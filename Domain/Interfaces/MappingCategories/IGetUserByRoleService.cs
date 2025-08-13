using Domain.ViewModels.MappingCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.MappingCategories
{
    public interface IGetUserByRoleService
    {
        public Task<IEnumerable<UserWithRoleViewModel>> GetUserByRoleSupport();
    }
}
