using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/UPDATE")]
    public class UpdateCategoriesProductController : Controller
    {
        private readonly  IUpdateCategoriesProductService _updateCategoriesProducts;
        public UpdateCategoriesProductController(IUpdateCategoriesProductService updateCategoriesProducts)
        {
            _updateCategoriesProducts = updateCategoriesProducts;
        }

        [HttpPost("Categories")]
        public async Task<IActionResult> DeleteCategoryItem([FromBody] UpdateCategories req)
        {
            return Ok(await _updateCategoriesProducts.UpdateCategoriesItems(req));
        }

        [HttpPost("Product")]
        public async Task<IActionResult> DeleteProductItem([FromBody] UpdateProduct req)
        {
            return Ok(await _updateCategoriesProducts.UpdateProductItems(req));
        }


    }
}
