using Braintree;
using Domain.Interfaces.RegisterLogin;
using Domain.Models;   // login request model
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Implements.Auth;

//using Services.Auth;
using System.Collections.Generic;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMemberRegisterService _registerService;
        private readonly IConfiguration _configuration;


        public MemberController(ILoginService loginService, IMemberRegisterService registerService, IConfiguration configuration)
        {
            _loginService = loginService;
            _registerService = registerService;
            _configuration = configuration;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel request)
        {
            return Ok(await _loginService.UserLoginAsync(request));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] MemberRegisterViewModel request)
        {
            return Ok(await _registerService.MemberRegisterAsync(request)); 
        }


        [HttpPost("token")]
        public async Task<IActionResult> Token()
        {
            var service = new JwtTokenService(_configuration);

            //auth before genarate token
            var token = service.GenerateToken("myuser","myrole");

            return Ok(token);   
        }

        [HttpPost("test/token")]
        [Authorize]
        public async Task<IActionResult> TestToken()
        {
            var userClaims = User.Claims;

            return Ok(userClaims);
        }





    }
}
