using Entities.Models.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.General
{
    public class StrModelRepository
    {
        private AppDbContext _context;

        public StrModelRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrModelGeneralVM model)
        {
          
                bool exists = _context.StrModel.Any(s => s.Name == model.Name);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _model = new StrModel()
                {
                    Name = model.Name,
                    VendorId = model.VendorId,
                    CreatedByID = model.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrModel.Add(_model);
                _context.SaveChanges();
                return _model.Id.ToString();

           
        }
        public string Update(StrModelVM model)
        {
           
                bool exists = _context.StrModel.Any(s => s.Name == model.Name && s.Id != model.Id);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _model = _context.StrModel.Single(n => n.Id == model.Id);
               
                    _model.Name = model.Name;
                    _model.VendorId = model.VendorId;
                    _model.UpdateByID = model.TransactionUserId;
                    _model.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
               
         
        }
        public string Delete(int modelId)
        {
               var _model = _context.StrModel.Single(n => n.Id == modelId);
               
                    _context.StrModel.Remove(_model);
                    _context.SaveChanges();
                    return "Succeeded";
            
          
        }
        public List<StrModelGetVM> GetAll() => _context.StrModel.Select(n => new StrModelGetVM { Id = n.Id, Name = n.Name, VendorId = n.VendorId, VendorName = n.Vendor.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public StrModelGetVM GetById(int modelId) => _context.StrModel.Select(n => new StrModelGetVM { Id = n.Id, Name = n.Name, VendorId = n.VendorId, VendorName = n.Vendor.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == modelId);
    }
}
