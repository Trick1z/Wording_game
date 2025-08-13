using Domain.Models;
using Domain.ViewModels;
using Domain.ViewModels.MappingCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.MappingCategories
{
  

    public interface IInsertMappingCategoriesService
    {

        public Task<ServiceResult> InsertMapUserCategoryAsync(MappingItem req);
        public Task<ServiceResult> UpdateUnMapUserCategoryAsync(UnMappingItem req);

    }
}
