using Entities.Models.TR.Plan;
using Entities.ViewModels.TR.Excuted;
using Entities.ViewModels.TR.Plan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Plan
{
    public class TrPlanPositionRepository
    {
        private AppDbContext _context;
        public TrPlanPositionRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(TrPlanPositionGeneralVM Inst)
        {
            
                var _Inst = new TrPlanPosition()
                {

                    PlanId = Inst.PlanId,
                    PositionId = Inst.PositionId,
                    CreatedByID = Inst.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrPlanPosition.Add(_Inst);
                _context.SaveChanges();
                return _Inst.Id.ToString();

            
          
        }
        public string Update(TrPlanPositionVM Inst)
        {
             var _item = _context.TrPlanPosition.Single(n => n.Id == Inst.Id);
           


                    _item.PlanId = Inst.PlanId;
                    _item.PositionId = Inst.PositionId;


                    _item.UpdateByID = Inst.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";

        }
        public string Delete(int InstId)
        {
          
                var _receipt = _context.TrPlanPosition.Single(n => n.Id == InstId);
               


                    _context.TrPlanPosition.Remove(_receipt);
                    _context.SaveChanges();
                    return "Succeeded";
         

        }
        public List<TrPlanPositionGetVM> GetAll()
            => _context.TrPlanPosition.Select(n => new TrPlanPositionGetVM
            {
                Id = n.Id,
                PlanId = n.PlanId,
                PlanTittle = n.Plan.Tittle,
                PositionId = n.PositionId,
                PositionName = n.Position.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        public TrPlanPositionGetVM GetById(int itemId) => _context.TrPlanPosition.Select(n => new TrPlanPositionGetVM
        {
            Id = n.Id,
            PlanId = n.PlanId,
            PlanTittle = n.Plan.Tittle,
            PositionId = n.PositionId,
            PositionName = n.Position.Name,
            CreateUserName = n.CreatedBy.Name,
            TransactionUserId = n.CreatedBy.Id
        }).Single(n => n.Id == itemId);
        public List<TrPlanPositionGetVM> GetByHeaderId(int Id)
            => _context.TrPlanPosition
            .Where(n => n.PlanId == Id)
            .Select(
                n => new TrPlanPositionGetVM
                {
                    HeaderTittle = n.Plan.Tittle,
                    HeaderDays = n.Plan.Days,
                    HeaderStartDate = n.Plan.StartDate,
                    HeaderEndDate = n.Plan.EndDate,
                    HeaderNoTrainee = n.Plan.NoTrainee,
                    HeaderTrainingCenterName = n.Plan.TrainingCenter.Name,
                    HeaderClassRoomName = n.Plan.ClassRoom.Name,
                    HeaderFiscalYearName = n.Plan.FiscalYear.fiscalyear,
                    HeaderCourseName = n.Plan.Course.Name,
                    HeaderPurposeName = n.Plan.Purpose.Name,
                    HeaderFinanacielDegreeName = n.Plan.FinanacielDegree.Name,
                    //details
                    Id = n.Id,
                    PlanId = n.PlanId,
                    PlanTittle = n.Plan.Tittle,
                    PositionId = n.PositionId,
                    PositionName = n.Position.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();

        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        //public PaginatedResult<TrPlanPositionGetVM> GetAllByPagination(int page, int pageSize)
        //{
        //    var totalCount = _context.TrPlanPosition.Count();
        //    List<TrPlanPositionGetVM> Item = _context.TrPlanPosition
        //        .OrderByDescending(Item => Item.CreationDate)
        //        .Skip((page) * pageSize)
        //        .Take(pageSize)
        //        .Select(n => new TrPlanPositionGetVM
        //        {
        //            Id = n.Id,
        //            PlanId = n.PlanId,
        //            PlanTittle = n.Plan.Tittle,
        //            PositionId = n.PositionId,
        //            CreateUserName = n.CreatedBy.Name,
        //            TransactionUserId = n.CreatedBy.Id
        //        })
        //        .ToList();

        //    var paginatedResult = new PaginatedResult<TrPlanPositionGetVM>
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
        public PaginatedResult<TrPlanPositionGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.TrPlanPosition.Where(n => n.PlanId == HeaderId).Count();

            if (totalCount == 0)
            {
                return new PaginatedResult<TrPlanPositionGetVM>
                {
                    Items = new List<TrPlanPositionGetVM>(),
                    TotalItems = 0,
                    Page = page,
                    PageSize = pageSize
                };
            }
            List<int> TrPlan = _context.TrPlanPosition
                   .Where(sus => sus.PlanId == HeaderId)
                   .Select(sus => sus.PlanId)
                   .ToList();
            List<TrPlanPositionGetVM> Item = _context.TrPlanPosition
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrPlanPositionGetVM
                {
                    Id = n.Id,
                    PlanId = n.PlanId,
                    PlanTittle=n.Plan.Tittle,
                    PositionId = n.PositionId,
                    PositionName= n.Position.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrPlanPositionGetVM>
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

