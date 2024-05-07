using Entities.Models.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities.ViewModels;
namespace DAL.Cc
{
    public class CcActivityRepository
    {
        private readonly AppDbContext _context;
        public CcActivityRepository(AppDbContext context)
        {
            _context = context;
        }
        //----------------------------------------------
        //GetLastNo function
        public string GetLastNo()
        {

            string maxNo = _context.CcActivity
            .Select(item => item.Code)
            .Max() ?? "0";

            int intmaxNo = int.Parse(maxNo);

            intmaxNo++;

            maxNo = intmaxNo.ToString();

            if (maxNo.Length == 1)
            {
                maxNo = "0" + intmaxNo;
            }

            return maxNo.ToString();
        }

        //----------------------------------------------
        //add function
        public string Add(CcActivityGeneralVM ccact)
        {

            var _ccact = new CcActivity()
            {
                Name = ccact.Name,
                Code = ccact.Code,
                CreatedByID = ccact.TransactionUserId,
                CreationDate = DateTime.Now
            };
            _context.CcActivity.Add(_ccact);
            _context.SaveChanges();
            return _ccact.Id.ToString();

        }
        //-----------------------------------------------
        //update function
        public string Update(CcActivityVM cc_act)
        {

            var _cc_act = _context.CcActivity.First(n => n.Id == cc_act.Id);

            _cc_act.Name = cc_act.Name;
            _cc_act.Code = cc_act.Code;
            _cc_act.UpdateByID = cc_act.TransactionUserId;
            _cc_act.CreationDate = DateTime.Now;
            _context.SaveChanges();
            return "Succeeded";

        }

        //--------------------------------------------
        //delet function

        public string Delete(int CcActivity_Id)
        {

            var _CcActivity = _context.CcActivity.First(n => n.Id == CcActivity_Id);

            var DetailsToDelete = _context.CcActivity.Where(n => n.Id == CcActivity_Id).ToList();
            _context.CcActivity.Remove(_CcActivity);
            _context.SaveChanges();
            return "Succeeded";
        }
        //-----------------------------------
        //get function
        public List<CcActivityGetVM> GetAll()
        {
            var result = _context.CcActivity.Select(n => new CcActivityGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();

            return result;
        }

        public CcActivityGetVM GetById(int itemId)
            => _context.CcActivity.Select(n => new CcActivityGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).FirstOrDefault(n => n.Id == itemId);

        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<CcActivityGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.CcActivity.Count();
            List<CcActivityGetVM> Item = _context.CcActivity
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new CcActivityGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<CcActivityGetVM>
            {
                Items = Item,
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };

            return paginatedResult;
        }
    }
}
