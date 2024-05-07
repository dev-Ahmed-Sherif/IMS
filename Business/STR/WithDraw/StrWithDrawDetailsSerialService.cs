using DAL;
using DAL.STR.WithDraw;
using Entities.ViewModels.STR.WithDraw;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.WithDraw
{
    public class StrWithDrawDetailsSerialService
    {
        public StrWithDrawDetailsSerialRepository _StrWithDrawDetailsSerialRepository;
        public StrWithDrawDetailsSerialService(StrWithDrawDetailsSerialRepository StrWithDrawDetailsSerialRepository)
        {
            _StrWithDrawDetailsSerialRepository = StrWithDrawDetailsSerialRepository;
        }

        public string Add(StrWithDrawSerialVM sTR_Product)
        {
            return _StrWithDrawDetailsSerialRepository.Add(sTR_Product);
        }

        public string Update(StrWithDrawSerialVM sTR_Product)
        {
            return _StrWithDrawDetailsSerialRepository.Update(sTR_Product);
        }

        public string Delete(int sTR_Product_Id)
        {
            return _StrWithDrawDetailsSerialRepository.Delete(sTR_Product_Id);
        }

        public List<StrWithDrawSerialGetVM> GetAll()
        {
            return _StrWithDrawDetailsSerialRepository.GetAll();
        }

        public StrWithDrawSerialGetVM GetById(int sTR_Product_Id)
        {
            return _StrWithDrawDetailsSerialRepository.GetById(sTR_Product_Id);
        }
    }
}
