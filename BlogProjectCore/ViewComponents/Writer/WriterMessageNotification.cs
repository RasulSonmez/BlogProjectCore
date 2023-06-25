using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {

        MessageManager mm = new MessageManager(new EFMessageRepository());
        

        public IViewComponentResult Invoke()
        {
            string p;

            p = "aliyildiz@gmail.com";
            var values = mm.GetInboxListByWriter(p);

            return View(values);
        }
    }
}
