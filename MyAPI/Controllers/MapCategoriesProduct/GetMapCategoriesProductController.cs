using Domain.Interfaces.MappingCategories;
using Domain.Interfaces.MappingCategoriesProduct;
using Microsoft.AspNetCore.Mvc;
using Services.Implements.MappingUser;

namespace MyAPI.Controllers.MapCategoriesProduct
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetMapCategoriesProductController : ControllerBase
    {

        private readonly IGetMapCategoriesProductService _getMapCategoriesProductService;



        public GetMapCategoriesProductController(IGetMapCategoriesProductService getMapCategoriesProductService)
        {

            _getMapCategoriesProductService = getMapCategoriesProductService;
        }



        //[HttpGet("unmappedCategories/{id}")]
        //public async Task<IActionResult> GetUnmappedCategoryItems(int id)
        //{
        //    return Ok(await _getMapCategoriesProductService.GetUnmappedProduct(id));
        //}

        [HttpGet("GetProductsWithSelection/{id}")]
        public async Task<IActionResult> GetProductsWithSelection(int id)
        {
            return Ok(await _getMapCategoriesProductService.GetProductsWithSelection(id));
        }


    }
}

