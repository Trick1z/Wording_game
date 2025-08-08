using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.Auth
{
    public class UserLoginService : IUserLoginService
    {
        private readonly MYGAMEContext _context;

        public UserLoginService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<string> UserLoginAsync(LoginViewModel request)
        {

            var validateException = new ValidateException();


            //checked null 
            await IsNullOrEmptyString(request , validateException);
            var user = await IsUsernameInTable(request , validateException);

            validateException.Throw();

            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, user.Password, request.Password);

            if (!(result == PasswordVerificationResult.Success))
            {
                validateException.Add("Username,Password", "Username or Password are in correct !");
            }

            validateException.Throw();

            return "Login Successfully";

        }

       
        public async Task<bool> IsNullOrEmptyString(LoginViewModel request, ValidateException validateException)
        {


            if (string.IsNullOrWhiteSpace(request.Username))
                validateException.Add("Username","Field Username must not be empty");

            if (string.IsNullOrWhiteSpace(request.Password))
                validateException.Add("Password","Field Password must not be empty");

            return false;
        }

        public async Task<User> IsUsernameInTable(LoginViewModel request , ValidateException validateException)
        {
            var isExists = await _context.User.FirstOrDefaultAsync(u => u.Username == request.Username);

            if (isExists == null)
                validateException.Add("Username,Password", "Username or Password are in correct !");

            return isExists;
        }

    }
}
