using Entities.Models.STR;
using Entities.ViewModels.STR.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.Employee
{
    public class StrEmployeeExchangeSerialRepository
    {
        private AppDbContext _context;
        public StrEmployeeExchangeSerialRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrEmployeeExchangeSerialVM ID)
        {
            
                var _Row = new StrEmployeeExchangeSerial()
                {
                    EmployeeExchangeDetailId = ID.EmployeeExchangeDetailId,
                    ProductSerialId = ID.ProductSerialId,
                    ProductId = ID.ProductId,
                    QTy = ID.QTy,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrEmployeeExchangeSerial.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
           
        }

        public string Update(StrEmployeeExchangeSerialVM ID)
        {
        
                var _Row = _context.StrEmployeeExchangeSerial.Single(n => n.Id == ID.Id);
               
                    _Row.EmployeeExchangeDetailId = ID.EmployeeExchangeDetailId;
                    _Row.ProductSerialId = ID.ProductSerialId;
                    _Row.ProductId = ID.ProductId;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
               
               
          
        }

        public string Delete(int ID)
        {
              var _Row = _context.StrEmployeeExchangeDetails.Single(n => n.Id == ID);
                 _context.StrEmployeeExchangeDetails.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
              
        }

        public List<StrEmployeeExchangeSerialGetVM> GetAll() => _context.StrEmployeeExchangeSerial.Select(n => new StrEmployeeExchangeSerialGetVM { Id = n.Id, EmployeeExchangeDetailId = n.EmployeeExchangeDetailId, EmployeeExchangeName = n.EmployeeExchangeDetail.STR_Employee_Exchange.Employee.Name, ProductId = n.ProductId, QTy = n.QTy, ProductSerialId = n.ProductSerialId, ProductName = n.ProductSerial.Product.Name, CreatorName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, EditorName = n.UpdateBy.Name, ExchangeDetails = n.EmployeeExchangeDetail, ProductSerial = n.ProductSerial }).ToList();
        public StrEmployeeExchangeSerialGetVM GetById(int ID) => _context.StrEmployeeExchangeSerial.Select(n => new StrEmployeeExchangeSerialGetVM { Id = n.Id, EmployeeExchangeDetailId = n.EmployeeExchangeDetailId, EmployeeExchangeName = n.EmployeeExchangeDetail.STR_Employee_Exchange.Employee.Name, ProductId = n.ProductId, QTy = n.QTy, ProductSerialId = n.ProductSerialId, ProductName = n.ProductSerial.Product.Name, CreatorName = n.CreatedBy.Name, EditorName = n.UpdateBy.Name, ExchangeDetails = n.EmployeeExchangeDetail, ProductSerial = n.ProductSerial }).FirstOrDefault(n => n.Id == ID);
        public List<StrEmployeeExchangeSerialGetVM> GetByHeader(int ID)
            => _context.StrEmployeeExchangeSerial
            .Where(n => n.EmployeeExchangeDetailId == ID)
            .Select(n => new StrEmployeeExchangeSerialGetVM
            {
                Id = n.Id,
                //EmployeeExchangeDetailId = n.EmployeeExchangeDetailId,
                EmployeeExchangeName = n.EmployeeExchangeDetail.STR_Employee_Exchange.Employee.Name,
                ProductSerialId = n.ProductSerialId,
                ProductName = n.ProductSerial.Product.Name,
                CreatorName = n.CreatedBy.Name,
                EditorName = n.UpdateBy.Name,
                ExchangeDetails = n.EmployeeExchangeDetail,
                ProductSerial = n.ProductSerial
            }).ToList();
        public List<StrEmployeeExchangeSerialGetVM> GetByProduct(int ID)
            => _context.StrEmployeeExchangeSerial
            .Where(n => n.ProductSerialId == ID)
            .Select(n => new StrEmployeeExchangeSerialGetVM
            {
                Id = n.Id,
                EmployeeExchangeDetailId = n.EmployeeExchangeDetailId,
                EmployeeExchangeName = n.EmployeeExchangeDetail.STR_Employee_Exchange.Employee.Name,
                //ProductSerialId = n.ProductSerialId,
                ProductName = n.ProductSerial.Product.Name,
                CreatorName = n.CreatedBy.Name,
                EditorName = n.UpdateBy.Name,
                ExchangeDetails = n.EmployeeExchangeDetail,
                ProductSerial = n.ProductSerial
            }).ToList();
    }
}
