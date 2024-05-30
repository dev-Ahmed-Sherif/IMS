using Entities.Models.TR.Instructor;
using Entities.ViewModels.TR.Instructor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Instructor
{
    public class TrInstructorDataRepository
    {
        private AppDbContext _context;
        public TrInstructorDataRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrInstructorDataGeneralVM Inst)
        {
           
                var _Inst = new TrInstructorData()
                {
                    Code = Inst.Code,
                    Name = Inst.Name,
                    phone = Inst.phone,
                    Email = Inst.Email,
                    Position = Inst.Position,
                    Address = Inst.Address,
                    Gender = Inst.Gender,
                    CityId = Inst.CityId,
                    CreatedByID = Inst.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.TrInstructorData.Add(_Inst);
                _context.SaveChanges();
                return _Inst.Id.ToString();
            

         
        }
        //-------------------------------
        // Update Data { By id => inst )} 
        //-------------------------------
        public string Update(TrInstructorDataVM Inst)
        {
          
                var _item = _context.TrInstructorData.Single(n => n.Id == Inst.Id);
              


                    _item.Code = Inst.Code;
                    _item.Name = Inst.Name;
                    _item.phone = Inst.phone;
                    _item.Email = Inst.Email;
                    _item.Position = Inst.Position;
                    _item.Address = Inst.Address;
                    _item.CityId = Inst.CityId;
                    _item.Gender = Inst.Gender;
                    _item.UpdateByID = Inst.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //------------------------------
        // Delete Data { By id => inst )} 
        //------------------------------
        public string Delete(int InstId)
        {
            
                var _receipt = _context.TrInstructorData.Single(n => n.Id == InstId);
            var DetailsToDelete = _context.TrInstructor.Where(p => p.InstructorDataId == InstId).ToList();
            _context.TrInstructor.RemoveRange(DetailsToDelete);
            _context.SaveChanges();

            _context.TrInstructorData.Remove(_receipt);
                    _context.SaveChanges();
                    return "Succeeded";
            

        }
        //--------------------------
        // GET All { For all Data )} 
        //--------------------------
        public List<TrInstructorDataGetVM> GetAll()
            => _context.TrInstructorData.Select(
                n => new TrInstructorDataGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    phone = n.phone,
                    Email = n.Email,
                    Position = n.Position,
                    Address = n.Address,
                    Gender = n.Gender,
                    CityId = n.CityId,
                    CityName = n.City.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //---------------------------------
        // GET All Data { By id => itemId )} 
        //---------------------------------
        public TrInstructorDataGetVM GetById(int itemId)
            => _context.TrInstructorData.Select(
                n => new TrInstructorDataGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    phone = n.phone,
                    Email = n.Email,
                    Position = n.Position,
                    Address = n.Address,
                    Gender = n.Gender,
                    CityId = n.CityId,
                    CityName = n.City.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).FirstOrDefault(n => n.Id == itemId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<TrInstructorDataGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrInstructorData.Count();
            List<TrInstructorDataGetVM> Item = _context.TrInstructorData
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrInstructorDataGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    phone = n.phone,
                    Email = n.Email,
                    Position = n.Position,
                    Address = n.Address,
                    Gender = n.Gender,
                    CityId = n.CityId,
                    CityName = n.City.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrInstructorDataGetVM>
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

