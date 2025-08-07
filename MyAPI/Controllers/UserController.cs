using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.Auth;
using Services.CalculateScore;
using Services.Word;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        //private readonly CalculateScore _calculateScore;
        //private readonly WordDataService _wordDataService;
        private readonly IUserRegisterService _userRegisterService;

        // ✅ ASP.NET Core จะ Inject LoginService ให้เอง
        public UserController(IUserRegisterService userRegisterService)
        {

            _userRegisterService = userRegisterService;
            //_wordDataService = wordDataService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterViewModel request)
        {
            return Ok(await _userRegisterService.UserRegisterAsync(request));
        }



    }
}
