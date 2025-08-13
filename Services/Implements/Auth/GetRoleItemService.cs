using Domain.Interfaces.RegisterLogin;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.Auth
{
    public class GetRoleItemService : IGetRoleItemService
    {

        private readonly MYGAMEContext _context;

        public GetRoleItemService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetRoleItem() {
            var role = await _context.Role.Where(r => r.IsActive == true)
                       .Select(r => new Role
                       {
                           RoleId = r.RoleId,
                           RoleName = r.RoleName
                           
                       })
                       .ToListAsync();

            return role;
        }
    }


}
