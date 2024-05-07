using Entities.Models.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Cc
{
    public class CcEquipmentRepository
    {
        private AppDbContext _context;

        public CcEquipmentRepository(AppDbContext context)
        {
            _context = context;
        }
        //----------------------------------------------
        //add function
        public string Add(CcEquipmentGeneralVM Add)
        {
           
                var _Add = new CcEquipment()
                {
                    Name = Add.Name,

                    Code = Add.Code,
                    CostCenterId = Add.CostCenterId,

                    CreatedByID = Add.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.CcEquipment.Add(_Add);
                _context.SaveChanges();
                return _Add.Id.ToString();
       
        }
        //-----------------------------------------------
        //update function
        public string Update(CcEquipmentVM update)
        {
           
                var _update = _context.CcEquipment.Single(n => n.Id == update.Id);
             
                    _update.Name = update.Name;
                    _update.Code = update.Code;
                    _update.CostCenterId = update.CostCenterId;
                    _update.UpdateByID = update.TransactionUserId;
                    _update.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
              
        }

        //--------------------------------------------
        //delet function

        public string Delete(int dele_Id)
        {
           
                var _dele = _context.CcEquipment.Single(n => n.Id == dele_Id);
               
                    _context.CcEquipment.Remove(_dele);
                    _context.SaveChanges();
                    return "Succeeded";
              

        }
        //-----------------------------------
        //get function
        public List<CcEquipmentGetVM> GetAll()
            => _context.CcEquipment.Select(n => new CcEquipmentGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                CostCenterId = n.CostCenterId,
                CostCenterName = n.CostCenter.Name,
                CostCenterCode = n.CostCenter.Code,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //----------------------------------------------------------
        public PaginatedResult<CcEquipmentGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.CcEquipment.Count();
            List<CcEquipmentGetVM> Item = _context.CcEquipment
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new CcEquipmentGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Code = n.Code,
                    CostCenterId = n.CostCenterId,
                    CostCenterName = n.CostCenter.Name,
                    CostCenterCode = n.CostCenter.Code,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<CcEquipmentGetVM>
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
        public CcEquipmentGetVM GetById(int itemId)
            => _context.CcEquipment.Select(n => new CcEquipmentGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                CostCenterId = n.CostCenterId,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).Single(n => n.Id == itemId);

    }
}
