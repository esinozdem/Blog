using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class NotificitionController : Controller
    {
        NotificitionManager nm = new NotificitionManager(new EFNotificitionRepository());
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult AllNotificition()
        {
            var values = nm.GetList();
            return View(values);
        }
    }
}
