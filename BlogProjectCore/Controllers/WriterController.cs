using BlogProjectCore.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjectCore.Controllers
{

    public class WriterController : Controller
    {

        WriterManager wm = new WriterManager(new EfWriterRepository());

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.mailName = usermail;

            Context c = new Context();

            var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult WriterEdit()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var writervalues = wm.TGetById(writerID);
            return View(writervalues);
        }

        [HttpPost]
        public IActionResult WriterEdit(Writer p)
        {
            WriterValidator wl = new WriterValidator();

            ValidationResult results = wl.Validate(p);

            if (results.IsValid)
            {
                wm.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();

            if (p.WriterImage != null)
            {

                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }

            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPasword = p.WriterPasword;
            w.WriterAbout = p.WriterAbout;          
            w.WriterStatus = true;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
