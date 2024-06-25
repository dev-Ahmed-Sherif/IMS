using Entities.Models.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Pro
{
    public class ProSupplierTypeRepository
    {
        private AppDbContext _context;
        public ProSupplierTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        //----------------------------------------------
        //add function
        public string Add(ProSupplierTypeGeneralVM add)
        {
          
                var _add = new ProSupplierType()
                {
                    Name = add.Name,

                    Code = add.Code,

                    CreatedByID = add.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.ProSupplierTypes.Add(_add);
                _context.SaveChanges();
                return _add.Id.ToString();
           
        }
        //-----------------------------------------------
        //update function
        public string Update(ProSupplierTypeVM update)
        {
           
                var _update = _context.ProSupplierTypes.Single(n => n.Id == update.Id);
                 _update.Name = update.Name;
                    _update.Code = update.Code;
                    _update.UpdateByID = update.TransactionUserId;
                    _update.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
           
        }

        //--------------------------------------------
        //delete function

        public string Delete(int ID)
        {
          
                var _Row = _context.ProSupplierTypes.Single(n => n.Id == ID);
             
                    _context.ProSupplierTypes.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //-----------------------------------
        //get function
        public List<ProSupplierTypeGetVM> GetAll() => _context.ProSupplierTypes.Select(n => new ProSupplierTypeGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public ProSupplierTypeGetVM GetById(int itemId) => _context.ProSupplierTypes.Select(n => new ProSupplierTypeGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);
        //------------------------------------------
        //autocode function
        public string GetLastNo()
        {
            int maxNo = _context.ProSupplierTypes
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
    }
}



