using Domain.Interfaces.MappingCategories;
using Domain.Models;
using Domain.ViewModels;
using Domain.ViewModels.MappingCategories;
using Domain.ViewModels.MappingCategoriesProduct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.MappingUser
{
    public class GetMapCategoriesItemService : IGetMapCategoriesItemService
    {


        private readonly MYGAMEContext _context;

        public GetMapCategoriesItemService(MYGAMEContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<IssueCategories>> GetUnmappedCategories(int userId)
        //{
        //    var unmappedCategories = await _context.IssueCategories
        //                .Where(c => c.IsActive &&
        //                       !_context.Rel_User_Categories
        //                           .Any(rc => rc.UserId == userId 
        //                             && rc.IssueCategoriesId == c.IssueCategoriesId))
        //                .ToListAsync();

        //    return unmappedCategories;
        //}


        //public async Task<IEnumerable<IssueCategories>> GetMappedCategories(int userId)
        //{
        //    var mappedCategories = await _context.IssueCategories
        //            .Where(c => c.IsActive &&
        //                   _context.Rel_User_Categories
        //                       .Any(rc => rc.UserId == userId
        //                         && rc.IssueCategoriesId == c.IssueCategoriesId))
        //            .ToListAsync();

        //    return mappedCategories;

        //}





        public async Task<CategoriesWithSelectionDto> GetUserMapCategoriesDropDown(int userId)
        {
            // ดึง category ทั้งหมดที่ active
            var allCategories = await _context.IssueCategories
                .Where(c => c.IsActive)
                .ToListAsync();

            // ดึง categoryId ที่ user แมพอยู่
            var selectedCategoryIds = await _context.Rel_User_Categories
                .Where(rc => rc.UserId == userId)
                .Select(rc => rc.IssueCategoriesId)
                .ToListAsync();

            // สร้าง DTO
            var data = new CategoriesWithSelectionDto
            {
                AllProducts = allCategories,
                SelectedCategories = selectedCategoryIds
            };

            return data;
        }
    }
}
