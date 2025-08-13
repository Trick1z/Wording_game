using Domain.Interfaces.CategoriesProduct;
using Domain.Models;
using Domain.ViewModels.CategoriesProduct;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers.CategoriesProduct
{
    [ApiController]
    [Route("api/DELETE")]
    public class DeleteCategoriesProductController : Controller
    {
        private readonly IDeleteCategoriesProductService _deleteCategoriesProducts;
      


        public DeleteCategoriesProductController(IDeleteCategoriesProductService deleteCategoriesProducts)
        {
            _deleteCategoriesProducts = deleteCategoriesProducts;
        }

        [HttpPost("Categories")]
        public async Task<IActionResult> DeleteCategoryItem([FromBody] DeleteCategories req )
        {
            return Ok(await _deleteCategoriesProducts.DeleteCategoriesItems(req));
        }

        [HttpPost("Product")]
        public async Task<IActionResult> DeleteProductItem([FromBody] DeleteProduct req )
        {
            return Ok(await _deleteCategoriesProducts.DeleteProductItems(req));
        }


    }
}

