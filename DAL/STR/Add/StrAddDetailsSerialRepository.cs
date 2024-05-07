using Entities.Models.STR.Add;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.Add
{
    public class StrAddDetailsSerialRepository
    {
        private AppDbContext _context;
        public StrAddDetailsSerialRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrAddDetailsSerialVM ID)
        {

            var _Row = new StrAddDetailsSerial()
            {
                AddDetailsId = ID.AddDetailsId,
                ProductSerialId = ID.ProductSerialId,
                ProductId = ID.ProductId,
                QTy = ID.QTy,
                CreatedByID = ID.TransactionUserId,
                CreationDate = DateTime.Now
            };
            _context.StrAddDetailsSerial.Add(_Row);
            _context.SaveChanges();
            return "Succeeded";

        }

        public string Update(StrAddDetailsSerialVM ID)
        {

            var _Row = _context.StrAddDetailsSerial.Single(n => n.Id == ID.Id);

            _Row.AddDetailsId = ID.AddDetailsId;
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
            var _Row = _context.StrAddDetailsSerial.Single(n => n.Id == ID);
            _context.StrAddDetailsSerial.Remove(_Row);
            _context.SaveChanges();
            return "Succeeded";
        }

        public List<StrAddDetailsSerialGetVM> GetAll()
            => _context.StrAddDetailsSerial.Select
                (n => new StrAddDetailsSerialGetVM
                {
                    Id = n.Id,
                    AddDetailsId = n.AddDetailsId,
                    ItemName = n.AddDetails.STR_Item.Name,
                    ProductSerialId = n.ProductSerialId,
                    ProductName = n.ProductSerial.Product.Name,
                    ProductId = n.ProductId,
                    QTy = n.QTy,
                    TransactionUserId = n.CreatedBy.Id,
                    CreatorName = n.CreatedBy.Name,
                    EditorName = n.UpdateBy.Name,
                    AddDetails = n.AddDetails,
                    ProductSerial = n.ProductSerial
                }).ToList();
        public StrAddDetailsSerialGetVM GetById(int ID)
            => _context.StrAddDetailsSerial.Select
                (n => new StrAddDetailsSerialGetVM
                {
                    Id = n.Id,
                    AddDetailsId = n.AddDetailsId,
                    ItemName = n.AddDetails.STR_Item.Name,
                    ProductSerialId = n.ProductSerialId,
                    ProductId = n.ProductId,
                    QTy = n.QTy,
                    ProductName = n.ProductSerial.Product.Name,
                    CreatorName = n.CreatedBy.Name,
                    EditorName = n.UpdateBy.Name,
                    AddDetails = n.AddDetails,
                    ProductSerial = n.ProductSerial
                }).Single(n => n.Id == ID);
        public StrAddDetailsSerialGetVM GetByHeader(int ID)
            => _context.StrAddDetailsSerial.Select
                (n => new StrAddDetailsSerialGetVM
                {
                    Id = n.Id,
                    //AddDetailsId = n.AddDetailsId,
                    ItemName = n.AddDetails.STR_Item.Name,
                    ProductSerialId = n.ProductSerialId,
                    ProductName = n.ProductSerial.Product.Name,
                    ProductId = n.ProductId,
                    QTy = n.QTy,
                    CreatorName = n.CreatedBy.Name,
                    EditorName = n.UpdateBy.Name,
                    AddDetails = n.AddDetails,
                    ProductSerial = n.ProductSerial
                }).Single(n => n.AddDetailsId == ID);
        public StrAddDetailsSerialGetVM GetByProduct(int ID)
            => _context.StrAddDetailsSerial.Select
                (n => new StrAddDetailsSerialGetVM
                {
                    Id = n.Id,
                    AddDetailsId = n.AddDetailsId,
                    ItemName = n.AddDetails.STR_Item.Name,
                    //ProductSerialId = n.ProductSerialId,
                    ProductId = n.ProductId,
                    QTy = n.QTy,
                    ProductName = n.ProductSerial.Product.Name,
                    CreatorName = n.CreatedBy.Name,
                    EditorName = n.UpdateBy.Name,
                    AddDetails = n.AddDetails,
                    ProductSerial = n.ProductSerial
                }).Single(n => n.ProductSerialId == ID);
    }
}
