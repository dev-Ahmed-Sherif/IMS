using Entities.Models.TR.General;
using Entities.ViewModels.TR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.General
{
    public class TrFinancierRepository
    {
        private AppDbContext _context;
        public TrFinancierRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(TrFinancierGeneralVM TR_Course)
        {
      
                var _Tr_Course = new TrFinancier()
                {
                    Name = TR_Course.Name,
                    IsActive = TR_Course.IsActive,
                    CreatedByID = TR_Course.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.TrFinancier.Add(_Tr_Course);
                _context.SaveChanges();
                return _Tr_Course.Id.ToString();
          
        }
        public string Update(TrFinancierVM TR_Course)
        {
           
                var _TR_Course = _context.TrFinancier.Single(n => n.Id == TR_Course.Id);
               
                    _TR_Course.Name = TR_Course.Name;

                    _TR_Course.IsActive = TR_Course.IsActive;

                    _TR_Course.UpdateByID = TR_Course.TransactionUserId;
                    _TR_Course.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        public string Delete(int TR_Course_Id)
        {
          
                var _TR_Course = _context.TrFinancier.Single(n => n.Id == TR_Course_Id);
               


                    _context.TrFinancier.Remove(_TR_Course);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        public List<TrFinancierGetVM> GetAll()
          => _context.TrFinancier.Select(
              n => new TrFinancierGetVM
              {
                  Id = n.Id,
                  Name = n.Name,


                  IsActive = n.IsActive,

                  CreateUserName = n.CreatedBy.Name,
                  TransactionUserId = n.CreatedBy.Id,

              }).ToList();
        public TrFinancierGetVM GetById(int TRCourseId)
            => _context.TrFinancier.Select(
                n => new TrFinancierGetVM
                {
                    Id = n.Id,
                    Name = n.Name,

                    IsActive = n.IsActive,

                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == TRCourseId);
    }
}
