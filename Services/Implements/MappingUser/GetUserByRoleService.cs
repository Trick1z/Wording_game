using Domain.Interfaces.MappingCategories;
using Domain.Models;
using Domain.ViewModels.MappingCategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.MappingUser
{
    public class GetUserByRoleService : IGetUserByRoleService
    {

        private readonly MYGAMEContext _context;

        public GetUserByRoleService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserWithRoleViewModel>> GetUserByRoleSupport()
        {
            var usersWithRole = await (from u in _context.User
                                       join r in _context.Role
                                           on u.RoleId equals r.RoleId
                                       where r.RoleId == 3
                                       select new UserWithRoleViewModel
                                       {
                                           UserId = u.UserId,
                                           Username = u.Username,
                                           RoleId = r.RoleId,
                                           RoleName = r.RoleName
                                       }).ToListAsync();

            return usersWithRole;
        }
    }
}
