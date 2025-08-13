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

            IsNullOrEmptySpace(request, validateException);

            User user = await IsUserInTable(request , validateException);

            validateException.Throw();

            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, user.Password, request.Password);



            if (!(result == PasswordVerificationResult.Success))
                validateException.Add("Username,Password", "Username and password are incorrect.");
            //validateException.Throw();


            return "Login Successfuly";

        }

        public bool IsNullOrEmptySpace(LoginViewModel request , ValidateException validateException) {

            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                validateException.Add("Username","Field Username Much Not Empty");

            return false;

        }

        public async Task<User> IsUserInTable(LoginViewModel request, ValidateException validateException   ) {


            var user = await _context.User
               .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null)
                validateException.Add("Username,Password", "Username and password are incorrect.");

            return user;

        }

    }
}
