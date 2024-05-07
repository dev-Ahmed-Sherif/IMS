using Entities.Models.TR;
using Entities.ViewModels.TR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Training
{
    public class TrTrainingCenterRepository
    {

        private AppDbContext _context;
        public TrTrainingCenterRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrTrainingCenterVM TrainingCenter)
        {
           
                var _TrainingCenter = new TrTrainingCenter()
                {
                    Name = TrainingCenter.Name,

                    Code = TrainingCenter.Code,

                    Phone = TrainingCenter.Phone,

                    Email = TrainingCenter.Email,

                    Address = TrainingCenter.Address,
                    CityId = TrainingCenter.CityId,
                    IsActive = TrainingCenter.IsActive,




                    CreatedByID = TrainingCenter.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.TrTrainingCenter.Add(_TrainingCenter);
                _context.SaveChanges();
                return "Succeeded";
          
        }
        //----------------------------------------
        // Update Data { By id => TrainingCenter )} 
        //----------------------------------------
        public string Update(TrTrainingCenterVM TrainingCenter)
        {
           
                var _TrainingCenter = _context.TrTrainingCenter.Single(n => n.Id == TrainingCenter.Id);
               
                    _TrainingCenter.Name = TrainingCenter.Name;
                    _TrainingCenter.Code = TrainingCenter.Code;
                    _TrainingCenter.Phone = TrainingCenter.Phone;
                    _TrainingCenter.Email = TrainingCenter.Email;
                    _TrainingCenter.Address = TrainingCenter.Address;
                    _TrainingCenter.CityId = TrainingCenter.CityId;
                    _TrainingCenter.IsActive = TrainingCenter.IsActive;


                    _TrainingCenter.UpdateByID = TrainingCenter.TransactionUserId;
                    _TrainingCenter.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
          
        }
        //--------------------------------------------
        // Delete Data { By id => TrainingCentereId )} 
        //--------------------------------------------
        public string Delete(int TrainingCentereId)
        {
          
                var _TR_TrainingCenter = _context.TrTrainingCenter.Single(n => n.Id == TrainingCentereId);
              

                    var DetailsToDelete = _context.TrInstructor.Where(n => n.TrainingCenterId == TrainingCentereId).ToList();
                    if (DetailsToDelete != null)
                    {
                        _context.TrInstructor.RemoveRange(DetailsToDelete);
                        _context.SaveChanges();
                    }
                    _context.TrTrainingCenter.Remove(_TR_TrainingCenter);
                    _context.SaveChanges();
                    return "Succeeded";
             

        }
        //--------------------------
        // GET All { For all Data )} 
        //--------------------------
        public List<TrTrainingCenterGetVM> GetAll()
            => _context.TrTrainingCenter.Select(
                n => new TrTrainingCenterGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    Phone = n.Phone,
                    Email = n.Email,
                    Address = n.Address,
                    CityId = n.CityId,
                    CityName = n.City.Name,
                    IsActive = n.IsActive,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //---------------------------------------------
        // GET All Data { By id => TrainingCenterId )} 
        //---------------------------------------------
        public TrTrainingCenterGetVM GetById(int TrainingCenterId)
            => _context.TrTrainingCenter.Select(
                n => new TrTrainingCenterGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    Phone = n.Phone,
                    Email = n.Email,
                    Address = n.Address,
                    CityId = n.CityId,
                    CityName = n.City.Name,
                    IsActive = n.IsActive,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == TrainingCenterId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<TrTrainingCenterGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrTrainingCenter.Count();
            List<TrTrainingCenterGetVM> Item = _context.TrTrainingCenter
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrTrainingCenterGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    Phone = n.Phone,
                    Email = n.Email,
                    Address = n.Address,
                    CityId = n.CityId,
                    CityName = n.City.Name,
                    IsActive = n.IsActive,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrTrainingCenterGetVM>
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
