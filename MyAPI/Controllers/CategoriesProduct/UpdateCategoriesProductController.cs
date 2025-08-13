using Domain.Interfaces.CategoriesProduct;
using Domain.ViewModels.CategoriesProduct;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers.CategoriesProduct
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
        public async Task<IActionResult> UpdateCategoryItem([FromBody] UpdateCategories req)
        {
            return Ok(await _updateCategoriesProducts.UpdateCategoriesItems(req));
        }

        [HttpPost("Product")]
        public async Task<IActionResult> UpdateProductItem([FromBody] UpdateProduct req)
        {
            return Ok(await _updateCategoriesProducts.UpdateProductItems(req));
        }


    }
}
