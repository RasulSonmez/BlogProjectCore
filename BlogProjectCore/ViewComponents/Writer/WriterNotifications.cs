using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.ViewComponents.Writer
{
    public class WriterNotifications : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
