using Entities.Models.TR.Plan;
using Entities.ViewModels.TR.Plan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Plan
{
    public class TrPlanFinancierRepository
    {
        private AppDbContext _context;
        public TrPlanFinancierRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(TrPlanFinancierGeneralVM TR_PlanFinanc)
        {
           
                var _PlanFinanc = new TrPlanFinancier()
                {
                    PlanId = TR_PlanFinanc.PlanId,
                    FinancierId = TR_PlanFinanc.FinancierId,
                    CreatedByID = TR_PlanFinanc.TransactionUserId,

                    CreationDate = DateTime.Now

                };
                _context.TrPlanFinancier.Add(_PlanFinanc);
                _context.SaveChanges();
                return _PlanFinanc.Id.ToString();
            
           
        }
        public string Update(TrPlanFinancierVM TR_PlanFinanc)
        {
           
                var _TR_PlanFinanc = _context.TrPlanFinancier.Single(n => n.Id == TR_PlanFinanc.Id);
               
                    _TR_PlanFinanc.PlanId = TR_PlanFinanc.PlanId;
                    _TR_PlanFinanc.FinancierId = TR_PlanFinanc.FinancierId;

                    _TR_PlanFinanc.UpdateByID = TR_PlanFinanc.TransactionUserId;
                    _TR_PlanFinanc.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
               
        }
        public string Delete(int TR_PlanFinanc_Id)
        {

            var _TR_Course = _context.TrPlanFinancier.Single(n => n.Id == TR_PlanFinanc_Id);

            _context.TrPlanFinancier.Remove(_TR_Course);
            _context.SaveChanges();
            return "Succeeded";
        }
        public List<TrPlanFinancierGetVM> GetAll()
          => _context.TrPlanFinancier.Select(
              n => new TrPlanFinancierGetVM
              {
                  PlanId = n.PlanId,
                  FinancierId = n.FinancierId,

                  CreateUserName = n.CreatedBy.Name,
                  TransactionUserId = n.CreatedBy.Id,

              }).ToList();
        public TrPlanFinancierGetVM GetById(int TrPlanFinancierId)
            => _context.TrPlanFinancier.Select(
                n => new TrPlanFinancierGetVM
                {
                    PlanId = n.PlanId,
                    FinancierId = n.FinancierId,

                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).FirstOrDefault(n => n.Id == TrPlanFinancierId);
        public List<TrPlanFinancierGetVM> GetByHeaderId(int Id)
            => _context.TrPlanFinancier
            .Where(n => n.PlanId == Id)
            .Select(
                n => new TrPlanFinancierGetVM
                {
                    HeaderTittle = n.Plan.Tittle,
                    HeaderDays = n.Plan.Days,
                    HeaderStartDate = n.Plan.StartDate,
                    HeaderEndDate = n.Plan.EndDate,
                    HeaderNoTrainee = n.Plan.NoTrainee,
                    HeaderTrainingCenterName = n.Plan.TrainingCenter.Name,
                    HeaderClassRoomName = n.Plan.ClassRoom.Name,
                    HeaderFiscalYearName = n.Plan.FiscalYear.fiscalyear,
                    FinancierName = n.Financier.Name,
                    HeaderCourseName = n.Plan.Course.Name,
                    HeaderPurposeName = n.Plan.Purpose.Name,
                    HeaderFinanacielDegreeName = n.Plan.FinanacielDegree.Name,
                    //details
                    Id = n.Id,
                    PlanId = n.PlanId,
                    FinancierId = n.FinancierId,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id,
                }).ToList();

        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        //public PaginatedResult<TrPlanFinancierGetVM> GetAllByPagination(int page, int pageSize)
        //{
        //    var totalCount = _context.TrPlanFinancier.Count();
        //    List<TrPlanFinancierGetVM> Item = _context.TrPlanFinancier
        //        .OrderByDescending(Item => Item.CreationDate)
        //        .Skip((page) * pageSize)
        //        .Take(pageSize)
        //        .Select(n => new TrPlanFinancierGetVM
        //        {
        //            PlanId = n.PlanId,
        //            FinancierId = n.FinancierId,
        //            CreateUserName = n.CreatedBy.Name,
        //            TransactionUserId = n.CreatedBy.Id,
        //        })
        //        .ToList();

        //    var paginatedResult = new PaginatedResult<TrPlanFinancierGetVM>
        //    {
        //        Items = Item,
        //        TotalItems = totalCount,
        //        Page = page,
        //        PageSize = pageSize
        //    };

        //    return paginatedResult;
        //}
        //public class PaginatedResult<T>
        //{
        //    public List<T> Items { get; set; }
        //    public int TotalItems { get; set; }
        //    public int Page { get; set; }
        //    public int PageSize { get; set; }
        //}
        public PaginatedResult<TrPlanFinancierGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.TrPlanFinancier.Where(n => n.PlanId == HeaderId).Count();

            if (totalCount == 0)
            {
                return new PaginatedResult<TrPlanFinancierGetVM>
                {
                    Items = new List<TrPlanFinancierGetVM>(),
                    TotalItems = 0,
                    Page = page,
                    PageSize = pageSize
                };
            }
            List<int?> TrPlan = _context.TrPlanFinancier
                   .Where(sus => sus.PlanId == HeaderId)
                   .Select(sus => sus.PlanId)
                   .ToList();
            List<TrPlanFinancierGetVM> Item = _context.TrPlanFinancier
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrPlanFinancierGetVM
                {
                    Id = n.Id,
                    PlanId = n.PlanId,
                    PlanName = n.Plan.Tittle,
                    FinancierId = n.FinancierId,
                    FinancierName=n.FinancierId!=null?n.Financier.Name:"",
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrPlanFinancierGetVM>
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

    }
}
