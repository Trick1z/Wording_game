using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Word
{
    public  class WordDataService
    {
        private readonly MYGAMEContext _context;
        public WordDataService(MYGAMEContext context)
        {
            _context = context;
        }



        public async Task<object> GetWordByUserId(int id) {

            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var data = await _context.Word.Where(w => w.UserId == id  && w.ModifiedTime >= today && w.ModifiedTime < tomorrow)
            .Select(w => new
            {
                w.WordId,
                w.Word1,
                w.Score,
                Date = w.ModifiedTime
            })
            .ToListAsync();



            return data;
        
        
        
        }

        public async Task<bool> IsExist(string word) {


            var user = await _context.Word
      .FirstOrDefaultAsync(u => u.Word1 == word);

            if (user == null)
                return false;

            return true;
        }
    }
}
