using Entities.Models.TR;
using Entities.ViewModels.TR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Training
{
    public class TrTraineeRepository
    {

        private AppDbContext _context;
        public TrTraineeRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrTraineeVM Trainee)
        {
           
                var _Trainee = new TrTrainee()
                {
                    Name = Trainee.Name,

                    Code = Trainee.Code,

                    NationalId = Trainee.NationalId,

                    Phone = Trainee.Phone,

                    Email = Trainee.Email,

                    Address = Trainee.Address,

                    Gender = Trainee.Gender,

                    CityId = Trainee.CityId,
                    CityStateId = Trainee.CityStateId,
                    CorporationCLientId = Trainee.CorporationCLientId,

                    CreatedByID = Trainee.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.TrTrainee.Add(_Trainee);
                _context.SaveChanges();
                return "Succeeded";
          
        }
        //----------------------------------------
        // Update Data { By id => Trainee.id )} 
        //----------------------------------------
        public string Update(TrTraineeVM Trainee)
        {
           
                var _Trainee = _context.TrTrainee.Single(n => n.Id == Trainee.Id);
              
                    _Trainee.CorporationCLientId = Trainee.CorporationCLientId;
                    _Trainee.Name = Trainee.Name;
                    _Trainee.Code = Trainee.Code;
                    _Trainee.NationalId = Trainee.NationalId;
                    _Trainee.Phone = Trainee.Phone;
                    _Trainee.Email = Trainee.Email;
                    _Trainee.Address = Trainee.Address;
                    _Trainee.Gender = Trainee.Gender;
                    _Trainee.CityId = Trainee.CityId;
                    _Trainee.CityStateId = Trainee.CityStateId;
                    _Trainee.UpdateByID = Trainee.TransactionUserId;
                    _Trainee.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        //------------------------------
        // Delete Data { By id => TraineeId )} 
        //------------------------------
        public string Delete(int TraineeId)
        {
           
                var _Trainee = _context.TrTrainee.Single(n => n.Id == TraineeId);
            
                    _context.TrTrainee.Remove(_Trainee);
                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        //--------------------------
        // GET All { For all Data )} 
        //--------------------------
        public List<TrTraineeGetVM> GetAll()
            => _context.TrTrainee.Select(
                n => new TrTraineeGetVM
                {
                    Id = n.Id,

                    Name = n.Name,
                    Code = n.Code,
                    NationalId = n.NationalId,
                    Phone = n.Phone,
                    Email = n.Email,
                    Address = n.Address,
                    Gender = n.Gender,
                    CityId = n.CityId,
                    CityName = n.City.Name,
                    CorporationCLientId = n.CorporationCLientId,
                    CorporationCLinetName = n.CorporationCLient.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //-------------------------------------
        // GET All Data { By id => TraineeId )} 
        //-------------------------------------
        public TrTraineeGetVM GetById(int TraineeId)
            => _context.TrTrainee.Select(
                n => new TrTraineeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    NationalId = n.NationalId,
                    Phone = n.Phone,
                    Email = n.Email,
                    Address = n.Address,
                    Gender = n.Gender,
                    CityId = n.CityId,
                    CityName = n.City.Name,
                    CorporationCLientId = n.CorporationCLientId,
                    CorporationCLinetName = n.CorporationCLient.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).FirstOrDefault(n => n.Id == TraineeId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<TrTraineeGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrTrainee.Count();
            List<TrTraineeGetVM> Item = _context.TrTrainee
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrTraineeGetVM
                {
                    Id = n.Id,

                    CorporationCLientId = n.CorporationCLientId,
                    CorporationCLinetName = n.CorporationCLient.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrTraineeGetVM>
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
