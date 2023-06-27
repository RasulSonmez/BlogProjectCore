using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProjectCore.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic3 :ViewComponent
    {
      Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.AdminName = c.Admins.Where(x => x.AdminID == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.AdminImg = c.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.AdminDes = c.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDescription).FirstOrDefault();

            return View();
        }
    }
}
