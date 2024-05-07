using Entities.Models.STR.Add;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.Add
{
    public class StrWithDrawTypeRepository
    {
        private AppDbContext _context;
        public StrWithDrawTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrWithDrawTypeGeneralVM receipt)
        {
           
                var _receipt = new StrWithDrawType()
                {
                    Name = receipt.Name,
                    Destination = receipt.Destination,
                    AccountId = receipt.AccountId,
                    CreatedByID = receipt.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrWithDrawType.Add(_receipt);
                _context.SaveChanges();
                return "Succeeded";
          
        }
        public string Update(StrWithDrawTypeVM receipt)
        {
            
                var _receipt = _context.StrWithDrawType.Single(n => n.Id == receipt.Id);
                
                    _receipt.Name = receipt.Name;
                    _receipt.Destination = receipt.Destination;
                    _receipt.AccountId = receipt.AccountId;

                    _receipt.UpdateByID = receipt.TransactionUserId;
                    _receipt.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
               
            
        }
        public string Delete(int receiptId)
        {
            
                var _receipt = _context.StrWithDrawType.Single(n => n.Id == receiptId);
               
                    _context.StrWithDrawType.Remove(_receipt);
                    _context.SaveChanges();
                    return "Succeeded";
               
           
        }
        public List<StrWithDrawTypeGetVM> GetAll()
            => _context.StrWithDrawType.Select(
                n => new StrWithDrawTypeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Destination = n.Destination,
                    AccountId = n.AccountId,
                    AccountName = n.Account.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        public StrWithDrawTypeGetVM GetById(int receiptId)
            => _context.StrWithDrawType.Select(
                n => new StrWithDrawTypeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Destination = n.Destination,
                    AccountId = n.AccountId,
                    AccountName = n.Account.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == receiptId);
    }
}
