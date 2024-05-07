using Entities.Models.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DAL.STR.General
{
    public class StrApprovalStatusRepository
    {

        private AppDbContext _context;
        public StrApprovalStatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(StrApprovalStatusVM ApprovalStatus)
        {
           
                var _ApprovalStatus = new StrApprovalStatus()
                {
                    Name = ApprovalStatus.name,
                    CreatedByID = ApprovalStatus.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrApprovalStatus.Add(_ApprovalStatus);
                _context.SaveChanges();
                return "Succeeded";
           
        }
        public string Update(StrApprovalStatusVM ApprovalStatus)
        {
            
                var _ApprovalStatus = _context.StrApprovalStatus.Single(n => n.Id == ApprovalStatus.Id);
               
                    _ApprovalStatus.Name = ApprovalStatus.name;

                    _ApprovalStatus.UpdateByID = ApprovalStatus.TransactionUserId;
                    _ApprovalStatus.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
               
          
        }

        public string Delete(int ApprovalStatusId)
        {
           
                var _ApprovalStatus = _context.StrApprovalStatus.Single(n => n.Id == ApprovalStatusId);
              
                    _context.StrApprovalStatus.Remove(_ApprovalStatus);
                    _context.SaveChanges();
                    return "Succeeded";
               
           
        }


        public List<StrApprovalStatusGetVM> GetAll() => _context.StrApprovalStatus.Select(n => new StrApprovalStatusGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public StrApprovalStatusGetVM GetById(int ApprovalStatusId) => _context.StrApprovalStatus.Select(n => new StrApprovalStatusGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == ApprovalStatusId);

    }
}
