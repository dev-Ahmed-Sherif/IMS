using Entities.Models.Fa;
using Entities.ViewModels.Fa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Fa
{
    public class FaCategoryFirstRepository
    {
        private AppDbContext _context;

        public FaCategoryFirstRepository(AppDbContext context)
        {
            _context = context;
        }
        //---------------------------------------------
        //add function
        public string Add(FaCategoryFirstGeneralVM facat1)
        {
         
                var _facat1 = new FaCategoryFirst()
                {
                    Name = facat1.Name,

                    Code = facat1.Code,

                    CreatedByID = facat1.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.FaCategoryFirst.Add(_facat1);
                _context.SaveChanges();
                return _facat1.Id.ToString();
           
        }
        //-----------------------------------------------
        //update function
        public string Update(FaCategoryFirstVM fa_cat1)
        {
          
                var _fa_cat1 = _context.FaCategoryFirst.Single(n => n.Id == fa_cat1.Id);
              
                    _fa_cat1.Name = fa_cat1.Name;
                    fa_cat1.Code = fa_cat1.Code;
                    _fa_cat1.UpdateByID = fa_cat1.TransactionUserId;
                    _fa_cat1.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
              
        }

        //--------------------------------------------
        //delet function

        public string Delete(int FaCategoryFirst_Id)
        {
            try
            {
                var _FaCategoryFirst = _context.FaCategoryFirst.FirstOrDefault(n => n.Id == FaCategoryFirst_Id);
                if (_FaCategoryFirst != null)
                {


                    _context.FaCategoryFirst.Remove(_FaCategoryFirst);
                    _context.SaveChanges();
                    return "Succeeded";
                }
                else
                {
                    return "nothing to be deleted";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
        //-----------------------------------
        //get function
        public List<FaCategoryFirstGetVM> GetAll() => _context.FaCategoryFirst.Select(n => new FaCategoryFirstGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public FaCategoryFirstGetVM GetById(int itemId) => _context.FaCategoryFirst.Select(n => new FaCategoryFirstGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == itemId);
        //----------------------------------------
        //autocode function
        public string GetLastNo()
        {
            int maxNo = _context.FaCategoryFirst
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
