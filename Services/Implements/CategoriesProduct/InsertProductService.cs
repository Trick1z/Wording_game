using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.CategoriesProduct
{
    public class InsertProductService : IInsertProductService
    {

        private readonly MYGAMEContext _context;

        public InsertProductService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> InsertProductItem(InsertProduct requried)
        {
            var validate = new ValidateException();

            IsNullOrEmpty(requried, validate);
            await IsProductInTable(requried, validate);

            validate.Throw();

            Product data =  PackedData(requried);
            _context.Product.Add(data);
            await _context.SaveChangesAsync();


            return new List<Product> { data };

        }

        public static Product PackedData(InsertProduct requried)
        {
            var date = DateTime.Now;
            Product data = new Product();

            data.ProductName = requried.ProductName;
            data.CreateTime = date;
            data.IsActive = true;
            data.ModifiedTime = date;

            return data;
        }

        public bool IsNullOrEmpty(InsertProduct requried , ValidateException validate) {


            if (string.IsNullOrEmpty(requried.ProductName))
                validate.Add("ProductName", "ProductName Much Not Empty!!");

            return false;



        }
        public async Task<bool> IsProductInTable(InsertProduct request, ValidateException validate)
        {
            var isExists = await _context.Product
     .FirstOrDefaultAsync(u => u.ProductName == request.ProductName);

            if (isExists != null)
                validate.Add("ProductName", "This ProductName are already added!");

            return false;
        }


    }
}
