using Entities.Models.TR.General;
using Entities.ViewModels.TR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.General
{
    public class TrPurposeRepository
    {
        private AppDbContext _context;
        public TrPurposeRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(TrPurposeGeneralVM TR_Course)
        {
         
                var _Tr_Course = new TrPurpose()
                {
                    Name = TR_Course.Name,

                    IsActive = TR_Course.IsActive,

                    CreatedByID = TR_Course.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrPurpose.Add(_Tr_Course);
                _context.SaveChanges();
                return _Tr_Course.Id.ToString();
        
        }
        public string Update(TrPurposeVM TR_Course)
        {
           
                var _TR_Course = _context.TrPurpose.Single(n => n.Id == TR_Course.Id);
         
                    _TR_Course.Name = TR_Course.Name;

                    _TR_Course.IsActive = TR_Course.IsActive;

                    _TR_Course.UpdateByID = TR_Course.TransactionUserId;
                    _TR_Course.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
           
        }
        public string Delete(int TR_Course_Id)
        {
           
                var _TR_Course = _context.TrPurpose.Single(n => n.Id == TR_Course_Id);
               
                    var DetailsToDelete = _context.TrExcuted.Where(n => n.PurposeId == TR_Course_Id || n.MaterialPurposeId == TR_Course_Id).ToList();
                    if (DetailsToDelete != null)
                    {
                        _context.TrExcuted.RemoveRange(DetailsToDelete);
                        _context.SaveChanges();
                    }
                    var DetailsToDelete1 = _context.TrPlan.Where(n => n.PurposeId == TR_Course_Id).ToList();
                    if (DetailsToDelete != null)
                    {
                        _context.TrPlan.RemoveRange(DetailsToDelete1);
                        _context.SaveChanges();
                    }

                    _context.TrPurpose.Remove(_TR_Course);
                    _context.SaveChanges();
                    return "Succeeded";
                
            
        }
        public List<TrPurposeGetVM> GetAll()
          => _context.TrPurpose.Select(
              n => new TrPurposeGetVM
              {
                  Id = n.Id,
                  Name = n.Name,


                  IsActive = n.IsActive,

                  CreateUserName = n.CreatedBy.Name,
                  TransactionUserId = n.CreatedBy.Id,

              }).ToList();
        public TrPurposeGetVM GetById(int TRCourseId)
            => _context.TrPurpose.Select(
                n => new TrPurposeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,

                    IsActive = n.IsActive,

                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == TRCourseId);
    }
}
