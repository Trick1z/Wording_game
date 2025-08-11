using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.CategoriesProduct
{
    public class GetCategoriesProductItemService : IGetCategoriesProductItemService
    {
        private readonly MYGAMEContext _context;

        public GetCategoriesProductItemService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IssueCategoiries>> GetCategoriesItems()
        {
            var categories = await _context.IssueCategoiries
                .Where(c => c.IsActive == true)
                        .Select(c => new IssueCategoiries
                        {
                            IssueCategoriesId = c.IssueCategoriesId,
                            CategoryName = c.CategoryName,
                            IsProgramIssue = c.IsProgramIssue,
                            IsActive = c.IsActive,
                            CreateTime = c.CreateTime,
                            ModifiedTime = c.ModifiedTime
                        })
                        .ToListAsync();

            return categories;
        }


        public async Task<IEnumerable<Product>> GetProductItems()
        {
            var products = await _context.Product
                    .Where(c => c.IsActive == true)
                        .Select(p => new Product
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            IsActive = p.IsActive,
                            
                            CreateTime =p.CreateTime
                            ,ModifiedTime  = p.ModifiedTime
                        

                        })
                        .ToListAsync();

            return products;
        }

    }
}

