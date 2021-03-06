using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    class ModelCompleteFakeRepository : IRepository
    {
        public IEnumerable<Product> Products { get; set; }

        public void AddProduct(Product p)
        {
            // do nothing - not required for test            
        } 
    }

    class ModelCompleteFakeRepositoryPricesUnder50 : IRepository
    {
        public IEnumerable<Product> Products { get; } = new Product[] {
            new Product { Name = "P1", Price = 5M     },
            new Product { Name = "P2", Price = 48.95M },
            new Product { Name = "P3", Price = 19.50M },
            new Product { Name = "P3", Price = 34.95M }
        };

        public void AddProduct(Product p)
        {                
            // do nothing - not required for test            
        }
    }

    class PropertyOnceFakeRepository : IRepository
    {
        public int PropertyCounter { get; set; } = 0;

        public IEnumerable<Product> Products {
            get
            {
                this.PropertyCounter++;
                return new[] { new Product { Name = "P1", Price = 100 } };
            }
        }

        public void AddProduct(Product p)
        {
            // do nothing - not required for test            
        }
    }



    public class HomeControllerTests
    {        
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            // Arrange      
            var mock = new Mock<IRepository>();

            mock.SetupGet(repository => repository.Products).Returns(products);

            var controller = new HomeController { Repository = mock.Object };

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert            
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            // Arrange            
            var mock = new Mock<IRepository>();

            mock.SetupGet(repository => repository.Products).Returns(new[] { new Product { Name = "P1", Price = 100M } });

            var controller = new HomeController { Repository = mock.Object };

            // Act            
            var result = controller.Index();

            // Assert            
            mock.VerifyGet(repository => repository.Products, Times.Once);
        }
    }
}
