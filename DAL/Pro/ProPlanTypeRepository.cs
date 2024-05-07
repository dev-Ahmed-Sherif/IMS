using Entities.Models.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Pro
{
    public class ProPlanTypeRepository
    {
        private AppDbContext _context;
        public ProPlanTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        //----------------------------------------------
        //add function
        public string Add(ProPlantTypeGeneralVM add)
        {
            
                var _add = new ProPlanType()
                {
                    Name = add.Name,

                    Code = add.Code,

                    CreatedByID = add.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.ProPlantType.Add(_add);
                _context.SaveChanges();
                return _add.Id.ToString();
        
        }
        //-----------------------------------------------
        //update function
        public string Update(ProPlanTypeVM update)
        {
           
                var _update = _context.ProPlantType.Single(n => n.Id == update.Id);
              
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
             var _Row = _context.ProPlantType.Single(n => n.Id == ID);
              
                    _context.ProPlantType.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //-----------------------------------
        //get function
        public List<ProPlantTypeGetVM> GetAll() => _context.ProPlantType.Select(n => new ProPlantTypeGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public ProPlantTypeGetVM GetById(int itemId) => _context.ProPlantType.Select(n => new ProPlantTypeGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);
        //------------------------------------------
        //autocode function
        public string GetLastNo()
        {
            int maxNo = _context.ProPlantType
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
