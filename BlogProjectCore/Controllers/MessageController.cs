using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        public IActionResult InBox()
        {
            int id = 2;

            var values = mm.GetInboxListByWriter(id);

            return View(values);
        }


        public IActionResult MessageDetail(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }



    }
}
