using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.MappingCategories
{


    public interface IGetMapCategoriesItemService
    {

        public Task<IEnumerable<IssueCategories>> GetUnmappedCategories(int userId);
        public Task<IEnumerable<IssueCategories>> GetMappedCategories(int userId);
    }
}
