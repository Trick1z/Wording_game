using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.RegisterLogin
{
    public interface ILoginService
    {
        public Task<string> UserLoginAsync(LoginViewModel request);

    }
}
