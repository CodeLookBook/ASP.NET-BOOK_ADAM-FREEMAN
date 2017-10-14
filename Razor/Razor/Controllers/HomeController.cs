using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Product product = new Product
            {
                ProductId   = 1,
                Name        = "Kayak",
                Category    = "Watersports",
                Description = "А boat for one person",
                Price       = 275M,
            };
            return View(product);
        }
    }
}