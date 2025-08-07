using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
{
    public  class MemberRegisterService :  IMemberRegisterService
    {

        private readonly MYGAMEContext _context;
        private readonly PasswordHasher<object> _hasher = new PasswordHasher<object>();


        public MemberRegisterService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<string> MemberRegisterAsync(MemberRegisterViewModel request)
        {

            if (await IsNullOrEmptyString(request))
                return "All Field Are Required!";

            if (await IsUsernameInTable(request))
                return "Username Are Already Used !!";

            if (!await ArePasswordsMatching(request))
                return "Password do not match";

            var hashed = HashPassword(request);

            //add new member 
            Member data = CreateRegisterData(request, hashed);
            AddMember(data);
            await OnSaveChange();

            return "Register Successfully";



            //return t,f
        }

        private async Task OnSaveChange()
        {
            await _context.SaveChangesAsync();
        }

        private void AddMember(Member data)
        {
            _context.Member.Add(data);
        }

        private static Member CreateRegisterData(MemberRegisterViewModel request, string hashed)
        {
            var dateNow = DateTime.Now;

            var member = new Member();
            member.Username = request.Username;
            member.Password = hashed;
            member.IsVip = request.IsVip;
            member.CreatedTime = dateNow;
            member.ModifiedTime = dateNow;

            return member;
        }

        public async Task<bool> IsNullOrEmptyString(MemberRegisterViewModel request)
        {

            if (string.IsNullOrWhiteSpace(request.Username)
                        || string.IsNullOrWhiteSpace(request.Password)
                        || string.IsNullOrWhiteSpace(request.ConfirmPassword)
                        || !request.IsVip)
            {
                return true;
            }

            


            return false;
        }

        public async Task<bool> IsUsernameInTable(MemberRegisterViewModel request)
        {
            var isExists = await _context.Member
     .AnyAsync(u => u.Username == request.Username);

            return isExists;
        }

        public async Task<bool> ArePasswordsMatching(MemberRegisterViewModel request)
        {
            if (request.Password == request.ConfirmPassword)
            {
                return true;
            }
            return false;
        }

        public string HashPassword(MemberRegisterViewModel request)
        {
            return _hasher.HashPassword(null, request.Password);
        }





    }
}
