using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
{
    public  class RegisterService
    {

        private readonly MYGAMEContext _context;
        private readonly PasswordHasher<object> _hasher = new PasswordHasher<object>();


        public RegisterService(MYGAMEContext context)
        {
            _context = context;
        }

     //   public async Task<bool> RegisterAsync(string username, string password,string confirmPassword , bool isVip )
     //   {

     //throw new Exception("save");

     //   }

        public async Task<bool> PassswordChecking(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }
            return false;
        }

        public async Task<string> HashPassword(string password)
        {
            // ใช้ Task.Run เพื่อให้เป็น async-friendly (จริง ๆ การ hash password ไม่ใช่ async แต่คุณอยากใช้ Task)
            return await Task.Run(() => _hasher.HashPassword(null, password));
        }

        public async Task<bool> RegisterAsync(string username)
        {
            var isExists = await _context.Member
     .AnyAsync(u => u.Username == username);

            return isExists;
            //return t,f
        }


    }
}
