using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGetCategoriesProductItemService
    {
        public Task<IEnumerable<IssueCategoiries>> GetCategoriesItems();
        public Task<IEnumerable<Product>> GetProductItems();
        //public Task<IEnumerable<ProductItems>> GetRelCategoriesProduct();
    }
}
