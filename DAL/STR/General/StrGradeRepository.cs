using Entities.Models.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.General
{
    public class StrGradeRepository
    {
        private AppDbContext _context;
        public StrGradeRepository(AppDbContext context)
        {
            _context = context;
        }
        public string GetLastNo(int commidtyId)
        {


            try
            {
                int maxNo = _context.StrGrade.Where(item => item.CommodityId == commidtyId).Select(item => item.Code).DefaultIfEmpty().Max();
                if (maxNo == 0)
                {
                    maxNo = 1;
                }
                else
                {
                    maxNo = maxNo + 1;
                }

                return maxNo.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Add(StrGradeVM grade)
        {
           
                bool exists = _context.StrGrade.Any(s => s.Name == grade.Name);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _grade = new StrGrade()
                {
                    Name = grade.Name,
                    Code = grade.Code,
                    AccountId = grade.AccountId,
                    CommodityId = grade.CommodityId,
                    CreatedByID = grade.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrGrade.Add(_grade);
                _context.SaveChanges();
                return "Succeeded";
            
          
        }

        public string Update(StrGradeVM grade)
        {
            
                bool exists = _context.StrGrade.Any(s => s.Name == grade.Name && s.Id != grade.Id);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _grade = _context.StrGrade.Single(n => n.Id == grade.Id);
               
                    _grade.Name = grade.Name;
                    _grade.Code = grade.Code;
                    _grade.CommodityId = grade.CommodityId;
                    _grade.AccountId = grade.AccountId;
                    _grade.UpdateByID = grade.TransactionUserId;

                    _grade.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
              
           
        }

        public string Delete(int gradeId)
        {
          
          
                var _grade = _context.StrGrade.Single(n => n.Id == gradeId);
               
                    _context.StrGrade.Remove(_grade);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }

        public List<StrGradeGetVM> GetAll() => _context.StrGrade.Select(n => new StrGradeGetVM { Id = n.Id, Name = n.Name, CommodityId = n.CommodityId, CommodityName = n.STR_Commodity.Name, AccountId = n.AccountId, AccountName = n.Account.Name, CreateUserName = n.CreatedBy.Name, Code = n.Code, TransactionUserId = n.CreatedBy.Id }).ToList();
        public StrGradeGetVM GetById(int gradeId) => _context.StrGrade.Select(n => new StrGradeGetVM { Id = n.Id, Name = n.Name, CommodityId = n.CommodityId, Code = n.Code, CommodityName = n.STR_Commodity.Name, AccountId = n.AccountId, AccountName = n.Account.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == gradeId);
        public GradeWithPlatoonsVM GetWithPlatoons(int gradeId)
        {
            var _gradeWithPlatoons = _context.StrGrade.Where(n => n.Id == gradeId).Select(STR_Grade => new GradeWithPlatoonsVM()
            {
                Name = STR_Grade.Name,
                Code = STR_Grade.Code,
                AccountId = STR_Grade.AccountId,


                Grade_Platoon = _context.StrPlatoon.Select(n => new StrPlatoonVM()
                {
                    Code = n.Code,
                    Name = n.Name,
                    GradeId = n.GradeId,



                }).ToList()

            }).Single();
            return _gradeWithPlatoons;
        }
    }
}
