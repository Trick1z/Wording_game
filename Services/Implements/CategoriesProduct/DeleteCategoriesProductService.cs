using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.CategoriesProduct
{
    internal class DeleteCategoriesProductService : IDeleteCategoriesProductService
    {

        private readonly MYGAMEContext _context;

        public DeleteCategoriesProductService(MYGAMEContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<IssueCategoiries>> DeleteCategoriesItems()
        //{
           
        //}




    }
}
