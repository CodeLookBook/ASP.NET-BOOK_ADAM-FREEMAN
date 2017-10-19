using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        #region PROPERTIES
        // PRIVATE
        private IProductRepository repository;
        #endregion


        #region CONSTRUCTORS
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        #endregion

        #region ACTIONS
        public IActionResult List() => View(this.repository.Products);
        #endregion
    }
}