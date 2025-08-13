using Domain.Interfaces.MappingCategories;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.MappingUser
{
    public class GetMapCategoriesItemService : IGetMapCategoriesItemService
    {


        private readonly MYGAMEContext _context;

        public GetMapCategoriesItemService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IssueCategories>> GetUnmappedCategories(int userId)
        {
            var unmappedCategories = await _context.IssueCategories
                        .Where(c => c.IsActive &&
                               !_context.Rel_User_Categories
                                   .Any(rc => rc.UserId == userId 
                                     && rc.IssueCategoriesId == c.IssueCategoriesId))
                        .ToListAsync();

            return unmappedCategories;
        }


        public async Task<IEnumerable<IssueCategories>> GetMappedCategories(int userId)
        {
            var mappedCategories = await _context.IssueCategories
                    .Where(c => c.IsActive &&
                           _context.Rel_User_Categories
                               .Any(rc => rc.UserId == userId
                                 && rc.IssueCategoriesId == c.IssueCategoriesId))
                    .ToListAsync();

            return mappedCategories;

        }



        //public async Task<IEnumerable<UserWithRoleViewModel>> GetUserByRoleSupport()
        //{
        //    var usersWithRole = await (from u in _context.User
        //                               join r in _context.Role
        //                                   on u.RoleId equals r.RoleId
        //                               where r.RoleId == 3
        //                               select new UserWithRoleViewModel
        //                               {
        //                                   UserId = u.UserId,
        //                                   Username = u.Username,
        //                                   RoleId = r.RoleId,
        //                                   RoleName = r.RoleName
        //                               }).ToListAsync();

        //    return usersWithRole;
        //}
    }
}
