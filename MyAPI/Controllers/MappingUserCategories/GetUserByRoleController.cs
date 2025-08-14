using Domain.Interfaces.MappingCategories;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers.MappingCategories
{
    [ApiController]
    [Route("api/GET")]
    public class GetUserByRoleController : Controller
    {
        private readonly IGetUserByRoleService _getUserByRoleService;


        public GetUserByRoleController(IGetUserByRoleService getUserByRoleService)
        {
            _getUserByRoleService =  getUserByRoleService;
        }


        [HttpGet("userByRole")]
        public async Task<IActionResult> GetUserByRoleItem()
        {
            return Ok(await _getUserByRoleService.GetUserByRoleSupport());
        }

    }
}

