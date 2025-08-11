using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsertCategoriesController : Controller
    {
        
        

            private readonly IInsertCategoriesService _insertCategories;
            private readonly IInsertProductService _insertProduct;

            public InsertCategoriesController(IInsertCategoriesService insertCategories , IInsertProductService insertProductService)
            {

                _insertCategories = insertCategories;
                _insertProduct = insertProductService;
            }

        [HttpPost("add-categories")]
        public async Task<IActionResult> InsertCategoriesItems([FromBody] InsertCategories request)
        {

            return Ok(await _insertCategories.InsertCategoriesItems(request));
        }


        [HttpPost("add-product")]
        public async Task<IActionResult> InsertProductItems([FromBody] InsertProduct request)
        {
            return Ok(await _insertProduct.InsertProductItem(request));
        }

    }
}
