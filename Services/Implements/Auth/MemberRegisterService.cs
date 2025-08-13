using Azure;
using Domain.Exceptions;
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

namespace Services.Implements.Auth
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

            var validateException = new ValidateException();

            IsNullOrEmptyString(request, validateException);
            await IsUsernameInTable(request, validateException);
            ArePasswordsMatching(request, validateException);


            validateException.Throw();

            var hashed = HashPassword(request);

            //add new member 
            Member data = CreateRegisterData(request, hashed);

            _context.Member.Add(data);
            await _context.SaveChangesAsync();

            return "Register Successfully";



            //return t,f
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

        public bool IsNullOrEmptyString(MemberRegisterViewModel request , ValidateException validateException)
        {
            if (string.IsNullOrWhiteSpace(request.Username))
                validateException.Add("Username","Field Username must not be empty");

            if (string.IsNullOrWhiteSpace(request.Password))
                validateException.Add("Password","Field Password must not be empty");

            if (string.IsNullOrWhiteSpace(request.ConfirmPassword))
                validateException.Add("ConfirmPassword", "Field ConfirmPassword must not be empty");

            if (!request.IsVip)
                validateException.Add("IsVip", "Field IsVip must not be empty");

            



            return false;
        }

        public async Task<bool> IsUsernameInTable(MemberRegisterViewModel request , ValidateException validateException)
        {
            var isExists = await _context.Member.FirstOrDefaultAsync(u => u.Username == request.Username);

            if (isExists != null)
                validateException.Add("Username","Username are already taken");

            return false;
        }

        public bool ArePasswordsMatching(MemberRegisterViewModel request, ValidateException validateException)
        {
            if (request.Password != request.ConfirmPassword)
                validateException.Add("Password", "Password and ConfirmPassword do not match !");
            return false;
        }

        public string HashPassword(MemberRegisterViewModel request)
        {
            return _hasher.HashPassword(null, request.Password);
        }





    }
}
