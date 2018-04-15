using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository : IRepository
    {
        private static SimpleRepository     sharedRepository = new SimpleRepository();
        private Dictionary<string, Product> products         = new Dictionary<string, Product>();

        public static SimpleRepository      SharedRepository => sharedRepository;
        public IEnumerable<Product>         Products         => this.products.Values;        

        public SimpleRepository()
        {
            var initialItems = new[] {
                new Product { Name = "Kayak"      , Price = 275M   },
                new Product { Name = "Lifejacket" , Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            };

            foreach (var item in initialItems)
            {
                this.AddProduct(item);
            }

            this.products.Add("Error", null);
        }

        public void AddProduct(Product p) => this.products.Add(p.Name, p);
    }
}
