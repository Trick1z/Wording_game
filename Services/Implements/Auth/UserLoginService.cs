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
            await IsNullOrEmptyString(request);
            var user = await IsUsernameInTable(request);

            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, user.Password, request.Password);

            if (!(result == PasswordVerificationResult.Success))
            {
                throw new ValidateException("UserLogin", "Username or Password are in correct !");
            }

            return "Login Successfully";

        }

       
        public async Task<bool> IsNullOrEmptyString(LoginViewModel request)
        {

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Username))
                errors.Add("Field Username must not be empty");

            if (string.IsNullOrWhiteSpace(request.Password))
                errors.Add("Field Password must not be empty");

            if (errors.Any())
            {
                throw new ValidateException("UserLogin", string.Join(" , ", errors));
            }



            return false;
        }

        public async Task<User> IsUsernameInTable(LoginViewModel request)
        {
            var isExists = await _context.User.FirstOrDefaultAsync(u => u.Username == request.Username);

            if (isExists == null)
            {
                throw new ValidateException("UserLogin", "Username or Password are in correct !");
            }

            return isExists;
        }

    }
}
