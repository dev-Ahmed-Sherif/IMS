using Entities.Models.STR.Product;
using Entities.ViewModels.STR.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.Product
{
    public class StrProductSerialRepository
    {
        private AppDbContext _context;

        public StrProductSerialRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(StrProductSerialGeneralVM sTR_productserial)
        {

            
                bool exists = _context.StrProductSerial.Any(s => s.Serial == sTR_productserial.Serial);
                if (exists)
                {
                    return "productserial already exists.";
                }
                var _sTR_productserial = new StrProductSerial()
                {
                    Serial = sTR_productserial.Serial,
                    ProductionDate = sTR_productserial.ProductionDate,
                    ExpireDate = sTR_productserial.ExpireDate,
                    ProductId = sTR_productserial.ProductId,
                    CreatedByID = sTR_productserial.TransactionUserId,
                    CreationDate = DateTime.Now,

                };
                _context.StrProductSerial.Add(_sTR_productserial);
                _context.SaveChanges();
                return _sTR_productserial.Id.ToString();

           
        }

        public string Update(StrProductSerialVM sTR_productserial)
        {
          
                bool exists = _context.StrProductSerial.Any(s => s.Serial == sTR_productserial.Serial && s.Id != sTR_productserial.Id);
                if (exists)
                {
                    return "productserial already exists.";
                }

                var _sTR_productserial = _context.StrProductSerial.Single(n => n.Id == sTR_productserial.Id);
               
                    _sTR_productserial.Serial = sTR_productserial.Serial;
                    _sTR_productserial.ProductionDate = sTR_productserial.ProductionDate;
                    _sTR_productserial.ExpireDate = sTR_productserial.ExpireDate;
                    _sTR_productserial.ProductId = sTR_productserial.ProductId;
                    _sTR_productserial.CreatedByID = sTR_productserial.TransactionUserId;
                    _sTR_productserial.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
             
           
        }

        public string Delete(int sTR_productserialId)
        {
               var _sTR_productserial = _context.StrProductSerial.Single(n => n.Id == sTR_productserialId);
              
                    _context.StrProductSerial.Remove(_sTR_productserial);
                    _context.SaveChanges();
                    return "Succeeded";
               
           
        }

        public List<StrProductSerialGetVM> GetAll() => _context.StrProductSerial.Select(n => new StrProductSerialGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, Serial = n.Serial, ProductionDate = n.ProductionDate, ExpireDate = n.ExpireDate, ProductName = n.Product.Name, ProductId = n.ProductId, }).ToList();
        public StrProductSerialGetVM GetById(int sTR_productserialId) => _context.StrProductSerial.Select(n => new StrProductSerialGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, Serial = n.Serial, ProductionDate = n.ProductionDate, ExpireDate = n.ExpireDate, ProductName = n.Product.Name, ProductId = n.ProductId }).Single(n => n.Id == sTR_productserialId);

        // Add_Details













    }
}
