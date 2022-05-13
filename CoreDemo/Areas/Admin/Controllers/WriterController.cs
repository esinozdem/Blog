using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            //Aşağıdaki listeyi bir değişkene a5tayıp bu değişkeni json türüne convert etmem lazım.
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        //Dışardan gönderdiğim parametreye göre o parametredeki değeri getirmek istiyorum. ID'ye göre yazar getir.
        public IActionResult GetWriterByID(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);

        }
        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonwriters = JsonConvert.SerializeObject(w);
            return Json(jsonwriters);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.Id == w.Id); //önce yazarı bulduk.
            writer.Name = w.Name;
            var jsonwriter = JsonConvert.SerializeObject(w);
            return Json(jsonwriter);
        }

        public static List<WriterClass> writers = new List<WriterClass>()
        {
            new WriterClass
            {
                Id=1,
                Name="Ayse"
            },
            new WriterClass
            {
                Id=2,
                Name="Ali"
            },
            new WriterClass
            {
                Id=3,
                Name="Mehmet"
            }
        };
    }
}
