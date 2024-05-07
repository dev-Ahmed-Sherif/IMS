using Entities.Models.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PY
{
    public class PyItemRepository
    {

        private AppDbContext _context;


        public PyItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(PyItemVM Item)
        {
           
                var _PyItem = new PyItem()
                {
                    Name = Item.name,
                    Code = Item.Code,
                    Manner = Item.Manner,
                    Type = Item.Type,
                    CalcType = Item.CalcType,
                    Value = Item.Value,
                    Round = Item.Round,
                    MinValue = Item.MinValue,
                    MaxValue = Item.MaxValue,
                    Status = Item.Status,
                    Party = Item.Party,
                    ResetType = Item.ResetType,
                    ResetValue = Item.ResetValue,
                    Visibility = Item.Visibility,
                    Equation = Item.Equation,
                    CategoryId = Item.CategoryId,
                    CreatedByID = Item.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PyItem.Add(_PyItem);
                _context.SaveChanges();
                return "Succeeded";
           
        }
        public string Update(PyItemVM Item)
        {
           
                var _Item = _context.PyItem.FirstOrDefault(n => n.Id == Item.Id);
             
                    _Item.Name = Item.name;
                    _Item.Code = Item.Code;
                    _Item.Manner = Item.Manner;
                    _Item.Type = Item.Type;
                    _Item.CalcType = Item.CalcType;
                    _Item.Value = Item.Value;
                    _Item.Round = Item.Round;
                    _Item.MinValue = Item.MinValue;
                    _Item.MaxValue = Item.MaxValue;
                    _Item.Status = Item.Status;
                    _Item.Party = Item.Party;
                    _Item.ResetType = Item.ResetType;
                    _Item.ResetValue = Item.ResetValue;
                    _Item.Visibility = Item.Visibility;
                    _Item.Equation = Item.Equation;
                    _Item.CategoryId = Item.CategoryId;


                    _Item.UpdateByID = Item.TransactionUserId;
                    _Item.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        public string Delete(int ItemId)
        {
         
                var _Item = _context.PyItem.Single(n => n.Id == ItemId);
              
                    _context.PyItem.Remove(_Item);
                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        //--------------------------------
        // GET ALL { Data For All Users } 
        //--------------------------------
        public List<PyItemGetVM> GetAll()
            => _context.PyItem.Select(
                n => new PyItemGetVM
                {
                    Id = n.Id,
                    name = n.Name,
                    Code = n.Code,
                    Manner = n.Manner,
                    Type = n.Type,
                    CategoryId = n.CategoryId,
                    CategoryName = n.Category.Name,
                    CalcType = n.CalcType,
                    Value = n.Value,
                    Round = n.Round,
                    MinValue = n.MinValue,
                    MaxValue = n.MaxValue,
                    Status = n.Status,
                    Party = n.Party,
                    ResetType = n.ResetType,
                    ResetValue = n.ResetValue,
                    Visibility = n.Visibility,
                    Equation = n.Equation,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //---------------------------------------------------
        // GET { Data From Table By ID => ItemId } 
        //---------------------------------------------------
        public PyItemGetVM GetById(int ItemId)
            => _context.PyItem.Select(
                n => new PyItemGetVM
                {
                    Id = n.Id,
                    name = n.Name,
                    Code = n.Code,
                    Manner = n.Manner,
                    Type = n.Type,
                    CategoryId = n.CategoryId,
                    CategoryName = n.Category.Name,
                    CalcType = n.CalcType,
                    Value = n.Value,
                    Round = n.Round,
                    MinValue = n.MinValue,
                    MaxValue = n.MaxValue,
                    Status = n.Status,
                    Party = n.Party,
                    ResetType = n.ResetType,
                    ResetValue = n.ResetValue,
                    Visibility = n.Visibility,
                    Equation = n.Equation,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == ItemId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<PyItemGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.PyItem.Count();
            List<PyItemGetVM> Item = _context.PyItem
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new PyItemGetVM
                {
                    Id = n.Id,
                    name = n.Name,
                    Code = n.Code,
                    Manner = n.Manner,
                    Type = n.Type,
                    CategoryId = n.CategoryId,
                    CategoryName = n.Category.Name,
                    CalcType = n.CalcType,
                    Value = n.Value,
                    Round = n.Round,
                    MinValue = n.MinValue,
                    MaxValue = n.MaxValue,
                    Status = n.Status,
                    Party = n.Party,
                    ResetType = n.ResetType,
                    ResetValue = n.ResetValue,
                    Visibility = n.Visibility,
                    Equation = n.Equation,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<PyItemGetVM>
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

        public List<PyItemGetVM> GetByHeader(int Id)
          => _context.PyItem.Where(n => n.CategoryId == Id)
                .Select(n => new PyItemGetVM
                {
                    //Header
                    CategoryId = n.CategoryId,
                    CategoryName = n.Category.Name,
                    HeaderCreateUserName = n.CreatedBy.Name,
                    //Details
                    Id = n.Id,
                    name = n.Name,
                    Code = n.Code,
                    Manner = n.Manner,
                    Type = n.Type,
                    CalcType = n.CalcType,
                    Value = n.Value,
                    Round = n.Round,
                    MinValue = n.MinValue,
                    MaxValue = n.MaxValue,
                    Status = n.Status,
                    Party = n.Party,
                    ResetType = n.ResetType,
                    ResetValue = n.ResetValue,
                    Visibility = n.Visibility,
                    Equation = n.Equation,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
    }
}

