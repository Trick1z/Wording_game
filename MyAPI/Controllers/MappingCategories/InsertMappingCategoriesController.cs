using Domain.Interfaces.MappingCategories;
using Domain.ViewModels.MappingCategories;
using Microsoft.AspNetCore.Mvc;
using Services.Implements.MappingUser;

namespace MyAPI.Controllers.MappingCategories
{
    [ApiController]
    [Route("api/MAP")]
    public class InsertMappingCategoriesController : Controller
    {

        private readonly IInsertMappingCategoriesService _insertMappingCategoriesService;



        public InsertMappingCategoriesController(IInsertMappingCategoriesService insertMappingCategoriesService)
        {

            _insertMappingCategoriesService = insertMappingCategoriesService;
        }

        [HttpPost("MappingUserCategories")]
        public async Task<IActionResult> InsertMappingUserCategoriesItem(MappingItem req)
        {
            return Ok(await _insertMappingCategoriesService.InsertMapUserCategoryAsync(req));
        }


        [HttpPost("UnmappingUserCategories")]
        public async Task<IActionResult> UpdateUnMappingUserCategoriesItem(UnMappingItem req)
        {
            return Ok(await _insertMappingCategoriesService.UpdateUnMapUserCategoryAsync(req));
        }


    }
}
