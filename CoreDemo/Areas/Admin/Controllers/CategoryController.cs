using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManeger cm = new CategoryManeger(new EFCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = cm.GetList().ToPagedList(page,3);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {

            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(p);
            if (result.IsValid)
            {
                p.CategoryStatus = true;
            
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");
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
        public IActionResult CategoryDelete(int id)
        {
            var value = cm.GetById(id);
            cm.TDelete(value); //value değişkeni tüm satırı seçiyor.
            return RedirectToAction("Index");
        }
    }
}
