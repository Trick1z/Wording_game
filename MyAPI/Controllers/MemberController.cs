using Braintree;
using Domain.Interfaces;
using Domain.Models;   // login request model
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Auth;
using System.Collections.Generic;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMemberRegisterService _registerService;


        // ✅ ASP.NET Core จะ Inject LoginService ให้เอง
        public MemberController(ILoginService loginService, IMemberRegisterService registerService)
        {
            _loginService = loginService;
            _registerService = registerService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel request)
        {
            return Ok(await _loginService.LoginAsync(request));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] MemberRegisterViewModel request)
        {
            return Ok(await _registerService.MemberRegisterAsync(request)); 
        }


        
    }
}
