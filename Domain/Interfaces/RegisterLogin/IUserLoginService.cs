using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.RegisterLogin
{
    public interface IUserLoginService
    {


        public Task<LoginResponseViewModel> UserLoginAsync(LoginViewModel request);
        Task<object> CheckAccessAsync(int roleId, string pageUrl);
    }
}
