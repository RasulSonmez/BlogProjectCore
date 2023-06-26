using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProjectCore.ViewComponents.Writer
{
   

    public class WriterAboutOnDahsboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
    

        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;       

            Context c = new Context();

            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            var values = wm.GetWriterById(writerID);
            return View(values);
        }

    }
}
