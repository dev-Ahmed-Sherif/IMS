using Entities.ViewModels.TR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.General
{
    public class TrCoporateClientRepository
    {
        private AppDbContext _context;
        public TrCoporateClientRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrCorporateCLientGeneralVM Inst)
        {
           

                var _Inst = new TrCorporateCLient()
                {
                    Code = Inst.Code,
                    Name = Inst.Name,
                    phone = Inst.phone,
                    Email = Inst.Email,
                    Address = Inst.Address,
                    CityId = Inst.CityId,
                    CreatedByID = Inst.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrCorporateCLient.Add(_Inst);
                _context.SaveChanges();
                return _Inst.Id.ToString();
          

        }
        //------------------------
        // Update Data { By id  )} 
        //------------------------
        public string Update(TrCorporateCLientVM Inst)
        {
           

                var _item = _context.TrCorporateCLient.FirstOrDefault(n => n.Id == Inst.Id);
              



                    _item.Code = Inst.Code;

                    _item.Name = Inst.Name;
                    _item.phone = Inst.phone;
                    _item.Email = Inst.Email;

                    _item.Address = Inst.Address;
                    _item.CityId = Inst.CityId;

                    _item.UpdateByID = Inst.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
              

        }
        //------------------------------
        // Delete Data { By id => instId )} 
        //------------------------------
        public string Delete(int InstId)
        {
            
                var _receipt = _context.TrCorporateCLient.Single(n => n.Id == InstId);
               
                    _context.TrCorporateCLient.Remove(_receipt);
                    _context.SaveChanges();
                    return "Succeeded";
             

        }
        //--------------------------
        // GET All { For all Data )} 
        //--------------------------
        public List<TrCorporateCLientGetVM> GetAll()
            => _context.TrCorporateCLient.Select(
                n => new TrCorporateCLientGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    phone = n.phone,
                    Email = n.Email,
                    Address = n.Address,
                    CityId = n.CityId,
                    CityName = n.City.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //---------------------------------
        // GET All Data { By id => TrackId )} 
        //---------------------------------
        public TrCorporateCLientGetVM GetById(int itemId)
            => _context.TrCorporateCLient.Select(
                n => new TrCorporateCLientGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    phone = n.phone,
                    Email = n.Email,
                    Address = n.Address,
                    CityId = n.CityId,
                    CityName = n.City.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == itemId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<TrCorporateCLientGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrCorporateCLient.Count();
            List<TrCorporateCLientGetVM> Item = _context.TrCorporateCLient
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrCorporateCLientGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    phone = n.phone,
                    Email = n.Email,
                    Address = n.Address,
                    CityId = n.CityId,
                    CityName = n.City.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();








            var paginatedResult = new PaginatedResult<TrCorporateCLientGetVM>
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

