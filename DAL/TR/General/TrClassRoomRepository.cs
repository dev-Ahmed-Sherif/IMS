using Entities.Models.TR;
using Entities.ViewModels.TR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.General
{
    public class TrClassRoomRepository
    {

        private AppDbContext _context;
        public TrClassRoomRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrClassRoomVM ClassRoom)
        {
           
                var _ClassRoom = new TrClassRoom()
                {
                    Code = ClassRoom.Code,
                    Name = ClassRoom.Name,
                    Address = ClassRoom.Address,
                    Type = ClassRoom.Type,
                    Capacity = ClassRoom.Capacity,
                    IsActive = ClassRoom.IsActive,
                    TrainingCenterId = ClassRoom.TrainingCenterId,
                    CityStateId = ClassRoom.CityStateId,



                    CreatedByID = ClassRoom.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.TrClassRoom.Add(_ClassRoom);
                _context.SaveChanges();
                return "Succeeded";
          
        }
        //------------------------
        // Update Data { By id  )} 
        //------------------------
        public string Update(TrClassRoomVM ClassRoom)
        {
            
                var _ClassRoom = _context.TrClassRoom.Single(n => n.Id == ClassRoom.Id);
              
                    _ClassRoom.Code = ClassRoom.Code;
                    _ClassRoom.Name = ClassRoom.Name;
                    _ClassRoom.Address = ClassRoom.Address;
                    _ClassRoom.Type = ClassRoom.Type;
                    _ClassRoom.Capacity = ClassRoom.Capacity;
                    _ClassRoom.IsActive = ClassRoom.IsActive;
                    _ClassRoom.CityStateId = ClassRoom.CityStateId;
                    _ClassRoom.TrainingCenterId = ClassRoom.TrainingCenterId;

                    _ClassRoom.UpdateByID = ClassRoom.TransactionUserId;
                    _ClassRoom.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
           
        }
        //-----------------------
        // Delete Data { By id )} 
        //-----------------------
        public string Delete(int TraineeId)
        {
           
                var _platoon = _context.TrClassRoom.Single(n => n.Id == TraineeId);
               
                    _context.TrClassRoom.Remove(_platoon);
                    _context.SaveChanges();
                    return "Succeeded";
               
        }
        //--------------------------
        // GET All { For all Data )} 
        //--------------------------
        public List<TrClassRoomGetVM> GetAll()
            => _context.TrClassRoom.Select(
                n => new TrClassRoomGetVM
                {
                    Id = n.Id,
                    Code = n.Code,
                    Name = n.Name,
                    Address = n.Address,
                    Type = n.Type,
                    Capacity = n.Capacity,
                    IsActive = n.IsActive,
                    TrainingCenterId = n.TrainingCenterId,
                    TrainingCenterName = n.TrainingCenter.Name,
                    CityStateId = n.CityStateId,
                    CityStateName = n.CityState.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //-------------------------
        // GET All Data { By id  )} 
        //-------------------------
        public TrClassRoomGetVM GetById(int ClassRoomId)
            => _context.TrClassRoom.Select(
                n => new TrClassRoomGetVM
                {
                    Id = n.Id,
                    Code = n.Code,
                    Name = n.Name,
                    Address = n.Address,
                    Type = n.Type,
                    Capacity = n.Capacity,
                    IsActive = n.IsActive,
                    TrainingCenterId = n.TrainingCenterId,
                    TrainingCenterName = n.TrainingCenter.Name,
                    CityStateId = n.CityStateId,
                    CityStateName = n.CityState.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == ClassRoomId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<TrClassRoomGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrClassRoom.Count();
            List<TrClassRoomGetVM> Item = _context.TrClassRoom
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrClassRoomGetVM
                {
                    Id = n.Id,
                    Code = n.Code,
                    Name = n.Name,
                    Address = n.Address,
                    Type = n.Type,
                    Capacity = n.Capacity,
                    IsActive = n.IsActive,
                    TrainingCenterId = n.TrainingCenterId,
                    TrainingCenterName = n.TrainingCenter.Name,
                    CityStateId = n.CityStateId,
                    CityStateName = n.CityState.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrClassRoomGetVM>
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
