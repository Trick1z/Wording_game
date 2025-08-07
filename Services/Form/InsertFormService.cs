using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Infrastructure.Data;
//using Domain.Entities; // Your EF models


namespace Services.Form
{
    public class InsertFormService : IInsertFormService
    {
        private readonly MYGAMEContext _context;

        public InsertFormService(MYGAMEContext context)
        {
            _context = context;
        }

        public async Task<int> CreateFormAsync(InsertFormViewModel request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var dateNow = DateTime.Now;

            try
            {
                var form = new Domain.Models.Form
                {
                    MemberId = request.UserId,
                    Description = request.Description,
                    Status = "Pending",
                    CreatedTime = dateNow
                };
                AddFormData(form);
                await OnSaveChange();

                foreach (var item in request.FormTask)
                {
                    var assignedUserId = await GetUserByType(item.Category);

                    var task = new FormTask
                    {
                        TaskName = item.TaskName,
                        FormId = form.FormId,
                        Category = item.Category,
                        AssignmentId = assignedUserId,
                        Status = "Pending"
                    };

                    _context.FormTask.Add(task);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return form.FormId;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private async Task OnSaveChange()
        {
            await _context.SaveChangesAsync();
        }

        private void AddFormData(Domain.Models.Form form)
        {
            _context.Form.Add(form);
        }

        private async Task<int> GetUserByType(string category)
        {
            var role = category;

            var user = await _context.User
                .Where(u => u.Role == role)
                .FirstOrDefaultAsync();

            if (user == null)
                throw new Exception($"ไม่พบผู้ดูแลประเภทงาน: {category}");

            return user.Id;
        }



    }
}
