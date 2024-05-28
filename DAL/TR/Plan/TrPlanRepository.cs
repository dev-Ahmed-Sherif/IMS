using Entities.Models.TR.Excuted;
using Entities.Models.TR.Plan;
using Entities.ViewModels.TR.Plan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Plan
{
    public class TrPlanRepository
    {
        private AppDbContext _context;
        public TrPlanRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(TrPlanGeneralVM Inst)
        {
           
                var _Inst = new TrPlan()
                {

                    Tittle = Inst.Tittle,
                    Days = Inst.Days,
                    StartDate = Inst.StartDate,
                    EndDate = Inst.EndDate,
                    NoTrainee = Inst.NoTrainee,
                    TrainingCenterId = Inst.TrainingCenterId,
                    ClassRoomId = Inst.ClassRoomId,
                    FiscalYearId = Inst.FiscalYearId,
                    CourseId = Inst.CourseId,
                    PurposeId = Inst.PurposeId,
                    FinanacielDegreeId = Inst.FinanacielDegreeId,

                    CreatedByID = Inst.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrPlan.Add(_Inst);
                _context.SaveChanges();
                return _Inst.Id.ToString();
        
        }
        public string Update(TrPlanVM Inst)
        {
           
                var _item = _context.TrPlan.Single(n => n.Id == Inst.Id);
              



                    _item.TrainingCenterId = Inst.TrainingCenterId;
                    _item.Tittle = Inst.Tittle;
                    _item.Days = Inst.Days;
                    _item.StartDate = Inst.StartDate;
                    _item.EndDate = Inst.EndDate;
                    _item.NoTrainee = Inst.NoTrainee;

                    _item.ClassRoomId = Inst.ClassRoomId;
                    _item.FiscalYearId = Inst.FiscalYearId;
                    _item.CourseId = Inst.CourseId;
                    _item.PurposeId = Inst.PurposeId;
                    _item.FinanacielDegreeId = Inst.FinanacielDegreeId;




                    _item.UpdateByID = Inst.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
           
        }
        public string Delete(int InstId)
        {
            
                var _receipt = _context.TrPlan.Single(n => n.Id == InstId);

            var DetailsToDelete = _context.TrPlanFinancier.Where(p => p.PlanId == InstId).ToList();
            var DetailsToDelete2 = _context.TrPlanInstructor.Where(p => p.PlanId == InstId).ToList();
            var DetailsToDelete3 = _context.TrPlanPosition.Where(p => p.PlanId == InstId).ToList();
            
            _context.TrPlanFinancier.RemoveRange(DetailsToDelete);
            _context.SaveChanges();
            _context.TrPlanInstructor.RemoveRange(DetailsToDelete2);
            _context.SaveChanges();
            _context.TrPlanPosition.RemoveRange(DetailsToDelete3);
            _context.SaveChanges();
   

            _context.TrPlan.Remove(_receipt);
            _context.SaveChanges();
            return "Succeeded";


        }
        public List<TrPlanGetVM> GetAll()
            => _context.TrPlan.Select(n => new TrPlanGetVM
            {
                Id = n.Id,
                Tittle = n.Tittle,
                Days = n.Days,
                StartDate = n.StartDate,
                EndDate = n.EndDate,
                NoTrainee = n.NoTrainee,
                ClassRoomId = n.ClassRoomId,
                ClassRoomName = n.ClassRoom.Name,
                FiscalYearId = n.FiscalYearId,
                FiscalYearName = n.FiscalYear.fiscalyear,
                CourseId = n.CourseId,
                CourseName = n.Course.Name,
                PurposeId = n.PurposeId,
                PurposeName = n.Purpose.Name,
                TrainingCenterId = n.TrainingCenterId,
                TrainingCenterName = n.TrainingCenter.Name,
                FinanacielDegreeId = n.FinanacielDegreeId,
                FinanacielDegreeName = n.FinanacielDegree.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<TrPlanGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrPlan.Count();
            List<TrPlanGetVM> Item = _context.TrPlan
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrPlanGetVM
                {
                    Id = n.Id,
                    Tittle = n.Tittle,
                    Days = n.Days,
                    StartDate = n.StartDate,
                    EndDate = n.EndDate,
                    NoTrainee = n.NoTrainee,
                    ClassRoomId = n.ClassRoomId,
                    ClassRoomName = n.ClassRoom.Name,
                    FiscalYearId = n.FiscalYearId,
                    FiscalYearName = n.FiscalYear.fiscalyear,
                    CourseId = n.CourseId,
                    CourseName = n.Course.Name,
                    PurposeId = n.PurposeId,
                    PurposeName = n.Purpose.Name,
                    TrainingCenterId = n.TrainingCenterId,
                    TrainingCenterName = n.TrainingCenter.Name,
                    FinanacielDegreeId = n.FinanacielDegreeId,
                    FinanacielDegreeName = n.FinanacielDegree.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrPlanGetVM>
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
        public TrPlanGetVM GetById(int itemId) => _context.TrPlan.Select(n => new TrPlanGetVM { Id = n.Id, Tittle = n.Tittle, Days = n.Days, StartDate = n.StartDate, EndDate = n.EndDate, NoTrainee = n.NoTrainee, ClassRoomId = n.ClassRoomId, ClassRoomName = n.ClassRoom.Name, FiscalYearId = n.FiscalYearId, FiscalYearName = n.FiscalYear.fiscalyear, CourseId = n.CourseId, CourseName = n.Course.Name, PurposeId = n.PurposeId, PurposeName = n.Purpose.Name, TrainingCenterId = n.TrainingCenterId, TrainingCenterName = n.TrainingCenter.Name, FinanacielDegreeId = n.FinanacielDegreeId, FinanacielDegreeName = n.FinanacielDegree.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);
    }

}
