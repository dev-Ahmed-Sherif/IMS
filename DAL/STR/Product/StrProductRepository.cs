using DAL.Helpers;
using Entities.Enums;
using Entities.Models.STR.Product;
using Entities.ViewModels.STR.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.STR.Product
{
    public class StrProductRepository
    {
        private AppDbContext _context;

        public StrProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public int GetLastNo()
        {
            int maxNo = _context.StrProduct
             .Select(item => item.Code).DefaultIfEmpty()
             .Max();
            if (maxNo == 0)
            {
                maxNo = 1;
            }
            else
            {
                // int intmaxNo = int.Parse(maxNo);
                maxNo = maxNo + 1;
                //maxNo = intmaxNo.ToString();
            }
            return maxNo;

            // string maxNo = _context.StrItem.Select(n => new StrItem { No = n.No }).MaxAsync(n => n.GroupId == GroupId);
            //var maxNo = from item in StrItem where( item=> item.GroupId == GroupId ) select item.No;

        }

        //public string AddSTR_product(StrProductVM sTR_product)
        //{
        //    try
        //    {
        //        var _sTR_product = new StrProduct()
        //        {
        //            Name = sTR_product.Name,
        //            Attachment = sTR_product.Attachment,
        //            Code=sTR_product.Code,
        //            ItemId = sTR_product.ItemId,
        //            VendorId = sTR_product.VendorId,
        //            ModelId = sTR_product.ModelId,

        //            CreatedByID = sTR_product.TransactionUserId,
        //            CreationDate = DateTime.Now

        //        };
        //        _context.StrProduct.Add(_sTR_product);
        //        _context.SaveChanges();
        //        return _sTR_product.Id.ToString();
        //    }

        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}
        public async Task<string> Add(StrProductVM sTR_product)
        {
          
                bool exists = _context.StrProduct.Any(s => s.Name == sTR_product.Name);
                if (exists)
                {
                    return " Name already exists.";
                }
                string fileName = await FileHelper.UploadFile(sTR_product.File, FileHelper.GetDirectoryName(DirectoriesEnum.STRProduct));
                var _sTR_product = new StrProduct()
                {
                    Name = sTR_product.Name,
                    //Attachment = UploadFile(sTR_product.FilePath),
                    Attachment = fileName,
                    ItemId = sTR_product.ItemId,
                    VendorId = sTR_product.VendorId,
                    ModelId = sTR_product.ModelId,
                    Code = GetLastNo(),
                    CreatedByID = sTR_product.TransactionUserId,
                    CreationDate = DateTime.Now,
                };
                //if (sTR_product.FilePath != null)
                //{
                //    string filePath = UploadFile(sTR_product.FilePath); // Replace 'UploadFile' with your file upload method
                //    _sTR_product.Attachment = filePath; // Assuming 'FilePath' is the property in the 'StrProduct' class to store the file path
                //}

                _context.StrProduct.Add(_sTR_product);
                _context.SaveChanges();
                return _sTR_product.Id.ToString();
           
        }

        public async Task<string> Update(StrProductVM sTR_product)
        {
            

                bool exists = _context.StrProduct.Any(s => s.Name == sTR_product.Name && s.Id != sTR_product.Id);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _sTR_product = _context.StrProduct.Single(n => n.Id == sTR_product.Id);
               
                    _sTR_product.Name = sTR_product.Name;
                    _sTR_product.Attachment = await FileHelper.UploadFile(sTR_product.File, FileHelper.GetDirectoryName(DirectoriesEnum.STRProduct));
                    _sTR_product.Code = sTR_product.Code;
                    _sTR_product.ItemId = sTR_product.ItemId;
                    _sTR_product.VendorId = sTR_product.VendorId;
                    _sTR_product.ModelId = sTR_product.ModelId;

                    _sTR_product.UpdateByID = sTR_product.TransactionUserId;
                    _sTR_product.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
                
           
        }

        public string Delete(int sTR_Product_Id)
        {
          
                var _sTR_product = _context.StrProduct.Single(n => n.Id == sTR_Product_Id);
               
                    _context.StrProduct.Remove(_sTR_product);
                    _context.SaveChanges();
                    return "Succeeded";
               
          
        }

        public List<StrProductGetVM> GetAll() => _context.StrProduct.Select(
            n => new StrProductGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                Attachment = n.Attachment,
                ItemId = n.ItemId,
                ItemName = n.Item.Name,
                VendorId = n.VendorId,
                VendorName = n.Vendor.Name,
                ModelId = n.ModelId,
                ModelName = n.Model.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();

        public StrProductGetVM GetById(int sTR_ProdectId) => _context.StrProduct.Select(
            n => new StrProductGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                Attachment = n.Attachment,
                ItemId = n.ItemId,
                ItemName = n.Item.Name,
                VendorId = n.VendorId,
                VendorName = n.Vendor.Name,
                ModelId = n.ModelId,
                ModelName = n.Model.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedByID
            }).Single(n => n.Id == sTR_ProdectId);
        public List<StrProductGetVM> GetByName(string ProductName)
        {
            return _context.StrProduct
                .Where(n => n.Name.Contains(ProductName))
                .Select(n => new StrProductGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Attachment = "http://ims.aswan.gov.eg/" + n.Attachment,
                    Code = n.Code,
                    ItemId = n.ItemId,
                    ItemName = n.Item.Name,
                    VendorId = n.VendorId,
                    VendorName = n.Vendor.Name,
                    ModelId = n.ModelId,
                    ModelName = n.Model.Name
                })
               .ToList();
        }
        //public string UploadFile(IFormFile file)
        //{
        //    string uniqueFileName = null;
        //    string filePath = null;
        //    if (file != null && file.Length > 0)
        //    {
        //        string[] allowedFileTypes = { "image/jpeg", "image/png", "application/pdf" };
        //        // Generate a unique file name to avoid naming conflicts
        //        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
        //        string fileExtension = Path.GetExtension(file.FileName);
        //        uniqueFileName = $"{fileName}_{DateTime.Now.Ticks}{fileExtension}";

        //        // Set the path where the file will be stored
        //        string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        //        filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //        // Create the directory if it doesn't exist
        //        if (!Directory.Exists(uploadsFolder))
        //        {
        //            Directory.CreateDirectory(uploadsFolder);
        //        }

        //        // Save the file to the specified path
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            file.CopyTo(fileStream);
        //        }
        //    }

        //    return filePath;
        //}

    }
}


