using WorkingWithVisualStudio.Models;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            // Организация
            Product p = new Product() { Name = "Test", Price = 100M };

            // Действие
            p.Name = "New name";

            // Утверждение
            Assert.Equal("New name", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            // Организация
            Product p = new Product() { Name = "Test", Price = 100M };

            // Действие
            p.Price = 200M;

            // Утверждение
            Assert.Equal(200M, p.Price);
        }
    }
}
