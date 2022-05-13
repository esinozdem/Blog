using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        //kategorilerin grafik üzerinde listeleneceği action.
        public IActionResult Index()
        {
            return View();
        }
        //verilerime static olarak değer atamamı sağlayan action.
        public IActionResult CategoryChart()
        {

            List<CategoryClass> list = new List<CategoryClass>();

            list.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 14
            });
            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 5
            });
            return Json(new { jsonlist = list });
        }

    }
}
