using Entities.Models.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Pro
{
    public class ProSellerRepository
    {
        private AppDbContext _context;
        public ProSellerRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(ProSellerVM seller)
        {
            try
            {
                var _seller = new ProSeller()
                {
                    Name = seller.Name,
                    Code = seller.Code,
                    Phone = seller.Phone,
                    Email = seller.Email,
                    CityId = seller.CityId,
                    CityStateId = seller.CityStateId,
                    Address = seller.Address,
                    CommericalRegister = seller.CommericalRegister,
                    TaxCard = seller.TaxCard,
                    CreatedByID = seller.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.ProSeller.Add(_seller);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Update(ProSellerVM seller)
        {
           
                    var _seller = _context.ProSeller.Single(n => n.Id == seller.Id);
               
                    _seller.Name = seller.Name;
                    _seller.Code = seller.Code;
                    _seller.Phone = seller.Phone;
                    _seller.Email = seller.Email;
                    _seller.CityId = seller.CityId;
                    _seller.CityStateId = seller.CityStateId;
                    _seller.Address = seller.Address;
                    _seller.CommericalRegister = seller.CommericalRegister;
                    _seller.TaxCard = seller.TaxCard;
                    _seller.UpdateByID = seller.TransactionUserId;
                    _seller.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
           
        }

        public string Delete(int sellerId)
        {
            
                var _seller = _context.ProSeller.Single(n => n.Id == sellerId);
             
                    _context.ProSeller.Remove(_seller);
                    _context.SaveChanges();
                    return "Succeeded";
            
        }

        public List<ProSellerGetVM> GetAll() => _context.ProSeller
            .Select(n => new ProSellerGetVM
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
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        public ProSellerGetVM GetById(int sellerId) => _context.ProSeller
            .Select(n => new ProSellerGetVM
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

                TransactionUserId = n.CreatedBy.Id
            }).Single(n => n.Id == sellerId);

        public List<ProSellerGetVM> GetByName(string SellerName)
        {
            return _context.StrVendor
                .Where(n => n.Name.Contains(SellerName))
                .Select(n => new ProSellerGetVM
                {
                    Id = n.Id,
                    Name = n.Name,

                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
               .ToList();
        }
        //---------------------------------------------------
        //autocode function
        public string GetLastNo()
        {
            int maxNo = _context.ProSeller
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

        public List<ProSellerGetVM> Search(SellerSearchGeneral searchModel)
        {
            var query = _context.ProSeller.AsQueryable();
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

            var results = query.Select(n => new ProSellerGetVM
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
                TransactionUserId = n.CreatedBy.Id
            }).ToList();


            return results;

        }

    }
}
