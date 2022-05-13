using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{

    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterMenager wm = new WriterMenager(new EFWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            //Sisteme otantike olan kullanıcıya ait olan bilgiler için kullanılan metot.
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.v2 = writerID;
            var values = wm.GetWriterById(writerID);
            return View(values);
        }
    }
}
