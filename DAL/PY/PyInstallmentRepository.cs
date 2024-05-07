using Entities.Models.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.PY
{
    public class PyInstallmentRepository
    {

        private AppDbContext _context;


        public PyInstallmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(PyInstallmentVM Installment)
        {
           
                var _Installment = new PyInstallment()
                {

                    No = Installment.No,
                    Description = Installment.Description,
                    StartDate = Installment.StartDate,
                    Value = Installment.Value,
                    InstallmentValue = Installment.InstallmentValue,
                    InstallmentNo = Installment.InstallmentNo,
                    PaiedSum = Installment.PaiedSum,

                    EmployeeId = Installment.EmployeeId,
                    PyItemId = Installment.PyItemId,

                    CreatedByID = Installment.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.PyInstallment.Add(_Installment);
                _context.SaveChanges();
                return "Succeeded";
           
        }
        public string Update(PyInstallmentVM Installment)
        {
             var _Installment = _context.PyInstallment.Single(n => n.Id == Installment.Id);
               

                    _Installment.No = Installment.No;
                    _Installment.Description = Installment.Description;
                    _Installment.StartDate = Installment.StartDate;
                    _Installment.Value = Installment.Value;
                    _Installment.InstallmentValue = Installment.InstallmentValue;
                    _Installment.InstallmentNo = Installment.InstallmentNo;
                    _Installment.PaiedSum = Installment.PaiedSum;
                    _Installment.EmployeeId = Installment.EmployeeId;
                    _Installment.PyItemId = Installment.PyItemId;







                    _Installment.UpdateByID = Installment.TransactionUserId;
                    _Installment.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
               
         
        }
        public string Delete(int InstallmentId)
        {
           
                var _Installment = _context.PyInstallment.Single(n => n.Id == InstallmentId);
              
                    _context.PyInstallment.Remove(_Installment);
                    _context.SaveChanges();
                    return "Succeeded";
             
           
        }
        //--------------------------------
        // GET ALL { Data For All Users } 
        //--------------------------------
        public List<PyInstallmentGetVM> GetAll()
            => _context.PyInstallment.Select(
                n => new PyInstallmentGetVM
                {
                    Id = n.Id,
                    No = n.No,
                    Description = n.Description,
                    StartDate = n.StartDate,
                    Value = n.Value,
                    InstallmentValue = n.InstallmentValue,
                    InstallmentNo = n.InstallmentNo,
                    PaiedSum = n.PaiedSum,
                    EmployeeId = n.EmployeeId,
                    EmployeeName = n.Employee.Name,
                    PyItemId = n.PyItemId,
                    PyItemName = n.PyItem.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //-----------------------------------------------
        // GET { Data From Table By ID => InstallmentId } 
        //-----------------------------------------------
        public PyInstallmentGetVM GetById(int InstallmentId)
            => _context.PyInstallment.Select(
                n => new PyInstallmentGetVM
                {
                    Id = n.Id,
                    No = n.No,
                    StartDate = n.StartDate,
                    Value = n.Value,
                    InstallmentValue = n.InstallmentValue,
                    InstallmentNo = n.InstallmentNo,
                    PaiedSum = n.PaiedSum,
                    EmployeeId = n.EmployeeId,
                    EmployeeName = n.Employee.Name,
                    PyItemId = n.PyItemId,
                    PyItemName = n.PyItem.Name,
                    Description = n.Description,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == InstallmentId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<PyInstallmentGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.PyInstallment.Count();
            List<PyInstallmentGetVM> Item = _context.PyInstallment
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new PyInstallmentGetVM
                {
                    Id = n.Id,
                    No = n.No,
                    Description = n.Description,
                    StartDate = n.StartDate,
                    Value = n.Value,
                    InstallmentValue = n.InstallmentValue,
                    InstallmentNo = n.InstallmentNo,
                    PaiedSum = n.PaiedSum,
                    EmployeeId = n.EmployeeId,
                    EmployeeName = n.Employee.Name,
                    PyItemId = n.PyItemId,
                    PyItemName = n.PyItem.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<PyInstallmentGetVM>
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
    }
}
