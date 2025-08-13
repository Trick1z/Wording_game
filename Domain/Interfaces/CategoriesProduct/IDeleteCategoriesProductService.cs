using Domain.Models;
using Domain.ViewModels.CategoriesProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.CategoriesProduct
{
    public interface IDeleteCategoriesProductService
    {
        public Task<IEnumerable<IssueCategories>> DeleteCategoriesItems(DeleteCategories req);
        public Task<IEnumerable<Product>> DeleteProductItems(DeleteProduct req);


    }
}
