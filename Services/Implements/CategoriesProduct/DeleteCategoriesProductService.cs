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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services.Implements.CategoriesProduct
{
    public class DeleteCategoriesProductService : IDeleteCategoriesProductService
    {

        private readonly MYGAMEContext _context;

        public DeleteCategoriesProductService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IssueCategories>> DeleteCategoriesItems(DeleteCategories req)
        {
   

            var validate = new ValidateException();

            IssueCategories res = await isExists(req, validate);

            validate.Throw();

            var dateNow = DateTime.Now;

            //update isactive and save 
            res.IsActive= false;
            res.ModifiedTime = dateNow;
            await _context.SaveChangesAsync();

            return new List<IssueCategories> { res };

        }

        private async Task<IssueCategories> isExists(DeleteCategories req, ValidateException validate)
        {
            var isExists = await _context.IssueCategories
                            .FirstOrDefaultAsync(u => u.IssueCategoriesName == req.IssueCategoriesName &&
                                        u.IssueCategoriesId == req.IssueCategoriesId);

            if (isExists == null)
                validate.Add("Categories", "Not Found This Categories");
           

            return isExists;
        }
    }
}
