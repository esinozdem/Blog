using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{

    public class BlogController : Controller
    {
        BlogManeger bm = new BlogManeger(new EFBlogRepository());
        CategoryManeger cm = new CategoryManeger(new EFCategoryRepository()); //kategorileri çekiyoruz.
        Context c = new Context();
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }
        //Sisteme otantike olan yazarların blogları gelsin.
        public IActionResult BlogListByWriter()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);

        }
        //Admin tarafında yapılmayacak.
        //Sisteme otantike olan yazar kimse blog ekleme kısmını o yapacak.
        [HttpGet]
        public IActionResult BlogAdd()
        {
           
          
            //Amacım blogları eklerken blogların categorilerini seçerken categorilerin ıd olarak gönderilmesi değil, dropdowndan seçilmesini sağlamak.

            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues; //Viewbag sayesinde categoryvalues değişkeninden gelen değerleri dropdowna taşıyabilicez.
            return View();

        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.GetById(id);
            bm.TDelete(blogvalue); //blogvalue değişkeni tüm satırı seçiyor.
            return RedirectToAction("BlogListByWriter");

        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            //önce blogu bulmamız gerekiyor güncelleyebilmemiz için.
            var blogvalue = bm.GetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues; //Viewbag sayesinde categoryvalues değişkeninden gelen değerleri dropdowna taşıyabilicez.
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            //Güncelleme işlemi için bazı sütunlara değer belirtmediğimiz için hata verebilir.
            p.WriterID = writerID;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }

    }
}
