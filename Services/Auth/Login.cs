using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Services.Auth
{
    public class LoginService
    {
        private readonly MYGAMEContext _context;

        public LoginService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {




            //       var isExists = await _context.Member
            //.AnyAsync(u => u.Username == username && u.Password == password);

            //       return isExists;
            //return t,f

            var user = await _context.Member
       .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return false;

            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, user.Password, password);

            return result == PasswordVerificationResult.Success;


        }
    }
}
