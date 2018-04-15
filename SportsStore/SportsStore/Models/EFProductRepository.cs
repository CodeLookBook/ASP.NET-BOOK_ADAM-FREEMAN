using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext Context;

        public EFProductRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public IQueryable<Product> Products => this.Context.Products;
    }
}
