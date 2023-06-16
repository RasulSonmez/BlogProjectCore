using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
