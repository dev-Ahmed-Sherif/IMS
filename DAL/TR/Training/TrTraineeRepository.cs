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


        public List<TrTraineeGetSearchVM> Search(TrTraineeSearch searchModel)
        {
            var query = _context.TrTrainee.AsQueryable();
            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                query = query.Where(p => p.Name.Contains(searchModel.Name));
            }
            if (!string.IsNullOrEmpty(searchModel.Code))
            {
                query = query.Where(p => p.Code.Contains(searchModel.Code));
            }
            if (!string.IsNullOrEmpty(searchModel.Phone))
            {
                query = query.Where(p => p.Phone.Contains(searchModel.Phone));
            }
            if (!string.IsNullOrEmpty(searchModel.Email))
            {
                query = query.Where(p => p.Email.Contains(searchModel.Email));
            }
            if (!string.IsNullOrEmpty(searchModel.Address))
            {
                query = query.Where(p => p.Address.Contains(searchModel.Address));
            }
            if (!string.IsNullOrEmpty(searchModel.Gender))
            {
                query = query.Where(p => p.Gender.Contains(searchModel.Gender));
            }
            if (!string.IsNullOrEmpty(searchModel.Gender))
            {
                query = query.Where(p => p.Gender.Contains(searchModel.Gender));
            }
            if (!string.IsNullOrEmpty(searchModel.NationalId))
            {
                query = query.Where(p => p.NationalId.ToString().Contains(searchModel.NationalId));
            }
            if (!string.IsNullOrEmpty(searchModel.CityId))
            {
                query = query.Where(p => p.CityId.ToString().Contains(searchModel.CityId));
            }
            if (!string.IsNullOrEmpty(searchModel.CityStateId))
            {
                query = query.Where(p => p.CityStateId.ToString().Contains(searchModel.CityStateId));
            }
            if (!string.IsNullOrEmpty(searchModel.CorporationCLientId))
            {
                query = query.Where(p => p.CorporationCLientId.ToString().Contains(searchModel.CorporationCLientId));
            }
            if (!string.IsNullOrEmpty(searchModel.TransactionUserId))
            {
                query = query.Where(p => p.CreatedBy.Id.ToString().Contains(searchModel.TransactionUserId));
            }
            var result = query.Select(n => new TrTraineeGetSearchVM
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
                TransactionUserId = n.CreatedBy.Id,
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                //Section = n.Section.Name,    

            }).ToList();

            return result;
        }



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
