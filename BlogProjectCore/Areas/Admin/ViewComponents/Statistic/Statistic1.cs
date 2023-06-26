using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace BlogProjectCore.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = bm.GetList().ToList().Count();
            ViewBag.MessageCount = c.Contacts.Count();
            ViewBag.CommentCount = c.Comments.Count();

            string api = "59ae7e420ee51ebffa30a7642e93774b";

            string city = "Istanbul";

            string connection =
                 "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = XDocument.Load(connection);
            ViewBag.HavaDurumu = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;    

            return View();
        }
    }
}
