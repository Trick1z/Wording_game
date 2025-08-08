using Azure.Core;
using Braintree;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Services.Implements.Auth
{
    public class LoginService : ILoginService
    {
        private readonly MYGAMEContext _context;

        public LoginService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<string> UserLoginAsync(LoginViewModel request)
        {

            var validateException = new ValidateException();

            await IsNullOrEmptySpace(request);

            User user = await IsUserInTable(request);

            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, user.Password, request.Password);



            if (!(result == PasswordVerificationResult.Success))

                throw new ValidateException("Username and password are incorrect.");


            return "Login Successfuly";

        }

        public async Task<bool> IsNullOrEmptySpace(LoginViewModel request) {
            var errors = new List<string>();


            if (string.IsNullOrWhiteSpace(request.Username))
                errors.Add("Field Username Much Not Empty");
            if (string.IsNullOrWhiteSpace(request.Password))
                errors.Add("Field Password Much Not Empty");
            if (errors.Any())
                throw new ValidateException("Login", string.Join(" , ", errors));

            return false;

        }

        public async Task<User> IsUserInTable(LoginViewModel request) {


            var user = await _context.User
               .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null)
                throw new ValidateException("Username and password are incorrect.");          

            return null;

        }

    }
}
