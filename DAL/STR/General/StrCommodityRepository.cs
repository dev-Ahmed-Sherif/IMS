using Entities.Models.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.General
{
    public class StrCommodityRepository
    {
        private AppDbContext _context;
        public StrCommodityRepository(AppDbContext context)
        {
            _context = context;
        }
        public string GetLastNo()
        {
            int maxNo = _context.StrCommodity
             .Select(item => item.Code).DefaultIfEmpty()
             .Max();
            if (maxNo == 0)
            {
                maxNo = 1;
            }
            else
            {
                // int intmaxNo = int.Parse(maxNo);
                maxNo = maxNo + 1;
                //maxNo = intmaxNo.ToString();
            }
            return maxNo.ToString();

            // string maxNo = _context.StrItem.Select(n => new StrItem { No = n.No }).MaxAsync(n => n.GroupId == GroupId);
            //var maxNo = from item in StrItem where( item=> item.GroupId == GroupId ) select item.No;

        }
        public string Add(StrCommodityVM commodity)
        {
          
                bool exists = _context.StrCommodity.Any(s => s.Name == commodity.Name);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _commodity = new StrCommodity()
                {
                    Name = commodity.Name,
                    Code = commodity.Code,
                    AccountId = commodity.AccountId,
                    CreatedByID = commodity.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrCommodity.Add(_commodity);
                _context.SaveChanges();
                return "Succeeded";
            
        }

        public string Update(StrCommodityVM commodity)
        {
          
                bool exists = _context.StrCommodity.Any(s => s.Name == commodity.Name && s.Id != commodity.Id);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _commodity = _context.StrCommodity.Single(n => n.Id == commodity.Id);
                
                    _commodity.Name = commodity.Name;
                    _commodity.Code = commodity.Code;
                    _commodity.AccountId = commodity.AccountId;
                    _commodity.UpdateByID = commodity.TransactionUserId;
                    _commodity.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
                
              
           
        }

        public string Delete(int commodityId)
        {
           
                var _commodity = _context.StrCommodity.Single(n => n.Id == commodityId);
            var ToDeleteCommodity = _context.StrAdd.Where(p => p.CommodityId == commodityId).ToList();

            _context.StrAdd.RemoveRange(ToDeleteCommodity);
            _context.SaveChanges();

            _context.StrCommodity.Remove(_commodity);
                    _context.SaveChanges();
                
                return "Succeeded";
           
        }

        public List<StrCommodityGetVM> GetAll() => _context.StrCommodity.Select(n => new StrCommodityGetVM { Id = n.Id, Name = n.Name, Code = n.Code, AccountId = n.AccountId, AccountName = n.Account.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();

        public StrCommodityGetVM GetById(int commodityId) => _context.StrCommodity.Select(n => new StrCommodityGetVM { Id = n.Id, Name = n.Name, Code = n.Code, AccountId = n.AccountId, AccountName = n.Account.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == commodityId);


        public CommodityWithGradesVM GetWithGrades(int commodityId)
        {
            var _commodityWithGrades = _context.StrCommodity.Where(n => n.Id == commodityId).Select(STR_Commodity => new CommodityWithGradesVM()
            {
                Name = STR_Commodity.Name,
                Code = STR_Commodity.Code,
                AccountId = STR_Commodity.AccountId,
                Commodity_Grade = _context.StrGrade.Select(n => new StrGradeVM()
                {
                    Code = n.Code,
                    Name = n.Name,
                    AccountId = n.AccountId,
                    CommodityId = n.CommodityId
                }).ToList()
            }).FirstOrDefault();
            return _commodityWithGrades;
        }
    }
}
