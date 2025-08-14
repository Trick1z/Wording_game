using Domain.Interfaces.MappingCategories;
using Domain.Interfaces.MappingCategoriesProduct;
using Domain.Models;
using Domain.ViewModels.MappingCategoriesProduct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.MappingCategories
{
    public class GetMapCategoriesProductService : IGetMapCategoriesProductService
    {

        private readonly MYGAMEContext _context;

        public GetMapCategoriesProductService(MYGAMEContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Product>> GetUnmappedProduct(int categoryId)
        //{
        //    var unmappedProducts = await _context.Product
        //        .Where(p => p.IsActive
        //                    && !_context.RelCategoriesProduct
        //                        .Any(rc => rc.IssueCategoriesId == categoryId
        //                                   && rc.ProductId == p.ProductId))
        //        .ToListAsync();

        //    return unmappedProducts;
        //}
        public async Task<ProductWithSelectionDto> GetProductsWithSelection(int categoryId)
        {
            var allProducts = await _context.Product
                .Where(p => p.IsActive)
                .ToListAsync();

            var selectedProductIds = allProducts
                .Where(p => _context.RelCategoriesProduct
                    .Any(rc => rc.IssueCategoriesId == categoryId && rc.ProductId == p.ProductId))
                .Select(p => p.ProductId)
                .ToList();


            ProductWithSelectionDto data = new ProductWithSelectionDto();
            data.AllProducts = allProducts;
            data.SelectedProductIds = selectedProductIds;
            //return (allProducts, selectedProductIds);

            return data;
        }



        //public async Task<IEnumerable<Product>> GetMappedProduct(int categoryId)
        //{
        //    var mappedProducts = await _context.Product
        //        .Where(p => p.IsActive
        //                    && _context.RelCategoriesProduct
        //                        .Any(rc => rc.IssueCategoriesId == categoryId
        //                                   && rc.ProductId == p.ProductId))
        //        .ToListAsync();

        //    return mappedProducts;
        //}







    }
}
