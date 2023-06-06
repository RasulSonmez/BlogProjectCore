using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
