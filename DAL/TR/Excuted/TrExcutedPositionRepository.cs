using Entities.Models.TR.Excuted;
using Entities.ViewModels.TR.Excuted;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.TR.Excuted
{
    public class TrExcutedPositionRepository
    {
        private AppDbContext _context;

        public TrExcutedPositionRepository(AppDbContext context)
        {
            _context = context;
        }
        //add function
        public string Add(TrExcutedPositionGeneralVM Excpos)
        {
            
                var _Excpos = new TrExcutedPosition()
                {
                    ExcutedId = Excpos.ExcutedId,
                    PositionId = Excpos.PositionId,

                    CreatedByID = Excpos.TransactionUserId,
                    CreationDate = DateTime.Now



                };
                _context.TrExcutedPosition.Add(_Excpos);
                _context.SaveChanges();
                return _Excpos.Id.ToString();
         
        }
        //update
        public string Update(TrExcutedPositionVM ExcIns)
        {
           
                var _item = _context.TrExcutedPosition.Single(n => n.Id == ExcIns.Id);
              


                    _item.ExcutedId = ExcIns.ExcutedId;
                    _item.PositionId = ExcIns.PositionId;
                    _item.UpdateByID = ExcIns.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //delet
        public string Delete(int ExcInsId)
        {
           
                var _receipt = _context.TrExcutedPosition.Single(n => n.Id == ExcInsId);
               
                    _context.TrExcutedPosition.Remove(_receipt);
                    _context.SaveChanges();
                    return "Succeeded";
           

        }
        //get&getbyid
        public List<TrExcutedPositionGetVM> GetAll()
            => _context.TrExcutedPosition.Select(n => new TrExcutedPositionGetVM
            {
                Id = n.Id,
                ExcutedId = n.ExcutedId,
                PositionId = n.PositionId,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();

        public List<TrExcutedPositionGetVM> GetByHeaderId(int Id)
            => _context.TrExcutedPosition
            .Where(n => n.ExcutedId == Id)
            .Select(n => new TrExcutedPositionGetVM
            {
                HeaderCost = n.Excuted.Cost,
                HeaderStatus = n.Excuted.Status,
                HeaderEndDate = n.Excuted.EndDate,
                HeaderHeaderDays = n.Excuted.Days,
                HeaderNoTrainee = n.Excuted.NoTrainee,
                HeaderStartDate = n.Excuted.StartDate,
                HeaderCostplaned = n.Excuted.Costplaned,
                HeaderCourseName = n.Excuted.Course.Name,
                HeaderPurposeName = n.Excuted.Purpose.Name,
                HeaderDelegateName = n.Excuted.Delegate.Name,
                HeaderClassRoomName = n.Excuted.ClassRoom.Name,
                HeaderNoTraineeTotal = n.Excuted.NoTraineeTotal,
                HeaderMaterialPurposeName = n.Excuted.Purpose.Name,
                HeaderFiscalYearName = n.Excuted.FiscalYear.fiscalyear,
                HeaderNoTraineeCorporate = n.Excuted.NoTraineeCorporate,
                HeaderTrainingCenterName = n.Excuted.TrainingCenter.Name,
                //details
                Id = n.Id,
                ExcutedId = n.ExcutedId,
                PositionId = n.PositionId,
                PositionName = n.Position.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        //public PaginatedResult<TrExcutedPositionGetVM> GetAllByPagination(int page, int pageSize)
        //{
        //    var totalCount = _context.TrExcutedPosition.Count();
        //    List<TrExcutedPositionGetVM> Item = _context.TrExcutedPosition
        //        .OrderByDescending(Item => Item.CreationDate)
        //        .Skip((page) * pageSize)
        //        .Take(pageSize)
        //        .Select(n => new TrExcutedPositionGetVM
        //        {
        //            Id = n.Id,
        //            ExcutedId = n.ExcutedId,
        //            PositionId = n.PositionId,
        //            CreateUserName = n.CreatedBy.Name,
        //            TransactionUserId = n.CreatedBy.Id
        //        })
        //        .ToList();

        //    var paginatedResult = new PaginatedResult<TrExcutedPositionGetVM>
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
        public PaginatedResult<TrExcutedPositionGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.TrExcutedPosition.Where(n => n.ExcutedId == HeaderId).Count();

            if (totalCount == 0)
            {
                return new PaginatedResult<TrExcutedPositionGetVM>
                {
                    Items = new List<TrExcutedPositionGetVM>(),
                    TotalItems = 0,
                    Page = page,
                    PageSize = pageSize
                };
            }
            List<int> TrExcuted = _context.TrExcutedPosition
                   .Where(sus => sus.ExcutedId == HeaderId)
                   .Select(sus => sus.ExcutedId)
                   .ToList();
            List<TrExcutedPositionGetVM> Item = _context.TrExcutedPosition
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrExcutedPositionGetVM
                {
                                Id = n.Id,
                               ExcutedId = n.ExcutedId,
                               PositionId = n.PositionId,
                               CreateUserName = n.CreatedBy.Name,
                               TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrExcutedPositionGetVM>
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
        public TrExcutedPositionGetVM GetById(int itemId) => _context.TrExcutedPosition.Select(n => new TrExcutedPositionGetVM { Id = n.Id, ExcutedId = n.ExcutedId, PositionId = n.PositionId, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);

    }
}
