using Entities.Models.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PY
{
    public class PyItemGroupEmployeeRepository
    {
        private AppDbContext _context;
        public PyItemGroupEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(PyItemGroupEmployeeVM ItemGroupEmployee)
        {
         
                var _PyItemGroupEmployee = new PyItemGroupEmployee()
                {
                    EmployeeId = ItemGroupEmployee.EmployeeId,
                    ItemGroupId = ItemGroupEmployee.ItemGroupId,
                    CreatedByID = ItemGroupEmployee.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PyItemGroupEmployee.Add(_PyItemGroupEmployee);
                _context.SaveChanges();
                return "Succeeded";
           
        }
        public string Update(PyItemGroupEmployeeVM ItemGroupEmployee)
        {
           
                var _ItemGroupEmployee = _context.PyItemGroupEmployee.Single(n => n.Id == ItemGroupEmployee.Id);
               _ItemGroupEmployee.EmployeeId = ItemGroupEmployee.EmployeeId;
                    _ItemGroupEmployee.ItemGroupId = ItemGroupEmployee.ItemGroupId;

                    _ItemGroupEmployee.UpdateByID = ItemGroupEmployee.TransactionUserId;
                    _ItemGroupEmployee.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        public string Delete(int ItemGroupEmployeeId)
        {
          
                var _ItemGroupEmployee = _context.PyItemGroupEmployee.Single(n => n.Id == ItemGroupEmployeeId);
              
                    _context.PyItemGroupEmployee.Remove(_ItemGroupEmployee);
                    _context.SaveChanges();
                    return "Succeeded";
             
        }
        //--------------------------------
        // GET ALL { Data For All Users } 
        //--------------------------------
        public List<PyItemGroupEmployeeGetVM> GetAll()
            => _context.PyItemGroupEmployee.Select(
                n => new PyItemGroupEmployeeGetVM
                {
                    Id = n.Id,
                    EmployeeId = n.EmployeeId,
                    EmployeeName = n.Employee.Name,
                    ItemGroupId = n.ItemGroupId,
                    PyItemGroupName = n.ItemGroup.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //---------------------------------------------------
        // GET { Data From Table By ID => ItemGroupEmployeeId } 
        //---------------------------------------------------
        public PyItemGroupEmployeeGetVM GetById(int ItemGroupEmployeeId)
            => _context.PyItemGroupEmployee.Select(
                n => new PyItemGroupEmployeeGetVM
                {
                    Id = n.Id,
                    EmployeeId = n.EmployeeId,
                    EmployeeName = n.Employee.Name,
                    ItemGroupId = n.ItemGroupId,
                    PyItemGroupName = n.ItemGroup.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == ItemGroupEmployeeId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<PyItemGroupEmployeeGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.PyItemGroupEmployee.Where(n => n.ItemGroupId == HeaderId).Count();
            List<int> ItemGroupId = _context.PyItemGroupEmployee
                .Where(sus => sus.ItemGroupId == HeaderId)
                .Select(sus => sus.ItemGroupId)
                .ToList();
            List<PyItemGroupEmployeeGetVM> Item = _context.PyItemGroupEmployee
                .Where(n => ItemGroupId.Contains(n.ItemGroupId))
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new PyItemGroupEmployeeGetVM
                {
                    Id = n.Id,
                    EmployeeId = n.EmployeeId,
                    EmployeeName = n.Employee.Name,
                    ItemGroupId = n.ItemGroupId,
                    PyItemGroupName = n.ItemGroup.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<PyItemGroupEmployeeGetVM>
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

        public List<PyItemGroupEmployeeGetVM> GetByHeader(int Id)
          => _context.PyItemGroupEmployee.Where(n => n.ItemGroupId == Id)
                .Select(n => new PyItemGroupEmployeeGetVM
                {
                    //Header
                    ItemGroupId = n.ItemGroupId,
                    PyItemGroupName = n.ItemGroup.Name,
                    HeaderCreateUserName = n.ItemGroup.CreatedBy.Name,
                    //Details
                    Id = n.Id,
                    EmployeeId = n.EmployeeId,
                    EmployeeName = n.Employee.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
    }
}
