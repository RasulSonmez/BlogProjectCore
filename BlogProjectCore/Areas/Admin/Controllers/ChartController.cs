﻿using BlogProjectCore.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogProjectCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();

            list.Add(new CategoryClass
            {
                categoryname="Teknoloji",
                categorycount=10
            });

            list.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });

            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 14
            });

            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 3
            });

            list.Add(new CategoryClass
            {
                categoryname = "Sinema",
                categorycount = 20
            });

            list.Add(new CategoryClass
            {
                categoryname = "Kitap",
                categorycount = 100
            });
            return Json(new {jsonlist = list});
        }
    }
}
