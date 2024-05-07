using DAL;
using DAL.STR.Product;
using Entities.ViewModels.STR.Product;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.STR.Product
{
    public class StrProductService
    {
        public StrProductRepository _StrproductRepository;
        public StrProductService(StrProductRepository StrProductRepository)
        {
            _StrproductRepository = StrProductRepository;
        }
        public int AutoCode()
        {
            return _StrproductRepository.GetLastNo();
        }
        //public string AddSTR_product(StrProductVM sTR_Product)
        //{
        //    return _StrproductRepository.AddSTR_product(sTR_Product);
        //}
        public async Task<string> Add(StrProductVM sTR_Product)
        {
            return await _StrproductRepository.Add(sTR_Product);
        }


        public async Task<string> Update(StrProductVM sTR_Product)
        {
            return await _StrproductRepository.Update(sTR_Product);
        }

        public string Delete(int sTR_Product_Id)
        {
            return _StrproductRepository.Delete(sTR_Product_Id);
        }

        public List<StrProductGetVM> GetAll()
        {
            return _StrproductRepository.GetAll();
        }

        public StrProductGetVM GetById(int sTR_Product_Id)
        {
            return _StrproductRepository.GetById(sTR_Product_Id);
        }
        public List<StrProductGetVM> GetByName(string ProductName)
        {
            return _StrproductRepository.GetByName(ProductName);
        }
        //public async Task<string> UploadFile(StrProductVM sTR_product)
        //{
        //    return await _StrproductRepository.Add(sTR_product);
        //}
    }
}
