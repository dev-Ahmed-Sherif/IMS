using Entities.Models.Fa;
using Entities.ViewModels.Fa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Fa
{
    public class FaCategoryThirdRepository
    {
        private AppDbContext _context;

        public FaCategoryThirdRepository(AppDbContext context)
        {
            _context = context;
        }
        //---------------------------------------------
        //add function
        public string Add(FaCategoryThirdGeneralVM add)
        {
            
                var _add = new FaCategoryThird()
                {
                    Name = add.Name,

                    Code = add.Code,

                    CreatedByID = add.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.FaCategoryThird.Add(_add);
                _context.SaveChanges();
                return _add.Id.ToString();
           
        }
        //-----------------------------------------------
        //update function
        public string Update(FaCategoryThirdVM Update)
        {
            var _update = _context.FaCategoryThird.Single(n => n.Id == Update.Id);
               
                    _update.Name = Update.Name;
                    _update.Code = Update.Code;
                    _update.UpdateByID = Update.TransactionUserId;
                    _update.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
                
             
        }
        //--------------------------------------------
        //delete function

        public string Delete(int Row_Id)
        {
           
                var _Row = _context.FaCategoryThird.Single(n => n.Id == Row_Id);
                


                    _context.FaCategoryThird.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
                
               
         

        }
        //-----------------------------------
        //get function
        public List<FaCategoryThirdGetVM> GetAll() => _context.FaCategoryThird.Select(n => new FaCategoryThirdGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public FaCategoryThirdGetVM GetById(int itemId) => _context.FaCategoryThird.Select(n => new FaCategoryThirdGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);
        //----------------------------------------
        //autocode function
        public string GetLastNo()
        {
            string maxNo = _context.FaCategoryThird

              .Select(item => item.Code)
              .Max();

            if (maxNo == null)
            {
                maxNo = "00";
            }
            int intmaxNo = int.Parse(maxNo);

            intmaxNo = intmaxNo + 1;

            maxNo = intmaxNo.ToString();
            if (maxNo.Length == 1)
            {
                maxNo = "0" + intmaxNo;
            }


            return maxNo;

        }

    }
}
