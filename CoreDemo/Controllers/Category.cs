using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class Category : Controller
    {
        CategoryManeger cm = new CategoryManeger(new EFCategoryRepository());
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
