using Domain.Interfaces.MappingCategories;
using Domain.Interfaces.MappingCategoriesProduct;
using Domain.Models;
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

        public async Task<IEnumerable<Product>> GetUnmappedProduct(int categoryId)
        {
            var unmappedProducts = await _context.Product
                .Where(p => p.IsActive
                            && !_context.RelCategoriesProduct
                                .Any(rc => rc.IssueCategoriesId == categoryId
                                           && rc.ProductId == p.ProductId))
                .ToListAsync();

            return unmappedProducts;
        }

        public async Task<IEnumerable<Product>> GetMappedProduct(int categoryId)
        {
            var mappedProducts = await _context.Product
                .Where(p => p.IsActive
                            && _context.RelCategoriesProduct
                                .Any(rc => rc.IssueCategoriesId == categoryId
                                           && rc.ProductId == p.ProductId))
                .ToListAsync();

            return mappedProducts;
        }







    }
}
