using Entities.Models.STR;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.StoreOpen
{
    public class StrOpeningStockDetailsSerialRepository
    {
        private AppDbContext _context;
        public StrOpeningStockDetailsSerialRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrOpeningStockDetailsSerialVM ID)
        {
          
                var _Row = new StrOpeningStockDetailsSerial()
                {
                    OpeningStockDetailId = ID.OpeningStockDetailId,
                    ProductSerialId = ID.ProductSerialId,
                    ProductId = ID.ProductId,
                    QTy = ID.QTy,
                    CreatedByID = ID.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrOpeningStockDetailsSerial.Add(_Row);
                _context.SaveChanges();
                return "Succeeded";
         
        }

        public string Update(StrOpeningStockDetailsSerialVM ID)
        {
          
                var _Row = _context.StrOpeningStockDetailsSerial.Single(n => n.Id == ID.Id);
               
                    _Row.OpeningStockDetailId = ID.OpeningStockDetailId;
                    _Row.ProductSerialId = ID.ProductSerialId;
                    _Row.ProductId = ID.ProductId;
                    _Row.QTy = ID.QTy;
                    _Row.UpdateByID = ID.TransactionUserId;
                    _Row.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
               
          
        }

        public string Delete(int ID)
        {
            
                var _Row = _context.StrOpeningStockDetailsSerial.Single(n => n.Id == ID);
               
                    _context.StrOpeningStockDetailsSerial.Remove(_Row);
                    _context.SaveChanges();
                    return "Succeeded";
               
           
        }

        public List<StrOpeningStockDetailsSerialGetVM> GetAll()
            => _context.StrOpeningStockDetailsSerial.Select
                (n => new StrOpeningStockDetailsSerialGetVM
                {
                    Id = n.Id,
                    OpeningStockDetailId = n.OpeningStockDetailId,
                    OpeningStockDetailName = n.OpeningStockDetail.STR_Item.Name,
                    ProductSerialId = n.ProductSerialId,
                    ProductName = n.ProductSerial.Product.Name,
                    ProductId = n.ProductId,
                    QTy = n.QTy,
                    TransactionUserId = n.CreatedBy.Id,
                    CreatorName = n.CreatedBy.Name,
                    EditorName = n.UpdateBy.Name,
                    OpeningStockDetails = n.OpeningStockDetail,
                    ProductSerial = n.ProductSerial
                }).ToList();
        public StrOpeningStockDetailsSerialGetVM GetById(int ID)
            => _context.StrOpeningStockDetailsSerial.Select
                (n => new StrOpeningStockDetailsSerialGetVM
                {
                    Id = n.Id,
                    OpeningStockDetailId = n.OpeningStockDetailId,
                    OpeningStockDetailName = n.OpeningStockDetail.STR_Item.Name,
                    ProductSerialId = n.ProductSerialId,
                    ProductName = n.ProductSerial.Product.Name,
                    ProductId = n.ProductId,
                    QTy = n.QTy,
                    CreatorName = n.CreatedBy.Name,
                    EditorName = n.UpdateBy.Name,
                    OpeningStockDetails = n.OpeningStockDetail,
                    ProductSerial = n.ProductSerial
                }).Single(n => n.Id == ID);
        public List<StrOpeningStockDetailsSerialGetVM> GetByHeader(int ID)
            => _context.StrOpeningStockDetailsSerial
            .Where(n => n.OpeningStockDetailId == ID)
            .Select(n => new StrOpeningStockDetailsSerialGetVM
            {
                Id = n.Id,
                //OpeningStockDetailId = n.OpeningStockDetailId,
                OpeningStockDetailName = n.OpeningStockDetail.STR_Item.Name,
                ProductSerialId = n.ProductSerialId,
                ProductName = n.ProductSerial.Product.Name,
                ProductId = n.ProductId,
                QTy = n.QTy,
                CreatorName = n.CreatedBy.Name,
                EditorName = n.UpdateBy.Name,
                OpeningStockDetails = n.OpeningStockDetail,
                ProductSerial = n.ProductSerial
            }).ToList();
        public List<StrOpeningStockDetailsSerialGetVM> GetByProduct(int ID)
            => _context.StrOpeningStockDetailsSerial
            .Where(n => n.ProductSerialId == ID)
            .Select(n => new StrOpeningStockDetailsSerialGetVM
            {
                Id = n.Id,
                OpeningStockDetailId = n.OpeningStockDetailId,
                OpeningStockDetailName = n.OpeningStockDetail.STR_Item.Name,
                //ProductSerialId = n.ProductSerialId,
                ProductId = n.ProductId,
                QTy = n.QTy,
                ProductName = n.ProductSerial.Product.Name,
                CreatorName = n.CreatedBy.Name,
                EditorName = n.UpdateBy.Name,
                OpeningStockDetails = n.OpeningStockDetail,
                ProductSerial = n.ProductSerial
            }).ToList();
    }
}
