using SportsStore.Models;
using System;
using System.Linq;
using Xunit;

namespace SportsStore.Tests.Models
{
    public class CartTests
    {
        [Fact]
        public void AddItem_CanAddNewLine()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            // Arrange - create a new cart
            Cart target = new Cart();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            CartLine[] results = target.Lines.ToArray();

            // Assert
            Assert.Equal(2 , results.Length    );
            Assert.Equal(p1, results[0].Product);
            Assert.Equal(p2, results[1].Product);
        }

        [Fact]
        public void AddItem_CanAddQuantityForExistingLines()
        {
            // Arrange - create some test producrs
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            // Arrange - create a new cart
            Cart target = new Cart();

            // Act
            target.AddItem(p1, 1 );          
            target.AddItem(p2, 1 );
            target.AddItem(p1, 10);

            CartLine[] results = target.Lines.OrderBy(c => c.Product.ProductID).ToArray();

            // Assert
            Assert.Equal(2 , results.Length     );
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1 , results[1].Quantity);
        }
    }
}