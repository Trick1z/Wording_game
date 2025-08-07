using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
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

            //checked null 
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return "Username and password are required.";
            }

            //checked user in db
            var user = await _context.User
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
