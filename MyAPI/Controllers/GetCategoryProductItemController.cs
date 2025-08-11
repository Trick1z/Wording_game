using Domain.Exceptions;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/GET")]
    public class GetCategoryProductItemController : Controller
    {
        
            private readonly IGetCategoriesProductItemService _getCategoriesProducts;

           
        public GetCategoryProductItemController(IGetCategoriesProductItemService getCategoriesProducts)
        {
            _getCategoriesProducts = getCategoriesProducts;
        }


        [HttpGet("Categories/item")]
            public async Task<IActionResult> GetCategoryItem()
            {
                return Ok(await _getCategoriesProducts.GetCategoriesItems());
            }

            [HttpGet("Products/item")]
        public async Task<IActionResult> GetProductItems()
        {
            return Ok(await _getCategoriesProducts.GetProductItems());
        }


        //[HttpGet("Products")]
        //public async Task<IActionResult> GetRelCategoriesProduct()
        //{
        //    return Ok(await _getCategoriesProducts.GetProductItems());
        //}






    }
}
