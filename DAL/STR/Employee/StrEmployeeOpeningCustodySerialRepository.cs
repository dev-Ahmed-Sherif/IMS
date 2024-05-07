using Entities.Models.STR;
using Entities.ViewModels.STR.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.Employee
{
    public class StrEmployeeOpeningCustodySerialRepository
    {
        private AppDbContext _context;
        public StrEmployeeOpeningCustodySerialRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrEmployeeOpeningCustodySerialVM ID)
        {
            
                var _Row = new StrEmployeeOpeningCustodySerial()
                {
                    EmployeeOpeningCustodyDetailId = ID.EmployeeOpeningCustodyDetailId,
                    ProductSerialId = ID.ProductSerialId,
                    ProductId = ID.ProductId,
                    QTy = ID.QTy,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrEmployeeOpeningCustodySerial.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
           
        }

        public string Update(StrEmployeeOpeningCustodySerialVM ID)
        {
           
            var _Row = _context.StrEmployeeOpeningCustodySerial.Single(n => n.Id == ID.Id);
              
                    _Row.EmployeeOpeningCustodyDetailId = ID.EmployeeOpeningCustodyDetailId;
                    _Row.ProductSerialId = ID.ProductSerialId;
                    _Row.ProductId = ID.ProductId;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
            
           
        }

        public string Delete(int ID)
        {
           
                var _Row = _context.StrEmployeeOpeningCustody.Single(n => n.Id == ID);
              
                    _context.StrEmployeeOpeningCustody.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
                
            
        
        }

        public List<StrEmployeeOpeningCustodySerialGetVM> GetAll()
            => _context.StrEmployeeOpeningCustodySerial.Select
            (n => new StrEmployeeOpeningCustodySerialGetVM
            {
                Id = n.Id,
                EmployeeOpeningCustodyDetailId = n.EmployeeOpeningCustodyDetailId,
                EmployeeOpeningCustodyName = n.EmployeeOpeningCustodyDetail.STR_Employee_Opening_Custody.HR_Employee.Name,
                ProductSerialId = n.ProductSerialId,
                ProductId = n.ProductId,
                QTy = n.QTy,
                ProductName = n.ProductSerial.Product.Name,
                TransactionUserId = n.CreatedBy.Id,
                CreatorName = n.CreatedBy.Name,
                EditorName = n.UpdateBy.Name,
                OpeningCustodyDetails = n.EmployeeOpeningCustodyDetail,
                ProductSerial = n.ProductSerial
            }).ToList();
        public StrEmployeeOpeningCustodySerialGetVM GetById(int ID)
            => _context.StrEmployeeOpeningCustodySerial.Select
            (n => new StrEmployeeOpeningCustodySerialGetVM
            {
                Id = n.Id,
                EmployeeOpeningCustodyDetailId = n.EmployeeOpeningCustodyDetailId,
                EmployeeOpeningCustodyName = n.EmployeeOpeningCustodyDetail.STR_Employee_Opening_Custody.HR_Employee.Name,
                ProductSerialId = n.ProductSerialId,
                ProductId = n.ProductId,
                QTy = n.QTy,
                ProductName = n.ProductSerial.Product.Name,
                CreatorName = n.CreatedBy.Name,
                EditorName = n.UpdateBy.Name,
                OpeningCustodyDetails = n.EmployeeOpeningCustodyDetail,
                ProductSerial = n.ProductSerial
            }).Single(n => n.Id == ID);
        public List<StrEmployeeOpeningCustodySerialGetVM> GetByHeader(int ID)
            => _context.StrEmployeeOpeningCustodySerial
            .Where(n => n.EmployeeOpeningCustodyDetailId == ID)
            .Select(n => new StrEmployeeOpeningCustodySerialGetVM
            {
                Id = n.Id,
                //EmployeeOpeningCustodyDetailId = n.EmployeeOpeningCustodyDetailId,
                EmployeeOpeningCustodyName = n.EmployeeOpeningCustodyDetail.STR_Employee_Opening_Custody.HR_Employee.Name,
                ProductSerialId = n.ProductSerialId,
                ProductId = n.ProductId,
                QTy = n.QTy,
                ProductName = n.ProductSerial.Product.Name,
                CreatorName = n.CreatedBy.Name,
                EditorName = n.UpdateBy.Name,
                OpeningCustodyDetails = n.EmployeeOpeningCustodyDetail,
                ProductSerial = n.ProductSerial
            }).ToList();
        public List<StrEmployeeOpeningCustodySerialGetVM> GetByProduct(int ID)
            => _context.StrEmployeeOpeningCustodySerial
            .Where(n => n.ProductSerialId == ID)
            .Select(n => new StrEmployeeOpeningCustodySerialGetVM
            {
                Id = n.Id,
                EmployeeOpeningCustodyDetailId = n.EmployeeOpeningCustodyDetailId,
                EmployeeOpeningCustodyName = n.EmployeeOpeningCustodyDetail.STR_Employee_Opening_Custody.HR_Employee.Name,
                //ProductSerialId = n.ProductSerialId,
                ProductName = n.ProductSerial.Product.Name,
                ProductId = n.ProductId,
                QTy = n.QTy,
                CreatorName = n.CreatedBy.Name,
                EditorName = n.UpdateBy.Name,
                OpeningCustodyDetails = n.EmployeeOpeningCustodyDetail,
                ProductSerial = n.ProductSerial
            }).ToList();
    }
}
