using Entities.Models.TR.Excuted;
using Entities.ViewModels.TR.Excuted;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Excuted
{
    public class TrExcutedTraineeRepository
    {

        private AppDbContext _context;

        public TrExcutedTraineeRepository(AppDbContext context)
        {
            _context = context;
        }
        //add function
        public string Add(TrExcutedTraineeGeneralVM Excpos)
        {
            
                var _Excpos = new TrExcutedTrainee()
                {
                    ExcutedId = Excpos.ExcutedId,
                    EmployeeId = Excpos.EmployeeId,
                    TraineeId = Excpos.TraineeId,

                    CreatedByID = Excpos.TransactionUserId,
                    CreationDate = DateTime.Now



                };
                _context.TrExcutedTrainee.Add(_Excpos);
                _context.SaveChanges();
                return _Excpos.Id.ToString();
         
        }
        //update
        public string Update(TrExcutedTraineeVM ExcIns)
        {
              var _item = _context.TrExcutedTrainee.Single(n => n.Id == ExcIns.Id);
               


                    _item.ExcutedId = ExcIns.ExcutedId;
                    _item.EmployeeId = ExcIns.EmployeeId;
                    _item.TraineeId = ExcIns.TraineeId;
                    _item.UpdateByID = ExcIns.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";

            
        }
        //delet
        public string Delete(int ExcInsId)
        {
           
                var _receipt = _context.TrExcutedTrainee.Single(n => n.Id == ExcInsId);
               
                    _context.TrExcutedTrainee.Remove(_receipt);
                    _context.SaveChanges();
                    return "Succeeded";
              

        }
        //get&getbyid
        public List<TrExcutedTraineeGetVM> GetAll()
            => _context.TrExcutedTrainee
            .Select(n => new TrExcutedTraineeGetVM
            {
                Id = n.Id,
                ExcutedId = n.ExcutedId,
                EmployeeId = n.EmployeeId,
                TraineeId = n.TraineeId,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        //public PaginatedResult<TrExcutedTraineeGetVM> GetAllByPagination(int page, int pageSize)
        //{
        //    var totalCount = _context.TrExcutedTrainee.Count();
        //    List<TrExcutedTraineeGetVM> Item = _context.TrExcutedTrainee
        //        .OrderByDescending(Item => Item.CreationDate)
        //        .Skip((page) * pageSize)
        //        .Take(pageSize)
        //        .Select(n => new TrExcutedTraineeGetVM
        //        {
        //            Id = n.Id,
        //            ExcutedId = n.ExcutedId,
        //            EmployeeId = n.EmployeeId,
        //            TraineeId = n.TraineeId,
        //            CreateUserName = n.CreatedBy.Name,
        //            TransactionUserId = n.CreatedBy.Id
        //        })
        //        .ToList();

        //    var paginatedResult = new PaginatedResult<TrExcutedTraineeGetVM>
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
        public PaginatedResult<TrExcutedTraineeGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.TrExcutedTrainee.Where(n => n.ExcutedId == HeaderId).Count();

            if (totalCount == 0)
            {
                return new PaginatedResult<TrExcutedTraineeGetVM>
                {
                    Items = new List<TrExcutedTraineeGetVM>(),
                    TotalItems = 0,
                    Page = page,
                    PageSize = pageSize
                };
            }
            List<int?> TrExcuted = _context.TrExcutedTrainee
                   .Where(sus => sus.ExcutedId == HeaderId)
                   .Select(sus => sus.ExcutedId)
                   .ToList();
            List<TrExcutedTraineeGetVM> Item = _context.TrExcutedTrainee
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrExcutedTraineeGetVM
                {
                              Id = n.Id,
                              ExcutedId = n.ExcutedId ?? 0,
                              EmployeeId = n.EmployeeId??0,
                              EmployeeName=n.EmployeeId!=null?n.Employee.Name:"",
                              TraineeId = n.TraineeId??0,
                              TraineeName=n.TraineeId!=null?n.Trainee.Name:"",
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
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrExcutedTraineeGetVM>
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
        public TrExcutedTraineeGetVM GetById(int itemId)
            => _context.TrExcutedTrainee
            .Select(n => new TrExcutedTraineeGetVM
            {
                Id = n.Id,
                ExcutedId = n.ExcutedId,
                EmployeeId = n.EmployeeId,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).Single(n => n.Id == itemId);
        public List<TrExcutedTraineeGetVM> GetByHeaderId(int Id)
            => _context.TrExcutedTrainee
            .Where(n => n.ExcutedId == Id)
            .Select(n => new TrExcutedTraineeGetVM
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
                EmployeeName = n.Employee.Name,
                //details
                Id = n.Id,
                ExcutedId = n.ExcutedId,
                EmployeeId = n.EmployeeId,
                TraineeId = n.TraineeId,
                TraineeName = n.Trainee.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();

    }


}
