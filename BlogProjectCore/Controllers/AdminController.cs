using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProjectCore.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public PartialViewResult AdminNavbarPartial()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.InboxCount = c.Messages2.Where(x => x.ReceiverID == writerID).Select(y => y.MessageStatus == false).Count();

            return PartialView();
        }
    }
}
