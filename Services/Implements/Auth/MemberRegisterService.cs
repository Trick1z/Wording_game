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

            await IsNullOrEmptyString(request);
            await IsUsernameInTable(request);
            await ArePasswordsMatching(request);

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

        public async Task<bool> IsNullOrEmptyString(MemberRegisterViewModel request)
        {

            //if (string.IsNullOrWhiteSpace(request.Username)
            //            || string.IsNullOrWhiteSpace(request.Password)
            //            || string.IsNullOrWhiteSpace(request.ConfirmPassword)
            //            || !request.IsVip)
            //{
            //    return true;
            //}

            //var validate = new ValidateException()

            //if (string.IsNullOrWhiteSpace(request.Username))

            //    throw new ValidateException("Register","Field Username Much Not Empty");
            //if (string.IsNullOrWhiteSpace(request.Password))

            //    throw new ValidateException("Register", "Field Password Much Not Empty");
            //if (string.IsNullOrWhiteSpace(request.ConfirmPassword))

            //    throw new ValidateException("Register", "Field ConfirmPassword Much Not Empty");
            //if (!request.IsVip)

            //    throw new ValidateException("Register", "Field IsVip Much Not Empty");

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Username))
                errors.Add("Field Username must not be empty");

            if (string.IsNullOrWhiteSpace(request.Password))
                errors.Add("Field Password must not be empty");

            if (string.IsNullOrWhiteSpace(request.ConfirmPassword))
                errors.Add("Field ConfirmPassword must not be empty");

            if (!request.IsVip)
                errors.Add("Field IsVip must not be empty");

            if (errors.Any())
            {
                throw new ValidateException("MemberRegister", string.Join(" , ", errors));
            }



            return false;
        }

        public async Task<bool> IsUsernameInTable(MemberRegisterViewModel request)
        {
            var isExists = await _context.Member
     .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (isExists != null)
            {
                throw new ValidateException("MemberRegister", "This username are already taken!");
            }

            return false;
        }

        public async Task<bool> ArePasswordsMatching(MemberRegisterViewModel request)
        {
            if (request.Password != request.ConfirmPassword)
            {
                throw new ValidateException("MemberRegister", "Password and ConfirmPassword not match!");
            }
            return false;
        }

        public string HashPassword(MemberRegisterViewModel request)
        {
            return _hasher.HashPassword(null, request.Password);
        }





    }
}
