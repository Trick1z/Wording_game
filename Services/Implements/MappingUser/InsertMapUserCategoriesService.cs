using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces.MappingCategories;
using Domain.Models;
using Domain.ViewModels.MappingCategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements.MappingUser
{
    public class InsertMapUserCategoriesService : IInsertMapUserCategoriesService
    {

        private readonly MYGAMEContext _context;

        public InsertMapUserCategoriesService(MYGAMEContext context)
        {
            _context = context;
        }

        
           public async Task<ServiceResult> InsertMapUserCategoryAsync(MappingItem req)
           {
                using var transaction = await _context.Database.BeginTransactionAsync();

                var validat = new ValidateException();
                var dateNow = DateTime.Now;

               
                    await IsExists(req, validat);
                    validat.Throw();

                    // Insert Rel
                    Rel_User_Categories rel = NewRelData(req, dateNow);
                    _context.Rel_User_Categories.Add(rel);

                    // Insert Log
                    Log_Rel_User_Categories log = NewLogData(req, dateNow);
                    _context.Log_Rel_User_Categories.Add(log);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
               

                return new ServiceResult { Success = true, Message = "Mapping completed" };
           }

        //unmap
        public async Task<ServiceResult> UpdateUnMapUserCategoryAsync(UnMappingItem req)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var validat = new ValidateException();
            var dateNow = DateTime.Now;

            try
            {
                //Log_Rel_User_Categories logs = await IsExists(req, validat);


                Rel_User_Categories rel = await IsRelExists(req, validat);


                validat.Throw();

                //update log
                Log_Rel_User_Categories logs = new Log_Rel_User_Categories();

                logs.UserId = req.UserId;
                logs.IssueCategoriesId = rel.IssueCategoriesId;
                logs.ActionTime = dateNow;
                logs.ActionBy = Constance.AdminId;
                logs.ActionType = "Remove Categories";

                _context.Rel_User_Categories.Remove(rel);
                _context.Log_Rel_User_Categories.Add(logs);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

            return new ServiceResult { Success = true, Message = "Mapping completed" };
        }

        private async Task<Rel_User_Categories> IsRelExists(UnMappingItem req, ValidateException validat)
        {
            var exists = await _context.Rel_User_Categories
                                       .FirstOrDefaultAsync(x => x.UserId == req.UserId
                                       && x.IssueCategoriesId == req.IssueCategoriesId);

            if (exists == null)
                validat.Add("relations", "Map Not found in database");

            return exists;
        }

        //private async Task<Rel_User_Categories> IsRelExists(UnMappingItem req, ValidateException validat)
        //{
        //    // กำหนด tolerance ±1 วินาที
        //    var tolerance = TimeSpan.FromSeconds(1);

        //    // normalize JSON/Request time เป็น UTC
        //    var reqCreateTimeUtc = DateTime.SpecifyKind(req.CreateTime, DateTimeKind.Utc);

        //    // query เฉพาะ UserId + IssueCategoriesId ก่อน
        //    var candidates = await _context.Rel_User_Categories
        //        .Where(x => x.UserId == req.UserId && x.IssueCategoriesId == req.IssueCategoriesId)
        //        .ToListAsync();

        //    // เทียบเวลาแบบง่าย ๆ ด้วย tolerance
        //    var exists = candidates.FirstOrDefault(x =>
        //    {
        //        var dbTimeUtc = DateTime.SpecifyKind(x.CreateTime, DateTimeKind.Utc);
        //        return Math.Abs((dbTimeUtc - reqCreateTimeUtc).TotalSeconds) < tolerance.TotalSeconds;
        //    });

        //    if (exists == null)
        //        validat.Add("relations", "Map not found in database");

        //    return exists;
        //}





        private async Task<Log_Rel_User_Categories> IsExists(UnMappingItem req, ValidateException validat)
        {
            var exists = await _context.Log_Rel_User_Categories
                                           .FirstOrDefaultAsync(x => x.UserId == req.UserId
                                           && x.IssueCategoriesId == req.IssueCategoriesId
                                          );

            if (exists == null)
                validat.Add("Categories", "Map Not found in database");

            return exists;
        }

        //futures

        private static Log_Rel_User_Categories NewLogData(MappingItem req, DateTime dateNow)
        {
            return new Log_Rel_User_Categories
            {
                UserId = req.UserId,
                IssueCategoriesId = req.IssueCategoriesId,
                ActionType = "Add Categories",
                ActionTime = dateNow,
                ActionBy = Constance.AdminId

            };
        }

        private static Rel_User_Categories NewRelData(MappingItem req, DateTime dateNow)
        {
            return new Rel_User_Categories
            {
                UserId = req.UserId,
                IssueCategoriesId = req.IssueCategoriesId,
                CreatedTime = dateNow,
            };
        }

        private async Task IsExists(MappingItem req, ValidateException validat)
        {
            var exists = await _context.Rel_User_Categories
                                .AnyAsync(x => x.UserId == req.UserId && x.IssueCategoriesId == req.IssueCategoriesId);

            if (exists)
                validat.Add("Categories", "This Categories is already mapped to the user.");
        }
    }
    }

