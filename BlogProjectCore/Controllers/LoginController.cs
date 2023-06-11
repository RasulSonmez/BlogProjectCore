using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
