using Entities.Models.Fa;
using Entities.ViewModels.Fa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;

namespace DAL.Fa
{
    public class FaCategorySecondRepository
    {
        private AppDbContext _context;

        public FaCategorySecondRepository(AppDbContext context)
        {
            _context = context;
        }
        //---------------------------------------------
        //add function
        public string Add(FaCategorySecondGeneralVM add)
        {
           
                var _add = new FaCategorySecond()
                {
                    Name = add.Name,

                    Code = add.Code,

                    CreatedByID = add.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.FaCategorySecond.Add(_add);
                _context.SaveChanges();
                return _add.Id.ToString();
           
        }
        //-----------------------------------------------
        //update function
        public string Update(FaCategorySecondVM Update)
        {
            
                var _update = _context.FaCategorySecond.Single(n => n.Id == Update.Id);
             
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
            
                var _Row = _context.FaCategorySecond.Single(n => n.Id == Row_Id);
                


                    _context.FaCategorySecond.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
              

        }
        //-----------------------------------
        //get function
        public List<FaCategorySecondGetVM> GetAll() => _context.FaCategorySecond.Select(n => new FaCategorySecondGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public FaCategorySecondGetVM GetById(int itemId) => _context.FaCategorySecond.Select(n => new FaCategorySecondGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);
        //----------------------------------------
        //autocode function
        public string GetLastNo()
        {
            string maxNo = _context.FaCategorySecond

              .Select(item => item.Code)
              .Max();

            if (maxNo == null)
            {
                maxNo = "000";
            }
            int intmaxNo = int.Parse(maxNo);

            intmaxNo = intmaxNo + 1;

            maxNo = intmaxNo.ToString();
            if (maxNo.Length == 1)
            {
                maxNo = "00" + intmaxNo;
            }
            if (maxNo.Length == 2)
            {
                maxNo = "0" + intmaxNo;
            }

            return maxNo;

        }

    }
}

