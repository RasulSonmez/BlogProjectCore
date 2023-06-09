﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using System.Linq;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace BlogProjectCore.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }


        public IActionResult BlogListByWriter(int id)
        {
         
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {

            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;

            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerID;
                bm.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
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


        public IActionResult BlogDelete(int id)
        {
            var value = bm.TGetById(id);
            bm.TDelete(value);
            return RedirectToAction("BlogListByWriter");
        }


        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            var value = bm.TGetById(id);
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(value);
        }

        [HttpPost]
        public IActionResult BlogEdit(Blog blog)
        {

            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            blog.WriterID = writerID;

            blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            bm.TUpdate(blog);
        
            return RedirectToAction("BlogListByWriter");




        }


        public IActionResult ChangeStatusBlog(int id)
        {
            var blogValue = bm.TGetById(id);
            if (blogValue.BlogStatus)
            {
                blogValue.BlogStatus = false;
            }
            else
            {
                blogValue.BlogStatus = true;
            }
            bm.TUpdate(blogValue);
            return RedirectToAction("BlogListByWriter");
        }


    }
}
