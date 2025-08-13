using Domain.Interfaces.MappingCategories;
using Domain.Interfaces.MappingCategoriesProduct;
using Microsoft.AspNetCore.Mvc;
using Services.Implements.MappingUser;

namespace MyAPI.Controllers.MapCategoriesProduct
{
    [ApiController]
    [Route("api/GET")]
    public class GetMapCategoriesProductController : ControllerBase
    {

        private readonly IGetMapCategoriesProductService _getMapCategoriesProductService;



        public GetMapCategoriesProductController(IGetMapCategoriesProductService getMapCategoriesProductService)
        {

            _getMapCategoriesProductService = getMapCategoriesProductService;
        }



        [HttpGet("unmappedCategories/{id}")]
        public async Task<IActionResult> GetUnmappedCategoryItems(int id)
        {
            return Ok(await _getMapCategoriesProductService.GetUnmappedProduct(id));
        }
        [HttpGet("mappedCategories/{id}")]
        public async Task<IActionResult> GetMappedCategoryItems(int id)
        {
            return Ok(await _getMapCategoriesProductService.GetMappedProduct(id));
        }


    }
}

