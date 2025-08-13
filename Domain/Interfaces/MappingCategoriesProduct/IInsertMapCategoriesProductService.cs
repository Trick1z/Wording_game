using Domain.Models;
using Domain.ViewModels.MappingCategoriesProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.MappingCategoriesProduct
{
    public interface IInsertMapCategoriesProductService
    {


        public Task<IEnumerable<RelCategoriesProduct>> InsertMapCategoriesProduct(MappingCategoriesProductItem req);





    }
}
