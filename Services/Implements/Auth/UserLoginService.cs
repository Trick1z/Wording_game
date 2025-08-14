using Domain.Exceptions;
using Domain.Interfaces.RegisterLogin;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.Auth
{
    public class UserLoginService : IUserLoginService
    {
        private readonly MYGAMEContext _context;
        private readonly IConfiguration _config; // ✅ inject IConfiguration


        public UserLoginService(MYGAMEContext context, IConfiguration config)
        {
            _context = context;
            _config =  config;
        }

        public async Task<LoginResponseViewModel> UserLoginAsync(LoginViewModel request)
        {
            var user = await _context.User.Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null) throw new Exception("User not found");

            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, user.Password, request.Password);
            if (result != PasswordVerificationResult.Success)
                throw new Exception("Username or Password are incorrect");

            // Query access pages
            var accessPages = await (from pr in _context.Rel_Page_Role
                                     join p in _context.Pages on pr.PageId equals p.PageId
                                     where pr.RoleId == user.RoleId && !p.IsDeleted
                                     select p.PageUrl).ToListAsync();

            // สร้าง JWT โดยใช้ RoleId (int)
            var token = GenerateJwtToken(user.UserId, user.RoleId);

            return new LoginResponseViewModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Role = user.Role.RoleName,  // สำหรับ display
                Token = token,
                AccessPages = accessPages
            };
        }

        public async Task<object> CheckAccessAsync(int roleId, string pageUrl)
        {
            var page = await _context.Pages
                .FirstOrDefaultAsync(p => p.PageUrl == pageUrl && !p.IsDeleted);

            if (page == null) 
                return new { allowed = false };

            bool allowed = await _context.Rel_Page_Role
                .AnyAsync(pr => pr.RoleId == roleId && pr.PageId == page.PageId);

            return new { allowed };
        }

        private string GenerateJwtToken(int userId, int roleId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



            var claims = new[]
{
    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
    new Claim(ClaimTypes.Role, roleId.ToString()) 
};




            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        //End new2

        public bool IsNullOrEmptyString(LoginViewModel request, ValidateException validateException)
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
