using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManeger bm = new BlogManeger(new EFBlogRepository());
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
            var values =bm.GetBlogListByWriter(1);
            return View(values);
        }
        //Admin tarafında yapılmayacak.
        //Sisteme otantike olan yazar kimse blog ekleme kısmını o yapacak.
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManeger cm = new CategoryManeger(new EFCategoryRepository());
            //Amacım blogları eklerken blogların categorilerini seçerken categorilerin ıd olarak gönderilmesi değil, dropdowndan seçilmesini sağlamak.
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text= x.CategoryName,
                                                        Value=x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues; //Viewbag sayesinde categoryvalues değişkeninden gelen değerleri dropdowna taşıyabilicez.
            return View();
           
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
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

    }
}
