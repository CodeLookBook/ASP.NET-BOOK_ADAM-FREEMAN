using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SportsStore.Tests.Controllers
{
    public class ProductControllerTests
    {   
        [Fact]
        public void List_CanSendProductsListViewModelToView()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();

            mock.SetupGet(repository => repository.Products).Returns(new Product[] {
                new Product { ProductID=1, Name="P1", Category="C1" },
                new Product { ProductID=2, Name="P2", Category="C2" },
                new Product { ProductID=3, Name="P3", Category="C1" },
                new Product { ProductID=4, Name="P4", Category="C2" },
                new Product { ProductID=5, Name="P5", Category="C1" },
                new Product { ProductID=6, Name="P6", Category="C3" },
            }.AsQueryable());

            var controller = new ProductController(mock.Object) { PageSize = 2 };

            // Act
            var result   = controller.List("C2")     as ViewResult;
            var model    = result.ViewData.Model as ProductsListViewModel;

            // Assert
            mock.VerifyGet(repository => repository.Products, Times.AtLeastOnce);

            Assert.Equal(2   , model.Products.Count()               );

            Assert.Equal(2   , model.Products.ElementAt(0).ProductID);
            Assert.Equal("P2", model.Products.ElementAt(0).Name     );
            Assert.Equal("C2", model.Products.ElementAt(0).Category );
            Assert.Equal(4   , model.Products.ElementAt(1).ProductID);
            Assert.Equal("P4", model.Products.ElementAt(1).Name     );
            Assert.Equal("C2", model.Products.ElementAt(1).Category );

            Assert.Equal(2   , model.PagingInfo.ItemsPerPage        ); 
            Assert.Equal(1   , model.PagingInfo.CurrentPage         );
            Assert.Equal(2   , model.PagingInfo.TotalItems          );
        }
    }
}
