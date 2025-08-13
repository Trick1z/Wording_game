using Domain.Exceptions;
using Domain.Interfaces.CategoriesProduct;
using Domain.Models;
using Domain.ViewModels.CategoriesProduct;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Services.Implements.CategoriesProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.CategoriesProduct
{
    public class UpdateCategoriesProductService : IUpdateCategoriesProductService
    {
        private readonly MYGAMEContext _context;
        public UpdateCategoriesProductService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<IssueCategories> UpdateCategoriesItems(UpdateCategories req)
        {
            var validate = new ValidateException();

            IsCategoriesIdValidate(req, validate);
            IsCategoriesFieldNullOrEmptyString(req, validate);

            IssueCategories resp = await IsCategoriesInDatabase(req, validate);

            validate.Throw();

            var dateNow = DateTime.Now;
            resp.IssueCategoriesName = req.IssueCategoriesName;
            resp.IsProgramIssue = req.IsProgramIssue;
            resp.ModifiedTime = dateNow;

            await _context.SaveChangesAsync();



            //return new List<IssueCategories> { resp };
            return resp ;

        }

        public async Task<Product> UpdateProductItems(UpdateProduct req)
        {
            var validate = new ValidateException();

            IsProductIdValidate(req, validate);
            IsProductFieldNullOrEmptyString(req, validate);
            Product resp = await IsProductInDatabase(req, validate);

             validate.Throw();

            var dateNow = DateTime.Now;
            resp.ProductName = req.ProductName;
            resp.ModifiedTime = dateNow;

            await _context.SaveChangesAsync();

            return  resp ;

        }


        //futures



        private async Task<IssueCategories> IsCategoriesInDatabase(UpdateCategories req, ValidateException validate)
        {
            var IsInDb = await _context.IssueCategories.FirstOrDefaultAsync(u => u.IssueCategoriesId == req.IssueCategoriesId);

            if (IsInDb == null)
                validate.Add("Categories", "Not Found Categories");

            return IsInDb;
        }


        private bool IsCategoriesFieldNullOrEmptyString(UpdateCategories req, ValidateException validate)
        {
            if (string.IsNullOrWhiteSpace(req.IssueCategoriesName)) { 
                validate.Add("Categories", "IssueCategoriesName is required for update");
                return true;
            }

            return false;
        }
       

        private bool IsCategoriesIdValidate(UpdateCategories req, ValidateException validate)
        {
            if (req.IssueCategoriesId < 0)
            {
                validate.Add("Categories", "IssueCategoriesId is required for update");

                return false;
            }

            return true;
        }

        //product
        private bool IsProductIdValidate(UpdateProduct req, ValidateException validate)
        {
            if (req.ProductId < 0)
            {
                validate.Add("Product", "ProductId is required for update");

                return false;
            }

            return true;
        }
        private bool IsProductFieldNullOrEmptyString(UpdateProduct req, ValidateException validate)
        {
            if (string.IsNullOrWhiteSpace(req.ProductName))
            {
                validate.Add("Product", "ProductName is required for update");
                return true;
            }

            return false;
        }

        private async Task<Product> IsProductInDatabase(UpdateProduct req, ValidateException validate)
        {
            var IsInDb = await _context.Product.FirstOrDefaultAsync(u => u.ProductId == req.ProductId);

            if (IsInDb == null)
                validate.Add("Product", "Not Found Product");

            return IsInDb;

        }

        //private static UpdateProductData(UpdateProduct req, Product resp)
        //{
           

        //    //return true;
        //}


    }



}




