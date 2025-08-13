using Domain.Exceptions;
using Domain.Interfaces.CategoriesProduct;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.CategoriesProduct
{
    public class InsertCategoriesService : IInsertCategoriesService
    {


        private readonly MYGAMEContext _context;

        public InsertCategoriesService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IssueCategories>>InsertCategoriesItems(InsertCategories requried)
        {
            var validate = new ValidateException();
            await IsNullOrEmptyString(requried, validate);
            await IsCategoryInTable(requried, validate);

            //var dateNow = DateTime.Now

            validate.Throw();



            IssueCategories data = PackedData(requried);

            _context.IssueCategories.Add(data);
            await _context.SaveChangesAsync();

            //return data;
            return new List<IssueCategories> { data };

        }

        private static IssueCategories PackedData(InsertCategories requried)

        {

            var dateNow = DateTime.Now;


            IssueCategories data = new IssueCategories();
            data.IssueCategoriesName = requried.IssueCategoriesName;
            data.IsProgramIssue = requried.IsProgramIssue;
            data.IsActive = true;
            data.CreateTime = dateNow;
            data.ModifiedTime = dateNow;
            return data;
        }

        public async Task<bool> IsCategoryInTable(InsertCategories request, ValidateException validate)
        {
            var isExists = await _context.IssueCategories
     .FirstOrDefaultAsync(u => u.IssueCategoriesName == request.IssueCategoriesName);

            if (isExists != null)
                validate.Add("CategoryName", "This CategoryName are already added!");

            return false;
        }


        public async Task<bool> IsNullOrEmptyString(InsertCategories requried, ValidateException validate)
        {
            if (string.IsNullOrWhiteSpace(requried.IssueCategoriesName))
                validate.Add("CategoryName", "Field CategoryName Much Not Empty");


            return false;
        }


    }
}
