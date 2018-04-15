using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        public IProductRepository Repository { get; set; }
        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            this.Repository = repository;
        }

        public IActionResult List(string category, int page = 1)
        {
            IEnumerable<Product> products = this.Repository
                .Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * this.PageSize)
                .Take(this.PageSize);

            PagingInfo info = new PagingInfo {
                CurrentPage = page,
                ItemsPerPage = this.PageSize,
                TotalItems = category == null ?
                    this.Repository.Products.Count() :
                    this.Repository.Products.Where(p => p.Category == category)
                        .Count()
            };

            string currentCategory = category;

            return View(new ProductsListViewModel(products, info, currentCategory));
        }
    }
}
