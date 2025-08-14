using Domain.Models;
using Domain.ViewModels;
using Domain.ViewModels.MappingCategories;
using Domain.ViewModels.MappingCategoriesProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.MappingCategories
{
  

    //public interface IInsertMapUserCategoriesService
    public interface IInsertMapUserCategoriesService
    {
        public Task<Rel_User_Categories> InsertMapUserCategories(MappingUserCategoriesItem req);
        //public Task<ServiceResult> InsertMapUserCategoryAsync(MappingItem req);
        //public Task<ServiceResult> UpdateUnMapUserCategoryAsync(UnMappingItem req);

    }
}
