using Domain.Interfaces.MappingCategories;
using Domain.ViewModels.MappingCategories;
using Domain.ViewModels.MappingCategoriesProduct;
using Microsoft.AspNetCore.Mvc;
using Services.Implements.MappingUser;

namespace MyAPI.Controllers.MappingCategories
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsertMappingCategoriesController : Controller
    {

        private readonly IInsertMapUserCategoriesService _insertMappingCategoriesService;



        public InsertMappingCategoriesController(IInsertMapUserCategoriesService insertMappingCategoriesService)
        {

            _insertMappingCategoriesService = insertMappingCategoriesService;
        }

        //[HttpPost("MappingUserCategories")]
        //public async Task<IActionResult> InsertMappingUserCategoriesItem(MappingItem req)
        //{
        //    return Ok(await _insertMappingCategoriesService.InsertMapUserCategoryAsync(req));
        //}

        [HttpPost("InsertMappingUserCategories")]
        public async Task<IActionResult> InsertMappingUserCategoriesItem(MappingUserCategoriesItem req)
        {
            return Ok(await _insertMappingCategoriesService.InsertMapUserCategories(req));
        }



        //[HttpPost("UnmappingUserCategories")]
        //public async Task<IActionResult> UpdateUnMappingUserCategoriesItem(UnMappingItem req)
        //{
        //    return Ok(await _insertMappingCategoriesService.UpdateUnMapUserCategoryAsync(req));
        //}


    }
}
