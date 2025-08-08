using Domain.Exceptions;
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

namespace Services.Implements.Auth
{
    public class UserRegisterService :IUserRegisterService
    {

        private readonly MYGAMEContext _context;
        private readonly PasswordHasher<object> _hasher = new PasswordHasher<object>();


        public UserRegisterService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<string> UserRegisterAsync(UserRegisterViewModel request)
        {

            await IsNullOrEmptyString(request);
            await IsUsernameInTable(request);
            await ArePasswordsMatching(request);

            var hashed = HashPassword(request);

            //add new member 
            User data = CreateRegisterData(request, hashed);
            _context.User.Add(data);
            await _context.SaveChangesAsync();

            return "Register Successfully";
            //return t,f
        }

        private static User CreateRegisterData(UserRegisterViewModel request, string hashed)
        {
            var dateNow = DateTime.Now;

            var member = new User();
            member.Username = request.Username;
            member.Password = hashed;
            member.Role = request.Role;
            member.CreatedTime = dateNow;
            member.ModifiedTime = dateNow;

            return member;
        }

        public async Task<bool> IsNullOrEmptyString(UserRegisterViewModel request)
        {
            var error =new List<string>();



            if (string.IsNullOrWhiteSpace(request.Username))
                error.Add("Field Username are required");

            if (string.IsNullOrWhiteSpace(request.Password))
                error.Add("Field Password are required");

            if (string.IsNullOrWhiteSpace(request.ConfirmPassword))
                error.Add("Field ConfirmPassword are required");

            if (string.IsNullOrWhiteSpace(request.Role))
                error.Add("Field Role are required");

            if (error.Any())
                throw new ValidateException("UserRegister", string.Join(" , " , error));

            return false;
        }

        public async Task<bool> IsUsernameInTable(UserRegisterViewModel request)
        {
            var isExists = await _context.User
     .AnyAsync(u => u.Username == request.Username);

            if (isExists)
                throw new ValidateException("UserRegister","This Username are already taken!");

            return false;
        }   

        public async Task<bool> ArePasswordsMatching(UserRegisterViewModel request)
        {
            if (request.Password != request.ConfirmPassword)
                throw new ValidateException("UserRegister" , "Password and ConfirmPassword do not match");


            return true;
        }

        public string HashPassword(UserRegisterViewModel request)
        {
            return _hasher.HashPassword(null, request.Password);
        }





    }
}
