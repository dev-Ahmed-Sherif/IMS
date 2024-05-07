using Entities.Models.STR.Add;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.Add
{
    public class AddTypeRepository
    {
        private AppDbContext _context;
        public AddTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(StrAddTypeGeneralVM types)
        {
           
                var _type = new StrAddType()
                {
                    Name = types.Name,
                    Source = types.Source,
                    AccountId = types.AccountId,
                    CreatedByID = types.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrAddType.Add(_type);
                _context.SaveChanges();
                return "Succeeded";
            
           
        }

        public string Update(StrAddTypeVM type)
        {

            var _type = _context.StrAddType.Single(n => n.Id == type.Id);

            _type.Name = type.Name;
            _type.Source = type.Source;
            _type.AccountId = type.AccountId;

            _type.UpdateByID = type.TransactionUserId;
            _type.LastUpdateDate = DateTime.Now;

            _context.SaveChanges();
            return "Succeeded";


        }

        public string Delete(int typeId)
        {

            var _type = _context.StrAddType.Single(n => n.Id == typeId);

            _context.StrAddType.Remove(_type);
            _context.SaveChanges();
            return "Succeeded";

        }

        public List<StrAddTypeGetVM> GetAll()
            => _context.StrAddType.Select(
                n => new StrAddTypeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Source = n.Source,
                    AccountId = n.AccountId,
                    AccountName = n.Account.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();

        public StrAddTypeGetVM GetById(int typeId)
            => _context.StrAddType.Select(
                n => new StrAddTypeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Source = n.Source,
                    AccountId = n.AccountId,
                    AccountName = n.Account.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == typeId);
    }
}
