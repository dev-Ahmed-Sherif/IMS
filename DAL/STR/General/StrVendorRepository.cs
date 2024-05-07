using Entities.Models.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.General
{
    public class StrVendorRepository
    {
        private AppDbContext _context;

        public StrVendorRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrVendorGeneralVM vendor)
        {
           
                bool exists = _context.StrVendor.Any(s => s.Name == vendor.Name);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _vendor = new StrVendor()
                {
                    Name = vendor.Name,
                    CreatedByID = vendor.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrVendor.Add(_vendor);
                _context.SaveChanges();
                return _vendor.Id.ToString();

            
          
        }
        public string Update(StrVendorVM vendor)
        {
           
                bool exists = _context.StrVendor.Any(s => s.Name == vendor.Name && s.Id != vendor.Id);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _vendor = _context.StrVendor.Single(n => n.Id == vendor.Id);
                
                    _vendor.Name = vendor.Name;

                    _vendor.UpdateByID = vendor.TransactionUserId;
                    _vendor.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
               
          
        }
        public string Delete(int vendorId)
        {
           
                var _vendor = _context.StrVendor.Single(n => n.Id == vendorId);
               
                    _context.StrVendor.Remove(_vendor);
                    _context.SaveChanges();
                    return "Succeeded";
               
           
        }
        public List<StrVendorGetVM> GetAll() => _context.StrVendor.Select(n => new StrVendorGetVM { Id = n.Id, Name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public StrVendorGetVM GetById(int vendorId) => _context.StrVendor.Select(n => new StrVendorGetVM { Id = n.Id, Name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == vendorId);

        public List<StrVendorGetVM> GetByName(string VendorName)
        {
            return _context.StrVendor
                .Where(n => n.Name.Contains(VendorName))
                .Select(n => new StrVendorGetVM
                {
                    Id = n.Id,
                    Name = n.Name,

                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
               .ToList();
        }

    }
}
