using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {

        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        

        public IViewComponentResult Invoke()
        {
            int id = 2;

            var values = mm.GetInboxListByWriter(id);

            return View(values);
        }
    }
}
