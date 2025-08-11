using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Services.Auth;
//using Services.CalculateScore;
using Services.Word;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRegisterService _userRegisterService;
        private readonly IUserLoginService _userLoginService;

        public UserController(IUserRegisterService userRegisterService , IUserLoginService userLoginService)
        {

            _userRegisterService = userRegisterService;
            _userLoginService = userLoginService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterViewModel request)
        {
            return Ok(await _userRegisterService.UserRegisterAsync(request));
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel request)
        {
            return Ok(await _userLoginService.UserLoginAsync(request));
        }



    }
}
