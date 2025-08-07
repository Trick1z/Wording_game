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

            if (await IsNullOrEmptyString(request))
                return "All Field Are Required!";

            if (await IsUsernameInTable(request))
                return "Username Are Already Used !!";

            if (!await ArePasswordsMatching(request))
                return "Password do not match";

            var hashed = HashPassword(request);

            //add new member 
            User data = CreateRegisterData(request, hashed);
            AddMember(data);
            await OnSaveChange();

            return "Register Successfully";



            //return t,f
        }

        private async Task OnSaveChange()
        {
            await _context.SaveChangesAsync();
        }

        private void AddMember(User data)
        {
            _context.User.Add(data);
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

            if (string.IsNullOrWhiteSpace(request.Username)
                        || string.IsNullOrWhiteSpace(request.Password)
                        || string.IsNullOrWhiteSpace(request.ConfirmPassword)
                        || string.IsNullOrWhiteSpace(request.Role))
            {
                return true;
            }




            return false;
        }

        public async Task<bool> IsUsernameInTable(UserRegisterViewModel request)
        {
            var isExists = await _context.User
     .AnyAsync(u => u.Username == request.Username);

            return isExists;
        }

        public async Task<bool> ArePasswordsMatching(UserRegisterViewModel request)
        {
            if (request.Password == request.ConfirmPassword)
            {
                return true;
            }
            return false;
        }

        public string HashPassword(UserRegisterViewModel request)
        {
            return _hasher.HashPassword(null, request.Password);
        }





    }
}
