using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
