﻿using Microsoft.AspNetCore.Mvc;

namespace Shop.MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
