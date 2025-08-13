using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.RegisterLogin
{
    public interface IUserRegisterService
    {
        public Task<string> UserRegisterAsync(UserRegisterViewModel request);


    }

    
}
