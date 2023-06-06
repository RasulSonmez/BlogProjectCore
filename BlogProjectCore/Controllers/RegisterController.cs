using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index()
        {

            return View();  
        }
    }
}
