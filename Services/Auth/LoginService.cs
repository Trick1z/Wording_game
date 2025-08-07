using Azure.Core;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Services.Auth
{
    public class LoginService : ILoginService
    {
        private readonly MYGAMEContext _context;

        public LoginService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<string> LoginAsync(LoginViewModel request)
        {

            //checked null 
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return "Username and password are required.";
            }

            //checked user in db
            var user = await _context.Member
            .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null)
            {
              return "Username and password are incorrect.";
            }

            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, user.Password, request.Password);


            if (result == PasswordVerificationResult.Success)
            {
                return "Login successfully";
            }

            return "Somthing when wrong !";
        }
    }
}
