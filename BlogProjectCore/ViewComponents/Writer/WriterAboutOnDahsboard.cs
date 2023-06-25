using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.ViewComponents.Writer
{
   

    public class WriterAboutOnDahsboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
    

        public IViewComponentResult Invoke()
        {

            var values = wm.GetWriterById(3);
            return View(values);
        }

    }
}
