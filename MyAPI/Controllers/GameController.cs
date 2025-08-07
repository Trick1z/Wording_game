using Braintree;
using Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Services.Auth;
using Services.CalculateScore;
using Services.Word;
using System.Runtime.Intrinsics.Wasm;


namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {

        private readonly MYGAMEContext _context;
        private readonly CalculateScore _calculateScore;
        private readonly WordDataService _wordDataService;


        // ✅ ASP.NET Core จะ Inject LoginService ให้เอง
        public GameController( MYGAMEContext context , CalculateScore calculateScore , WordDataService wordDataService)
        {
            _context = context;
            _calculateScore = calculateScore;
            _wordDataService = wordDataService;
        }


        [HttpPost("InsertWordScoring/by/userid/{userid}")]
        public async Task<object> InsertWordScoring([FromBody] string word ,int  userid)
        {
            var new_word = await _calculateScore.FormatWord(word);

            //true if  word in db 
            var isExist = await _wordDataService.IsExist(new_word);
            if (isExist)
            {

                return Unauthorized(new { Message = "Word is already taken" });
            }

            var total = await _calculateScore.WordCalculate(word);

            Word PackedData = CreateNewData(userid, new_word, total);
            AddDataToDb(PackedData);
            OnSaveChange();

            return Ok(new { Messgae = " Word Added !" });

        }

        private void OnSaveChange()
        {
            _context.SaveChanges();
        }

        private void AddDataToDb(Word PackedData)
        {
            _context.Add(PackedData);
        }

        private static Word CreateNewData(int userid, string new_word, int total)
        {

            
            var newData = new Word();
            var dataNow = DateTime.Now;

            newData.Word1 = new_word;
            newData.Score = total;
            newData.UserId = userid;
            newData.CreatedTime = dataNow;
            newData.ModifiedTime = dataNow;

            return newData;
        }

        //[HttpGet("Word/{id}")]
        //public async Task<object> GetWordByUserid(int id)
        //{
        //    return await _wordDataService.GetWordByUserId(id);
        //}






    }
}
