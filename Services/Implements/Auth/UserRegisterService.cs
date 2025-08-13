using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var validate = new ValidateException();
             IsNullOrEmptyString(request, validate);
            await IsUsernameInTable(request, validate);
            await IsPasswordLengthMinimum(request, validate);
            await ArePasswordsMatching(request, validate);


            validate.Throw();


            var hashed = HashPassword(request);

            //add new member 
            User data = CreateRegisterData(request, hashed);
            _context.User.Add(data);
            await _context.SaveChangesAsync();

            return "Register Successfully";

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

        public async Task<bool> IsPasswordLengthMinimum(UserRegisterViewModel request, ValidateException validate)
        {
            if (request.Password.Length < 6)

                validate.Add("Password","Password Length minimum Required 6");


            return true;
        }




        public bool IsNullOrEmptyString(UserRegisterViewModel request, ValidateException validate )
        {
           

            if (string.IsNullOrWhiteSpace(request.Username))
                validate.Add("Username","Field Username are required");

            if (string.IsNullOrWhiteSpace(request.Password))
                validate.Add("Password", "Field Password are required");

            


            if (string.IsNullOrWhiteSpace(request.ConfirmPassword))
                validate.Add("ConfirmPassword", "Field ConfirmPassword are required");

            if (string.IsNullOrWhiteSpace(request.Role))
                validate.Add("Role", "Field Role are required");


            return false;
        }

        public async Task<bool> IsUsernameInTable(UserRegisterViewModel request, ValidateException validate)
        {
            //var validat = new ValidateException();

            var isExists = await _context.User.FirstOrDefaultAsync(u => u.Username == request.Username);

            if (isExists != null)
                validate.Add("Username", "This Username are already taken!");

            return false;
        }   

        public async Task<bool> ArePasswordsMatching(UserRegisterViewModel request, ValidateException validate)
        {
            if (request.Password != request.ConfirmPassword)
                validate.Add("Password", "Password and ConfirmPassword do not match");


            return true;
        }

        public string HashPassword(UserRegisterViewModel request)
        {
            return _hasher.HashPassword(null, request.Password);
        }





    }
}
