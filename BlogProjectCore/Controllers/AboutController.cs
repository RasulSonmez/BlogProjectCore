using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.Controllers
{
   
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutRepository());

        public IActionResult Index()
        {
            var values = abm.GetList();
            return View(values);
        }

        public PartialViewResult SocialMediaAbout()
        {
           
            return PartialView();    
        }
    }
}
