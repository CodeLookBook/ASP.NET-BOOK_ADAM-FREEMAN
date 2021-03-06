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

        [Fact]
        public void RemoveLine_CanRemoveLine()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };

            // Arrange - craete new cart
            Cart target = new Cart();

            // Arrange - add somme producats to the cart
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            // Act
            target.RemoveLine(p2);

            // Assert
            Assert.Equal(0, target.Lines.Where(l => l.Product == p2).Count());
            Assert.Equal(2, target.Lines.Count());
        }

        [Fact]
        public void ComputeTotalValue_CanCalculateCartTotalValue()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            // Arrange - create new cart
            Cart target = new Cart();

            // Arrange - add some products to the cart
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);

            // Act
            decimal result = target.ComputeTotalValue();

            // Assert
            Assert.Equal(450M, result);
        }

        [Fact]
        public void Clear_CanClearContents()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            // Arrange - create a new cart
            Cart target = new Cart();

            // Arrange - add some items
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            // Act - reset the cart
            target.Clear();

            // Assert 
            Assert.Equal(0, target.Lines.Count());
        }
    }
}
