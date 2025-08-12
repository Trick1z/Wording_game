using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers
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


    }
}

