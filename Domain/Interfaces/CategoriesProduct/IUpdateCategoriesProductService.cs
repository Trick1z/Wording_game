using Domain.Models;
using Domain.ViewModels.CategoriesProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.CategoriesProduct
{
    public interface IUpdateCategoriesProductService
    {

        public Task<IssueCategories> UpdateCategoriesItems(UpdateCategories req);
        public Task<Product> UpdateProductItems(UpdateProduct req);
    }
}
