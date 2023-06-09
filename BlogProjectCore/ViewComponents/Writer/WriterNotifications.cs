﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectCore.ViewComponents.Writer
{
    public class WriterNotifications : ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());

        public IViewComponentResult Invoke()
        {
            var values = nm.GetList();
            return View(values);
        }
    }
}
