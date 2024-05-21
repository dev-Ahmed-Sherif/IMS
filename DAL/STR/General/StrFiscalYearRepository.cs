using Entities.ExtensionMethods.STR.General;
using Entities.Models.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.General
{
    public class StrFiscalYearRepository
    {
        private AppDbContext _context;
        public StrFiscalYearRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrFiscalYearGeneralVM year)
        {
            
                var _year = new StrFiscalYear()
                {
                    fiscalyear = year.fiscalyear,
                    StartDate = year.StartDate,
                    EndDate = year.EndDate,
                    CreatedByID = year.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.FiscalYear.Add(_year);
                _context.SaveChanges();
                return _year.Id.ToString();

           
        }
        public string Update(StrFiscalYearVM year)
        {
          
                var _year = _context.FiscalYear.Single(n => n.Id == year.Id);
              
                    _year.fiscalyear = year.fiscalyear;
                    _year.StartDate = year.StartDate;
                    _year.EndDate = year.EndDate;
                    _year.UpdateByID = year.TransactionUserId;
                    _year.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
                
         
        }
        public string Delete(int yearId)
        {
           
                var _year = _context.FiscalYear.Single(n => n.Id == yearId);
               
                    _context.FiscalYear.Remove(_year);
                    _context.SaveChanges();
                    return "Succeeded";
               
           
        }
        public List<FiscalYearGetVM> GetAll() => _context.FiscalYear.Select(n => new FiscalYearGetVM { Id = n.Id, fiscalyear = n.fiscalyear, StartDate = n.StartDate, EndDate = n.EndDate, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public FiscalYearGetVM GetById(int yearId) => _context.FiscalYear.Select(n => new FiscalYearGetVM { Id = n.Id, fiscalyear = n.fiscalyear, StartDate = n.StartDate, EndDate = n.EndDate, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == yearId);
        //public string GetLastFiscalYear()
        //{
        //    var lastFiscalYear = _context.FiscalYear
        //        .OrderByDescending(fy => fy.Id)
        //        .Select(fy => fy.fiscalyear)
        //        .FirstOrDefault();

        //    return lastFiscalYear;
        //}
        public FiscalYearData GetLast()
        {
            var lastFiscalYears =
                _context
                .FiscalYear
                .OrderBy(fy=>fy.Id)
                .Where(fy=>fy.IsDeleted == false)
                .Last();

            return lastFiscalYears.ToFiscalYearData();
        }
    }
}
