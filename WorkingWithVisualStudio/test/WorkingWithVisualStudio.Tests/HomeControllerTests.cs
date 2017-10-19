using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        #region Local classes

        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {
                // Для теста, реализация не требуется
                throw new NotImplementedException();
            }
        }

        class PropertyOnceFakeRepository : IRepository
        {
            public int PropertyConter { get; set; } = 0;
            public IEnumerable<Product> Products
            {
                get
                {
                    this.PropertyConter++;
                    return new[] { new Product { Name = "P1", Price = 100 } };
                }
            }

            public void AddProduct(Product p)
            {
                // для теста не требуется
                throw new NotImplementedException();
            }
        }

        public void RepositoryPropertyCalledOnce()
        {
            #region Организация
            var repo       = new PropertyOnceFakeRepository();
            var controller = new HomeController() { Repository = repo };
            #endregion

            #region Действие
            var result = controller.Index();
            #endregion

            #region Утверждение
            Assert.Equal(1, repo.PropertyConter);
            #endregion
        }
        #endregion

        #region Test methods

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product [] products)
        {
            // Организация
            var controller = new HomeController();

            controller.Repository = new ModelCompleteFakeRepository()
            {
                Products = products
            };

            // Действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model
                        as IEnumerable<Product>;

            // Утверждение
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                && p1.Price == p2.Price));
        }
        #endregion
    }
}
