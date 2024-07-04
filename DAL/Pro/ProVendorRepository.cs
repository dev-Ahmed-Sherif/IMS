using Entities.ExtensionMethods;
using Entities.Helpers;
using Entities.Models.Pro;
using Entities.ViewModels.FI.Account;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProVendorRepository
    {
        private AppDbContext _context;
        public ProVendorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> Add(ProVendorGeneralVM Vendor)
        {

            var _Vendor = new ProVendor()
            {
                Name = Vendor.Name,
                Code = Vendor.Code,
                Phone = Vendor.Phone,
                Email = Vendor.Email,
                CityId = Vendor.CityId,
                CityStateId = Vendor.CityStateId,
                Address = Vendor.Address,
                CreatedByID = Vendor.TransactionUserId,
                CreationDate = DateTime.Now,
                TheLevel = Vendor.TheLevel,
            };
            _context.ProVendors.Add(_Vendor);
            await _context.SaveChangesAsync();
            return "Succeeded";

        }

        public async Task<string> Update(ProVendorVM Vendor)
        {

            var _Vendor = _context.ProVendors.Single(n => n.Id == Vendor.Id);

            _Vendor.Name = Vendor.Name;
            _Vendor.Code = Vendor.Code;
            _Vendor.Phone = Vendor.Phone;
            _Vendor.Email = Vendor.Email;
            _Vendor.CityId = Vendor.CityId;
            _Vendor.CityStateId = Vendor.CityStateId;
            _Vendor.Address = Vendor.Address;
            _Vendor.UpdateByID = Vendor.TransactionUserId;
            _Vendor.LastUpdateDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return "Succeeded";

        }

        public string Delete(int VendorId)
        {


            var _Vendor = _context.ProVendors.Single(n => n.Id == VendorId);

            //var DetailsToDelete = _context.ProVendorsTypes.Where(n => n.VendorId == VendorId).ToList();
            //if (DetailsToDelete != null)
            //{
            //    _context.ProVendorsTypes.RemoveRange(DetailsToDelete);
            //    _context.SaveChanges();
            //}

            //var DetailsToDeletes = _context.pro.Where(n => n.VendorId == VendorId).ToList();
            //if (DetailsToDelete != null)
            //{
            //    _context.ProVendorsTypes.RemoveRange(DetailsToDelete);
            //    _context.SaveChanges();
            //}
            _context.ProVendors.Remove(_Vendor);
            _context.SaveChanges();
            return "Succeeded";

        }

        public List<ProVendorGetVM> GetAll() => _context.ProVendors
            .Select(n => new ProVendorGetVM
            {
                Id = n.Id,
                Name = n.Name,

                Code = n.Code,
                Phone = n.Phone,
                Email = n.Email,
                CityId = n.CityId,
                CityStateId = n.CityStateId,
                Address = n.Address,
                CityName = n.City.Name,
                CityStateName = n.CityState.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                TheLevel = n.TheLevel,
                UpdateUserName = n.UpdateBy != null ? n.UpdateBy.Name : "",
            }).ToList();
        public ProVendorGetVM GetById(int VendorId) => _context.ProVendors
            .Select(n => new ProVendorGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                Phone = n.Phone,
                Email = n.Email,
                CityId = n.CityId,
                CityStateId = n.CityStateId,
                Address = n.Address,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                CityName = n.City.Name,
                CityStateName = n.CityState.Name,
                TheLevel = n.TheLevel,
                UpdateUserName = n.UpdateBy != null ? n.UpdateBy.Name : "",
            }).Single(n => n.Id == VendorId);

        public List<ProVendorGetVM> GetByName(string VendorName)
        {
            return _context.StrVendor
                .Where(n => n.Name.Contains(VendorName))
                .Select(n => new ProVendorGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id,
                })
               .ToList();
        }
        //---------------------------------------------------
        //autocode function
        public string GetLastNo()
        {
            int maxNo = _context.ProVendors
             .Select(item => item.Code).DefaultIfEmpty()
             .Max();
            if (maxNo == 0)
            {
                maxNo = 1;
            }
            else
            {

                maxNo = maxNo + 1;

            }
            return maxNo.ToString();


        }
        //-------------------------------------------------
        //search function

        public List<ProVendorGetVM> Search(VendorSearchGeneral searchModel)
        {
            var query = _context.ProVendors.AsQueryable();
            if (searchModel.Id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.Id);
            }

            if (searchModel.CityStateId.HasValue)
            {
                query = query.Where(p => p.CityStateId == searchModel.CityStateId);
            }

            if (searchModel.CityId.HasValue)
            {
                query = query.Where(p => p.CityId == searchModel.CityId);
            }


            if (searchModel.Code.HasValue)
            {
                query = query.Where(p => p.Code == searchModel.Code);
            }

            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                query = query.Where(p => p.Name.Contains(searchModel.Name));
            }
            if (!string.IsNullOrEmpty(searchModel.Phone))
            {
                query = query.Where(p => p.Phone == searchModel.Phone);
            }
            if (!string.IsNullOrEmpty(searchModel.Email))
            {
                query = query.Where(p => p.Email == searchModel.Email);
            }

            var results = query.Select(n => new ProVendorGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                Phone = n.Phone,
                Email = n.Email,
                CityId = n.CityId,
                CityStateId = n.CityStateId,
                Address = n.Address,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                CityName = n.City.Name,
                CityStateName = n.CityState.Name,
                TheLevel = n.TheLevel,
                UpdateUserName = n.UpdateBy != null ? n.UpdateBy.Name : "",
            }).ToList();


            return results;

        }
        public PaginatedResult<ProVendorGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.ProVendors.Count();
            List<ProVendorGetVM> Item = _context.ProVendors
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new ProVendorGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    Phone = n.Phone,
                    Email = n.Email,
                    CityId = n.CityId,
                    CityStateId = n.CityStateId,
                    Address = n.Address,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id,
                    CityName = n.City.Name,
                    CityStateName = n.CityState.Name,
                    TheLevel = n.TheLevel,
                    UpdateUserName = n.UpdateBy != null ? n.UpdateBy.Name : "",
                })
                .ToList();

            var paginatedResult = new PaginatedResult<ProVendorGetVM>
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
