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

        //    [ {
        //        task : "ยืม",
        //        type : "borrow"},
        //`       {
        //        task : "ซ่อม",
        //        type : "repair"},
        //        {
        //        task: "โปรแกรม",
        //        type: "software"},
        //]

        private readonly MYGAMEContext _context;

       

        public InsertFormService(MYGAMEContext context)
        {
            _context = context;
        }

        //public async Task<bool> InsertFormAsync(InsertFormViewModel model)
        //{
        //    using var transaction = await _context.Database.BeginTransactionAsync();

        //    try
        //    {
        //        // 1. Insert Form
        //        Form form = new Form
        //        {
        //            UserId = model.UserId
        //        };

        //        _context.Forms.Add(form);
        //        await _context.SaveChangesAsync();

        //        // 2. Insert FormTasks
        //        var tasks = model.FormTask.Select(t => new FormTask
        //        {
        //            TaskName = t.TaskName,
        //            TaskType = t.TaskType,
        //            FormId = form.Id
        //        }).ToList();

        //        _context.FormTasks.AddRange(tasks);
        //        await _context.SaveChangesAsync();

        //        // 3. Commit transaction
        //        await transaction.CommitAsync();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        // Log exception if needed
        //        return false;
        //    }
        //}




    }
}
