using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products        { get; set; }
        public PagingInfo           PagingInfo      { get; set; }
        public string               CurrentCategory { get; set; }

        public ProductsListViewModel(IEnumerable<Product> products, PagingInfo pagingInfo, string currentCategory)
        {
            this.Products        = products;
            this.PagingInfo      = pagingInfo;
            this.CurrentCategory = currentCategory;
        }
    }
}
