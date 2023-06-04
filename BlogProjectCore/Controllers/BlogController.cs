using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
