using Braintree;
using Domain.Models;   // login request model
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Auth;
using System.Collections.Generic;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly RegisterService _RegisterService;
        private readonly MYGAMEContext _context;


        // ✅ ASP.NET Core จะ Inject LoginService ให้เอง
        public AuthController(LoginService loginService, RegisterService RegisterService, MYGAMEContext context)
        {
            _loginService = loginService;
            _RegisterService = RegisterService;
            _context = context;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
        {
            var hasher = new PasswordHasher<object>();

            (bool flowControl, IActionResult value) = CheckNullOrSpace(request);
            if (!flowControl)
            {
                return value;
            }




            var success = await _loginService.LoginAsync(request.Username, request.Password);

            if (!success)
                return Unauthorized(new { Message = "Invalid username or password." });

            return Ok(new { Message = "Login success" });
        }

        private (bool flowControl, IActionResult value) CheckNullOrSpace(LoginRequestModel request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return (flowControl: false, value: BadRequest(new { Message = "Username and password are required." }));
            return (flowControl: true, value: null);
        }

        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] RegisterRequiredModel request)
        {
            //checked username password cpasswaord isvip != null not be null empty str
            (bool flowControl, IActionResult value) = CheckNullOrSpace(request);
            if (!flowControl)
            {
                return value;
            }

            var isExists = await _RegisterService.RegisterAsync(request.Username);

            if (isExists) {
            
                return Unauthorized(new { Message = "User is already taken" });
            }



            //var success = await _RegisterService.RegisterAsync(request.Username, request.Password, request.ConfirmPassword, request.IsVip.Value);

            var isSamePassword = await _RegisterService.PassswordChecking(request.Password, request.ConfirmPassword);
            if (!isSamePassword)
                return Unauthorized(new { Message = "Passwords dont match" });


            var hashedPassword = await _RegisterService.HashPassword(request.Password);

            Member member = CreateNewRegisterData(request, hashedPassword);

            addDataToTable(member);

            await onSaveChange();

            return Ok(new  {data = member , Message = "Register success" });
        }

        private async Task onSaveChange()
        {
            await _context.SaveChangesAsync();
        }

        private void addDataToTable(Member member)
        {
            _context.Member.Add(member);
        }

        private static Member CreateNewRegisterData(RegisterRequiredModel request, string hashedPassword)
        {


            //set new data 

            var prepairData = new Member();
            var date = DateTime.Now;

            prepairData.Username = request.Username;
            prepairData.Password = hashedPassword;
            prepairData.IsVip = request.IsVip.Value;
            prepairData.CreatedTime = date;
            prepairData.ModifiedTime = date;

            return prepairData;
        }

        private (bool flowControl, IActionResult value) CheckNullOrSpace(RegisterRequiredModel request)
        {
            if (string.IsNullOrWhiteSpace(request.Username)
                        || string.IsNullOrWhiteSpace(request.Password)
                        || string.IsNullOrWhiteSpace(request.ConfirmPassword)
                        || !request.IsVip.HasValue
                        )
            {
                return (flowControl: false, value: BadRequest(new { Message = "Username, Password, ConfirmPassword, IsVip are required." }));
            }

            return (flowControl: true, value: null);
        }
    }
}
