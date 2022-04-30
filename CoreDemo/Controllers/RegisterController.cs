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

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterMenager wm = new WriterMenager(new EFWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            //ekleme işlemi yapılırken HttpGet ve HttpPost attiributelerinin tanımlandığı metotların isimleri aynı olmak zorundadır.
            //HttpGet=> SAyfa yüklenince;
            //HttpPost => Sayfada buton tetikelnince
            // Mesele HttpGET attiribute komutu sayfada kategorize veya benzeri işlemler kullanılırken  sayfa yükelnediği anda listelenmesii istenilen niteliklerde kullanılıabilir.
            //HttpPost metotdunun bir parametre alması gerekiyor.


            //Validasyon kontrol
            WriterValidator wv = new WriterValidator();
            ValidationResult result = wv.Validate(p);
            if (result.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
