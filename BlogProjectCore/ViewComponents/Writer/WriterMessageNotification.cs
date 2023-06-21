using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
