using Entities.Models.TR.Plan;
using Entities.ViewModels.TR.Plan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Plan
{
    public class TrPlanCourseDataRepository
    {
        private AppDbContext _context;
        public TrPlanCourseDataRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(TrPlanCourseDataGeneralVM TR_Plancoursedata)
        {
           
                var _Plancoursedata = new TrPlanCourseData()
                {
                    Version = TR_Plancoursedata.Version,
                    CourseId = TR_Plancoursedata.CourseId,
                    Code = TR_Plancoursedata.Code,
                    PositionId = TR_Plancoursedata.PositionId,
                    FinancialDegreeId = TR_Plancoursedata.FinancialDegreeId,
                    IsMinimum = TR_Plancoursedata.IsMinimum,

                    CreatedByID = TR_Plancoursedata.TransactionUserId,

                    CreationDate = DateTime.Now

                };
                _context.TrPlanCourseData.Add(_Plancoursedata);
                _context.SaveChanges();
                return _Plancoursedata.Id.ToString();
            
        }

        public string Update(TrPlanCourseDataVM TR_Plancoursedata)
        {
            
                var _TR_Plancoursedata = _context.TrPlanCourseData.FirstOrDefault(n => n.Id == TR_Plancoursedata.Id);
               
                    _TR_Plancoursedata.Version = TR_Plancoursedata.Version;
                    _TR_Plancoursedata.CourseId = TR_Plancoursedata.CourseId;
                    _TR_Plancoursedata.Code = TR_Plancoursedata.Code;
                    _TR_Plancoursedata.PositionId = TR_Plancoursedata.PositionId;
                    _TR_Plancoursedata.FinancialDegreeId = TR_Plancoursedata.FinancialDegreeId;
                    _TR_Plancoursedata.IsMinimum = TR_Plancoursedata.IsMinimum;
                    _TR_Plancoursedata.UpdateByID = TR_Plancoursedata.TransactionUserId;
                    _TR_Plancoursedata.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        public string Delete(int TR_Plancoursedata_Id)
        {
           
                var _TR_Course = _context.TrPlanCourseData.Single(n => n.Id == TR_Plancoursedata_Id);
               
                    _context.TrPlanCourseData.Remove(_TR_Course);
                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        public List<TrPlanCourseDataGetVM> GetAll()
          => _context.TrPlanCourseData.Select(
              n => new TrPlanCourseDataGetVM
              {
                  Version = n.Version,
                  CourseId = n.CourseId,
                  Code = n.Code,
                  PositionId = n.PositionId,
                  FinancialDegreeId = n.FinancialDegreeId,
                  IsMinimum = n.IsMinimum,
                  CreateUserName = n.CreatedBy.Name,
                  TransactionUserId = n.CreatedBy.Id,

              }).ToList();

        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<TrPlanCourseDataGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrPlanCourseData.Count();
            List<TrPlanCourseDataGetVM> Item = _context.TrPlanCourseData
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrPlanCourseDataGetVM
                {
                    Version = n.Version,
                    CourseId = n.CourseId,
                    Code = n.Code,
                    PositionId = n.PositionId,
                    FinancialDegreeId = n.FinancialDegreeId,
                    IsMinimum = n.IsMinimum,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id,
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrPlanCourseDataGetVM>
            {
                Items = Item,
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };

            return paginatedResult;
        }
        public class PaginatedResult<T>
        {
            public List<T> Items { get; set; }
            public int TotalItems { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
        }
        public TrPlanCourseDataGetVM GetById(int TrPlancoursedataId)
            => _context.TrPlanCourseData.Select(
                n => new TrPlanCourseDataGetVM
                {
                    Version = n.Version,
                    CourseId = n.CourseId,
                    Code = n.Code,
                    PositionId = n.PositionId,
                    FinancialDegreeId = n.FinancialDegreeId,
                    IsMinimum = n.IsMinimum,

                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == TrPlancoursedataId);

    }
}
