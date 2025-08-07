using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserLoginService
    {


        public Task<string> UserLoginAsync(LoginViewModel request);
    }
}
