using Domain.Interfaces.MappingCategories;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers.MappingCategories
{

    [ApiController]
    [Route("api/GET")]
    public class GetMapCategoriesController : Controller
    {
        private readonly IGetMapCategoriesItemService _getMapCategoriesItemService;



        public GetMapCategoriesController(IGetMapCategoriesItemService getMapCategoriesItemService)
        {

            _getMapCategoriesItemService = getMapCategoriesItemService;
        }

        [HttpGet("unmappedUserId/{id}")]
        public async Task<IActionResult> GetUnmappedCategoryItems(int id)
        {
            return Ok(await _getMapCategoriesItemService.GetUnmappedCategories(id));
        }
        [HttpGet("mappedUserId/{id}")]
        public async Task<IActionResult> GetmappedCategoryItems(int id)
        {
            return Ok(await _getMapCategoriesItemService.GetMappedCategories(id));
        }
    }
}
