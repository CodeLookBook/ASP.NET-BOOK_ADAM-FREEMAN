using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository : IRepository
    {

        #region Fields

        private static SimpleRepository     sharedRepository = new SimpleRepository();
        private Dictionary<string, Product> products         = new Dictionary<string, Product>();

        #endregion



        #region Properties

        public static SimpleRepository SharedRepository => sharedRepository;
        public IEnumerable<Product> Products => this.products.Values;

        #endregion



        #region Constructors

        public SimpleRepository()
        {
            var initialItems = new[]
            {
                new Product { Name = "Kayak"        , Price = 275M    },
                new Product { Name = "Lifejacket"   , Price = 48.95M  },
                new Product { Name = "Soccer ball"  , Price = 19.50M  },
                new Product { Name = "Corner flag"  , Price = 34.95M  }
            };

            foreach (Product p in initialItems)
            {
                this.AddProduct(p);
            }

            this.products.Add("Error", null);
        }

        #endregion



        #region Functions

        public void AddProduct(Product product) => this.products.Add(product.Name, product);

        #endregion
    }
}
