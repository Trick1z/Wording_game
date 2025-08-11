using Domain.Exceptions;
using Domain.Interfaces;
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

        public async Task<IEnumerable<IssueCategoiries>>InsertCategoriesItems(InsertCategories requried)
        {
            var validate = new ValidateException();
            await IsNullOrEmptyString(requried, validate);
            await IsCategoryInTable(requried, validate);

            //var dateNow = DateTime.Now

            validate.Throw();

            

            IssueCategoiries data = PackedData(requried);

            _context.IssueCategoiries.Add(data);
            await _context.SaveChangesAsync();

            //return data;
            return new List<IssueCategoiries> { data };

        }

        private static IssueCategoiries PackedData(InsertCategories requried)

        {

            var dateNow = DateTime.Now;


            IssueCategoiries data = new IssueCategoiries();
            data.CategoryName = requried.CategoryName;
            data.IsProgramIssue = requried.IsProgramIssue;
            data.IsActive = true;
            data.CreateTime = dateNow;
            data.ModifiedTime = dateNow;
            return data;
        }

        public async Task<bool> IsCategoryInTable(InsertCategories request, ValidateException validate)
        {
            var isExists = await _context.IssueCategoiries
     .FirstOrDefaultAsync(u => u.CategoryName == request.CategoryName);

            if (isExists != null)
                validate.Add("CategoryName", "This CategoryName are already added!");

            return false;
        }


        public async Task<bool> IsNullOrEmptyString(InsertCategories requried, ValidateException validate)
        {
            if (string.IsNullOrWhiteSpace(requried.CategoryName))
                validate.Add("CategoryName", "Field CategoryName Much Not Empty");


            return false;
        }


    }
}
