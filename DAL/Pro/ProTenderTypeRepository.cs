using Entities.Models.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Pro
{
    public class ProTenderTypeRepository
    {
        private AppDbContext _context;
        public ProTenderTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        //----------------------------------------------
        //add function
        public string Add(ProTenderTypeGeneralVM add)
        {
           
                var _add = new ProTenderType()
                {
                    Name = add.Name,

                    Code = add.Code,

                    CreatedByID = add.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.ProTenderType.Add(_add);
                _context.SaveChanges();
                return _add.Id.ToString();
         
        }
        //-----------------------------------------------
        //update function
        public string Update(ProTenderTypeVM update)
        {
           
                var _update = _context.ProTenderType.Single(n => n.Id == update.Id);
               
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
            
                var _Row = _context.ProTenderType.Single(n => n.Id == ID);
              
                    _context.ProTenderType.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";

        }
        //-----------------------------------
        //get function
        public List<ProTenderTypeGetVM> GetAll() => _context.ProTenderType.Select(n => new ProTenderTypeGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public ProTenderTypeGetVM GetById(int itemId) => _context.ProTenderType.Select(n => new ProTenderTypeGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);
        //------------------------------------------
        //autocode function
        public string GetLastNo()
        {
            int maxNo = _context.ProTenderType
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
