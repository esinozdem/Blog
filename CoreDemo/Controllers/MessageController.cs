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
    [AllowAnonymous]
    public class MessageController : Controller
    {
        //Atılan tüm mesajlar ve ilgili mesaj gösterilecek.
        Message2Manager nm = new Message2Manager(new EFMessage2Repository());
        public IActionResult InBox()
        {
            int id = 2;
            var values = nm.GetInboxListWithByWriter(id);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            //önce mesajı bulmamız gerekiyor güncelleyebilmemiz için.
            var value = nm.GetById(id);
            return View(value);
        }
    }
}
