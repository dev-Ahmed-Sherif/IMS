using Entities.Models.TR.Excuted;
using Entities.ViewModels.FI.Entry;
using Entities.ViewModels.TR.Excuted;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Excuted
{
    public class TrExcutedFinancierRepository
    {
        private AppDbContext _context;
        public TrExcutedFinancierRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(TrExcutedFinancierGeneralVM Inst)
        {
           
                var _Inst = new TrExcutedFinancier()
                {

                    ExcutedId = Inst.ExcutedId,
                    FinancierId = Inst.FinancierId,
                    CreatedByID = Inst.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrExcutedFinancier.Add(_Inst);
                _context.SaveChanges();
                return _Inst.Id.ToString();

           
        }
        public string Update(TrExcutedFinancierVM Inst)
        {
            
                var _item = _context.TrExcutedFinancier.FirstOrDefault(n => n.Id == Inst.Id);
             


                    _item.ExcutedId = Inst.ExcutedId;
                    _item.FinancierId = Inst.FinancierId;


                    _item.UpdateByID = Inst.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
              
           
        }
        public string Delete(int InstId)
        {
           
                var _receipt = _context.TrExcutedFinancier.Single(n => n.Id == InstId);
               


                    _context.TrExcutedFinancier.Remove(_receipt);
                    _context.SaveChanges();
                    return "Succeeded";
              

        }
        public List<TrExcutedFinancierGetVM> GetAll()
            => _context.TrExcutedFinancier.Select(n => new TrExcutedFinancierGetVM
            {
                Id = n.Id,
                ExcutedId = n.ExcutedId,
                FinancierId = n.FinancierId,
                FinancierName = n.Financier.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<TrExcutedFinancierGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.TrExcutedFinancier.Where(n => n.ExcutedId == HeaderId).Count();

            if (totalCount == 0)
            {
                return new PaginatedResult<TrExcutedFinancierGetVM>
                {
                    Items = new List<TrExcutedFinancierGetVM>(),
                    TotalItems = 0,
                    Page = page,
                    PageSize = pageSize
                };
            }
            List<int> TrExcuted = _context.TrExcutedFinancier
                   .Where(sus => sus.ExcutedId == HeaderId)
                   .Select(sus => sus.ExcutedId)
                   .ToList();
            List<TrExcutedFinancierGetVM> Item = _context.TrExcutedFinancier
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrExcutedFinancierGetVM
                {
                    Id = n.Id,
                    ExcutedId = n.ExcutedId,
                    FinancierId = n.FinancierId,
                    FinancierName = n.Financier.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrExcutedFinancierGetVM>
            {
                Items = Item,
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };

            return paginatedResult;
        }
        public class PaginatedResult<T>
        {
            public List<T> Items { get; set; }
            public int TotalItems { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
        }
        public TrExcutedFinancierGetVM GetById(int itemId)
            => _context.TrExcutedFinancier.Select(n => new TrExcutedFinancierGetVM
            {
                Id = n.Id,
                ExcutedId = n.ExcutedId,
                FinancierId = n.FinancierId,
                FinancierName = n.Financier.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).Single(n => n.Id == itemId);
       
    }
}
