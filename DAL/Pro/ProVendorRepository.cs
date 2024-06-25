using Entities.Helpers;
using Entities.Models.Pro;
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
            try
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
                    CommericalRegister = Vendor.CommericalRegister,
                    TaxCard = Vendor.TaxCard,
                    CreatedByID = Vendor.TransactionUserId,
                    CreationDate = DateTime.Now,
                    IndusterialRegister = Vendor.IndusterialRegister,
                    TheLevel = Vendor.TheLevel,
                    AddedValueTaxUrl =
                    Vendor.AddedValueTax != null ?
                    await FileHelper.UploadFile(Vendor.AddedValueTax) : "",
                    UnionCardUrl =
                    Vendor.UnionCard != null ?
                    await FileHelper.UploadFile(Vendor.UnionCard) : "",
                };
                _context.ProVendors.Add(_Vendor);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
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
            _Vendor.CommericalRegister = Vendor.CommericalRegister;
            _Vendor.TaxCard = Vendor.TaxCard;
            _Vendor.UpdateByID = Vendor.TransactionUserId;
            _Vendor.LastUpdateDate = DateTime.Now;
            if (Vendor.AddedValueTax != null)
            {
                string addedValueTaxUrl = await FileHelper.UploadFile(Vendor.AddedValueTax);
                _Vendor.AddedValueTaxUrl = addedValueTaxUrl;
            }
            if (Vendor.UnionCard != null)
            {
                string unionCardUrl = await FileHelper.UploadFile(Vendor.UnionCard);
                _Vendor.UnionCardUrl = unionCardUrl;
            }
            _context.SaveChanges();
            return "Succeeded";

        }

        public string Delete(int VendorId)
        {

            var _Vendor = _context.ProVendors.Single(n => n.Id == VendorId);

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
                CommericalRegister = n.CommericalRegister,
                TaxCard = n.TaxCard,
                CityName = n.City.Name,
                CityStateName = n.CityState.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                IndusterialRegister = n.IndusterialRegister,
                TheLevel = n.TheLevel,
                UpdateUserName = n.UpdateBy != null ? n.UpdateBy.Name : "",
                UnionCard = n.UnionCardUrl,
                AddedValueTax = n.AddedValueTaxUrl
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
                CommericalRegister = n.CommericalRegister,
                TaxCard = n.TaxCard,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                CityName = n.City.Name,
                CityStateName = n.CityState.Name,
                IndusterialRegister = n.IndusterialRegister,
                TheLevel = n.TheLevel,
                UpdateUserName = n.UpdateBy != null ? n.UpdateBy.Name : "",
                UnionCard = n.UnionCardUrl,
                AddedValueTax = n.AddedValueTaxUrl,
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
                CommericalRegister = n.CommericalRegister,
                TaxCard = n.TaxCard,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                CityName = n.City.Name,
                CityStateName = n.CityState.Name,
                IndusterialRegister = n.IndusterialRegister,
                TheLevel = n.TheLevel,
                UpdateUserName = n.UpdateBy != null ? n.UpdateBy.Name : "",
                UnionCard = n.UnionCardUrl,
                AddedValueTax = n.AddedValueTaxUrl
            }).ToList();


            return results;

        }

    }
}
