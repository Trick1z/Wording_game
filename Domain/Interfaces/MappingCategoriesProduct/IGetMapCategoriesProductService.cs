using Domain.Models;
using Domain.ViewModels.MappingCategoriesProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.MappingCategoriesProduct
{
    public interface IGetMapCategoriesProductService
    {

        //public Task<IEnumerable<Product>> GetUnmappedProduct(int categories);
        //public Task<IEnumerable<Product>> GetMappedProduct(int categories);

        public Task<ProductWithSelectionDto> GetProductsWithSelection(int categoryId);



    }
}
