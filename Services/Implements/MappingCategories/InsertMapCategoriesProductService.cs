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
    public class InsertMapCategoriesProductService : IInsertMapCategoriesProductService
    {

        private readonly MYGAMEContext _context;

        public InsertMapCategoriesProductService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RelCategoriesProduct>> InsertMapCategoriesProduct (MappingCategoriesProductItem req)
        {


            var category = await _context.IssueCategories.Include(x => x.RelCategoriesProduct)
                .FirstOrDefaultAsync(x => x.IssueCategoriesId == req.CategoriesId);

            var products = await _context.Product.Where(x => x.IsActive == true)
                .Where(x => req.ProductsId.Contains(x.ProductId)).ToListAsync();

            
            var list = new List<RelCategoriesProduct>();
            foreach (var item in products)
            {
                list.Add(new RelCategoriesProduct()
                {
                    Product = item,
                    IssueCategories = category,
                    IsActive = true,
                    DeleteFlag = "N",
                    CreateTime = DateTime.Now,
                     ModifiedTime = DateTime.Now
                });
            }

            category.RelCategoriesProduct = list;

            await _context.SaveChangesAsync();

            
            return null;
        }
    }
}
