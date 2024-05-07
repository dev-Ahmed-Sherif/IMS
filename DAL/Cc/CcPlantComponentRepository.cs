using Entities.Models.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Cc
{
    public class CcPlantComponentRepository
    {
        private AppDbContext _context;
        public CcPlantComponentRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------------------------
        //autocode function
        public string GetLastNo()
        {
            int maxNo = _context.CcPlantComponent
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
        //----------------------------------------------
        //add function
        public string Add(CcPlantComponentGeneralVM Add)
        {
           
                var _Add = new CcPlantComponent()
                {
                    Name = Add.Name,

                    Code = Add.Code,
                    CreatedByID = Add.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.CcPlantComponent.Add(_Add);
                _context.SaveChanges();
                return _Add.Id.ToString();
           
        }
        //-----------------------------------------------
        //update function
        public string Update(CcPlantComponentVM update)
        {
            
                var _update = _context.CcPlantComponent.Single(n => n.Id == update.Id);
             
                    _update.Name = update.Name;
                    _update.Code = update.Code;
                    _update.UpdateByID = update.TransactionUserId;
                    _update.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
               
           
        }

        //--------------------------------------------
        //delet function

        public string Delete(int dele_Id)
        {
           
                var _dele = _context.CcPlantComponent.Single(n => n.Id == dele_Id);
               
                    var DetailsToDelete = _context.CcCostCenter.Where(p => p.PlantComponentId == dele_Id).ToList();
                    if (DetailsToDelete != null)
                    {
                        _context.CcCostCenter.RemoveRange(DetailsToDelete);
                        _context.SaveChanges();
                    }
                    _context.CcPlantComponent.Remove(_dele);
                    _context.SaveChanges();
                    return "Succeeded";
             

        }
        //-----------------------------------
        //get function
        public List<CcPlantComponentGetVM> GetAll()
            => _context.CcPlantComponent.Select(n => new CcPlantComponentGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<CcPlantComponentGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.CcPlantComponent.Count();
            List<CcPlantComponentGetVM> Item = _context.CcPlantComponent
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new CcPlantComponentGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<CcPlantComponentGetVM>
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
        public CcPlantComponentGetVM GetById(int itemId) => _context.CcPlantComponent.Select(n => new CcPlantComponentGetVM { Id = n.Id, Name = n.Name, Code = n.Code, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == itemId);

    }
}
