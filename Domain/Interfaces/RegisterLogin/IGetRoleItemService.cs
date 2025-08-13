using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.RegisterLogin
{
    public interface IGetRoleItemService
    {
        public Task<IEnumerable<Role>> GetRoleItem();


    }
}
