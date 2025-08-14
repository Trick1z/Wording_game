using Domain.Interfaces.MappingCategories;
using Domain.Interfaces.MappingCategoriesProduct;
using Domain.ViewModels.MappingCategories;
using Domain.ViewModels.MappingCategoriesProduct;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers.MapCategoriesProduct
{

    [ApiController]
    [Route("api/[controller]")]
    public class InsertMapCategoriesProductController : Controller
    {
        private readonly IInsertMapCategoriesProductService _insertMapCategoriesProductService;



        public InsertMapCategoriesProductController(IInsertMapCategoriesProductService insertMapCategoriesProductService)
        {

            _insertMapCategoriesProductService = insertMapCategoriesProductService;
        }

        [HttpPost("MappingCategoriesProduct")]
        public async Task<IActionResult> InsertMappingCategoriesProductItem(MappingCategoriesProductItem req)
        {

            return Ok(await _insertMapCategoriesProductService.InsertMapCategoriesProduct(req));
        }
    }
}


