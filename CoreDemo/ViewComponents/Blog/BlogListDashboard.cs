using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogListDashboard:ViewComponent
    {
        BlogManeger bm = new BlogManeger(new EFBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogListWithCategory(); //Kategoriyle irlikte getimesini istiyorum
            return View(values);
        }
    }
}
