using Entities.Models.STR.WithDraw;
using Entities.ViewModels.STR.WithDraw;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.WithDraw
{
    public class StrWithDrawDetailsSerialRepository
    {
        private AppDbContext _context;

        public StrWithDrawDetailsSerialRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrWithDrawSerialGeneralVM sTR_withdrawdetailsserial)
        {
            
                var _sTR_withdrawdetailsserial = new StrWithDrawDetailsSerial()
                {


                    ProductSerialId = sTR_withdrawdetailsserial.ProductserialId,
                    ProductId = sTR_withdrawdetailsserial.ProductId,
                    QTy = sTR_withdrawdetailsserial.QTy,
                    CreatedByID = sTR_withdrawdetailsserial.TransactionUserId,
                    CreationDate = DateTime.Now,

                };
                _context.StrWithDrawDetailsSerial.Add(_sTR_withdrawdetailsserial);
                _context.SaveChanges();
                return _sTR_withdrawdetailsserial.Id.ToString();

          
        }
        public string Update(StrWithDrawSerialVM sTR_withdrawdetailsserial)
        {
           
                var _sTR_withdrawdetailsserial = _context.StrWithDrawDetailsSerial.Single(n => n.Id == sTR_withdrawdetailsserial.Id);
             
                    _sTR_withdrawdetailsserial.ProductSerialId = sTR_withdrawdetailsserial.ProductserialId;
                    _sTR_withdrawdetailsserial.StrWithDrawDetailsId = sTR_withdrawdetailsserial.strwithdrawdetailsId;
                    _sTR_withdrawdetailsserial.CreatedByID = sTR_withdrawdetailsserial.TransactionUserId;
                    _sTR_withdrawdetailsserial.CreationDate = DateTime.Now;
                    _sTR_withdrawdetailsserial.ProductId = sTR_withdrawdetailsserial.ProductId;
                    _sTR_withdrawdetailsserial.QTy = sTR_withdrawdetailsserial.QTy;
                    _context.SaveChanges();
                    return "Succeeded";
               
          
        }
        public string Delete(int sTR_withdrawdetailsserialId)
        {
          
                var _sTR_withdrawdetailsserial = _context.StrWithDrawDetailsSerial.Single(n => n.Id == sTR_withdrawdetailsserialId);
                
                    _context.StrWithDrawDetailsSerial.Remove(_sTR_withdrawdetailsserial);
                    _context.SaveChanges();
                    return "Succeeded";
               
           
        }
        public List<StrWithDrawSerialGetVM> GetAll() => _context.StrWithDrawDetailsSerial.Select(n => new StrWithDrawSerialGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, ProductserialId = n.ProductSerialId, ProductId = n.ProductId, QTy = n.QTy, strwithdrawdetailsId = n.StrWithDrawDetailsId }).ToList();
        public StrWithDrawSerialGetVM GetById(int sTR_productserialId) => _context.StrWithDrawDetailsSerial.Select(n => new StrWithDrawSerialGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, ProductserialId = n.ProductSerialId, ProductId = n.ProductId, QTy = n.QTy }).FirstOrDefault(n => n.Id == sTR_productserialId);

    }
}
