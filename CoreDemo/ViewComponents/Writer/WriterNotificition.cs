using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNotificition:ViewComponent
    {

        NotificitionManager nm = new NotificitionManager(new EFNotificitionRepository());
        public IViewComponentResult Invoke()
        {
            var values = nm.GetList();
            return View(values);
        }
    }
}
