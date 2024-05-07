using Entities.Models.TR.Excuted;
using Entities.ViewModels.TR.Excuted;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Excuted
{
    public class TrExcutedInstructorRepository
    {
        private AppDbContext _context;

        public TrExcutedInstructorRepository(AppDbContext context)
        {
            _context = context;
        }

        //add function
        public string Add(TrExcutedInstructorGeneralVM ExcIns)
        {
           
                var _ExcIns = new TrExcutedInstructor()
                {
                    ExcutedId = ExcIns.ExcutedId,
                    InstructorId = ExcIns.InstructorId,

                    CreatedByID = ExcIns.TransactionUserId,
                    CreationDate = DateTime.Now



                };
                _context.TrExcutedInstructor.Add(_ExcIns);
                _context.SaveChanges();
                return _ExcIns.Id.ToString();
          
        }
        //update
        public string Update(TrExcutedInstructorVM ExcIns)
        {
            
                var _item = _context.TrExcutedInstructor.Single(n => n.Id == ExcIns.Id);
               


                    _item.ExcutedId = ExcIns.ExcutedId;
                    _item.InstructorId = ExcIns.InstructorId;
                    _item.UpdateByID = ExcIns.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //delet
        public string Delete(int ExcInsId)
        {
            
                var _receipt = _context.TrExcutedInstructor.Single(n => n.Id == ExcInsId);
              
                    _context.TrExcutedInstructor.Remove(_receipt);
                    _context.SaveChanges();
                    return "Succeeded";
             

        }
        //getall&getbyid
        public List<TrExcutedInstructorGetVM> GetAll()
            => _context.TrExcutedInstructor.Select(n => new TrExcutedInstructorGetVM
            {
                Id = n.Id,
                ExcutedId = n.ExcutedId,
                InstructorId = n.InstructorId,
                InstructorName = n.Instructor.Employee.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();

        public List<TrExcutedInstructorGetVM> GetByHeaderId(int Id)
            => _context.TrExcutedInstructor
            .Where(n => n.ExcutedId == Id)
            .Select(n => new TrExcutedInstructorGetVM
            {
                HeaderHeaderDays = n.Excuted.Days,
                HeaderStartDate = n.Excuted.StartDate,
                HeaderEndDate = n.Excuted.EndDate,
                HeaderNoTrainee = n.Excuted.NoTrainee,
                HeaderNoTraineeCorporate = n.Excuted.NoTraineeCorporate,
                HeaderNoTraineeTotal = n.Excuted.NoTraineeTotal,
                HeaderStatus = n.Excuted.Status,
                HeaderCostplaned = n.Excuted.Costplaned,
                HeaderCost = n.Excuted.Cost,
                HeaderTrainingCenterName = n.Excuted.TrainingCenter.Name,
                HeaderClassRoomName = n.Excuted.ClassRoom.Name,
                HeaderFiscalYearName = n.Excuted.FiscalYear.fiscalyear,
                HeaderCourseName = n.Excuted.Course.Name,
                HeaderPurposeName = n.Excuted.Purpose.Name,
                HeaderMaterialPurposeName = n.Excuted.Purpose.Name,
                HeaderDelegateName = n.Excuted.Delegate.Name,
                InstructorName = n.Instructor.Employee.Name,
                //details
                Id = n.Id,
                ExcutedId = n.ExcutedId,
                InstructorId = n.InstructorId,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<TrExcutedInstructorGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrExcutedInstructor.Count();
            List<TrExcutedInstructorGetVM> Item = _context.TrExcutedInstructor
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrExcutedInstructorGetVM
                {
                    Id = n.Id,
                    ExcutedId = n.ExcutedId,
                    InstructorId = n.InstructorId,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrExcutedInstructorGetVM>
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
        public TrExcutedInstructorGetVM GetById(int itemId) => _context.TrExcutedInstructor.Select(n => new TrExcutedInstructorGetVM { Id = n.Id, ExcutedId = n.ExcutedId, InstructorId = n.InstructorId, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);
    }
}