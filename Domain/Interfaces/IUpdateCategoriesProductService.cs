using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUpdateCategoriesProductService
    {

        public Task<IssueCategories> UpdateCategoriesItems(UpdateCategories req);
        public Task<Product> UpdateProductItems(UpdateProduct req);
    }
}
