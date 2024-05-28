using Entities.Models.TR.Plan;
using Entities.ViewModels.TR.Plan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Plan
{
    public class TrPlanInstructorRepository
    {
        private AppDbContext _context;
        public TrPlanInstructorRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(TrPlanInstructorGeneralVM Inst)
        {
            
                var _Inst = new TrPlanInstructor()
                {

                    PlanId = Inst.PlanId,
                    InstructorId = Inst.InstructorId,
                    CreatedByID = Inst.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrPlanInstructor.Add(_Inst);
                _context.SaveChanges();
                return _Inst.Id.ToString();

          
        }
        public string Update(TrPlanInstructorVM Inst)
        {
             var _item = _context.TrPlanInstructor.Single(n => n.Id == Inst.Id);
             

                    _item.PlanId = Inst.PlanId;
                    _item.InstructorId = Inst.InstructorId;


                    _item.UpdateByID = Inst.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
          
        }
        public string Delete(int InstId)
        {
           
                var _receipt = _context.TrPlanInstructor.Single(n => n.Id == InstId);
              


                    _context.TrPlanInstructor.Remove(_receipt);
                    _context.SaveChanges();
                    return "Succeeded";
           

        }
        public List<TrPlanInstructorGetVM> GetAll()
            => _context.TrPlanInstructor
            .Select(n => new TrPlanInstructorGetVM
            {
                Id = n.Id,
                PlanId = n.PlanId,
                PlanName = n.Plan.Tittle,
                InstructorId = n.InstructorId,
                InstructorName = n.Instructor.EmployeeId == null ? n.Instructor.InstructorData.Name : n.Instructor.Employee.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        public TrPlanInstructorGetVM GetById(int itemId) => _context.TrPlanInstructor.Select(n => new TrPlanInstructorGetVM { Id = n.Id, PlanId = n.PlanId, PlanName = n.Plan.Tittle, InstructorId = n.InstructorId, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);
        /*==================================*/
        /*=======Get Instructor Data========*/
        /*==================================*/
        public List<TrInstrctorDataVM> GetInstructorDataById(int itemId)
        {
            var instructorId = _context.TrPlanInstructor
                .Where(n => n.PlanId == itemId)
                .Select(n => n.InstructorId)
                .Distinct()
                .ToList();

            var instructor = _context.TrInstructor
                .Select(n => new TrInstrctorDataVM
                {
                    HeaderId = n.EmployeeId == null ? n.InstructorDataId : n.EmployeeId,
                    HeaderName = n.EmployeeId == null ? n.InstructorData.Name : n.Employee.Name,
                    HeaderCode = n.EmployeeId == null ? n.InstructorData.Code.ToString() : n.Employee.Code,
                    HeaderPhone = n.EmployeeId == null ? n.InstructorData.phone : n.Employee.Phone,
                    HeaderEmail = n.EmployeeId == null ? n.InstructorData.Email : n.Employee.Email,
                    HeaderPosition = n.EmployeeId == null ? n.InstructorData.Position : n.Employee.Position.Name,
                    HeaderAddress = n.EmployeeId == null ? n.InstructorData.Address : n.Employee.Address,
                    HeaderGender = n.EmployeeId == null ? n.InstructorData.Gender : n.Employee.Gender,
                    HeaderCityName = n.EmployeeId == null ? n.InstructorData.City.Name : n.Employee.CityState.Name,
                    //Details
                    Id = n.Id,
                    PlanId = itemId,
                    Type = n.Type,
                    IsEmployee = n.EmployeeId == null ? false : true,
                    CreateUserName = n.CreatedBy.Name,
                })
                .Where(n => instructorId.Contains(n.Id))
                .ToList();

            return instructor;
        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        //public PaginatedResult<TrPlanInstructorGetVM> GetAllByPagination(int page, int pageSize)
        //{
        //    var totalCount = _context.TrPlanInstructor.Count();
        //    List<TrPlanInstructorGetVM> Item = _context.TrPlanInstructor
        //        .OrderByDescending(Item => Item.CreationDate)
        //        .Skip((page) * pageSize)
        //        .Take(pageSize)
        //        .Select(n => new TrPlanInstructorGetVM
        //        {
        //            Id = n.Id,
        //            PlanId = n.PlanId,
        //            PlanName = n.Plan.Tittle,
        //            InstructorId = n.InstructorId,
        //            CreateUserName = n.CreatedBy.Name,
        //            TransactionUserId = n.CreatedBy.Id
        //        })
        //        .ToList();

        //    var paginatedResult = new PaginatedResult<TrPlanInstructorGetVM>
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
        public PaginatedResult<TrPlanInstructorGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.TrPlanInstructor.Where(n => n.PlanId == HeaderId).Count();

            if (totalCount == 0)
            {
                return new PaginatedResult<TrPlanInstructorGetVM>
                {
                    Items = new List<TrPlanInstructorGetVM>(),
                    TotalItems = 0,
                    Page = page,
                    PageSize = pageSize
                };
            }
            List<int> TrPlan = _context.TrPlanInstructor
                   .Where(sus => sus.PlanId == HeaderId)
                   .Select(sus => sus.PlanId)
                   .ToList();
            List<TrPlanInstructorGetVM> Item = _context.TrPlanInstructor
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrPlanInstructorGetVM
                {
                    Id = n.Id,
                    PlanId = n.PlanId,
                    PlanName=n.Plan.Tittle,
                    InstructorId = n.InstructorId,
                    InstructorName = n.Instructor.EmployeeId == null ? n.Instructor.InstructorData.Name : n.Instructor.Employee.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrPlanInstructorGetVM>
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
