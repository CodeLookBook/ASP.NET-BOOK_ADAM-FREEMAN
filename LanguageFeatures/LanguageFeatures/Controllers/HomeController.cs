using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index() => View(Product.GetProducts().Select(p => p?.Name));

        /*
        public IActionResult Index()
        {
            var products = new[] {
                new { Name = "Kayak"        , Price = 275M   },
                new { Name = "Lifejacet"    , Price = 48.95M },
                new { Name = "Soccer boll"  , Price = 19.50M },
                new { Name = "Corner flag"  , Price = 34.95M },
            };

            return View(products.Select(p => p.GetType()?.Name));
        }
        */

        public async Task<IActionResult> Index()
        {
            long? length = await MyAsyncMethods.GetPageLength();

            return View(new string[] { $"Length: {length}" });
        }
    }
}