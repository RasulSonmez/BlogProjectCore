using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
