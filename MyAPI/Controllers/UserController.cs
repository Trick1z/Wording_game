using Domain.Interfaces.RegisterLogin;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Services.Auth;
//using Services.CalculateScore;
using Services.Word;
using System.Security.Claims;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRegisterService _userRegisterService;
        private readonly IUserLoginService _userLoginService;
        private readonly IGetRoleItemService _getRoleItemService;

        public UserController(IUserRegisterService userRegisterService , IUserLoginService userLoginService, IGetRoleItemService getRoleItemService)
        {

            _userRegisterService = userRegisterService;
            _userLoginService = userLoginService;
            _getRoleItemService = getRoleItemService;
        }

        [HttpPost("register")]
        [AllowAnonymous]

        public async Task<IActionResult> Register([FromBody] UserRegisterViewModel request)
        {
            return Ok(await _userRegisterService.UserRegisterAsync(request));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel request)
        {
            return Ok(await _userLoginService.UserLoginAsync(request));
        }

        [HttpGet("role")] 
        public async Task<IActionResult> GetRole()
        {
            return Ok(await _getRoleItemService.GetRoleItem());
        }

        
        [HttpPost("check-access")]
        public async Task<IActionResult> CheckAccess([FromBody] CheckAccessRequestViewModel request)
        {
            return Ok(await _userLoginService.CheckAccessAsync(int.Parse(User.Claims.First(c => c.Type == ClaimTypes.Role).Value), request.PageUrl));
        }
    }
}
