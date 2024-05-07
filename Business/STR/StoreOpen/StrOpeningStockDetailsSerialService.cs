using DAL;
using DAL.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.StoreOpen
{
    public class StrOpeningStockDetailsSerialService
    {
        public StrOpeningStockDetailsSerialRepository _row;
        public StrOpeningStockDetailsSerialService(StrOpeningStockDetailsSerialRepository StrOpeningStockDetailsSerialRepository)
        {
            _row = StrOpeningStockDetailsSerialRepository;
        }
        public string Add(StrOpeningStockDetailsSerialVM ID)
        {
            return _row.Add(ID);
        }
        public string Update(StrOpeningStockDetailsSerialVM ID)
        {
            return _row.Update(ID);
        }
        public string Delete(int ID)
        {
            return _row.Delete(ID);
        }
        public List<StrOpeningStockDetailsSerialGetVM> GetAll()
        {
            return _row.GetAll();
        }
        public StrOpeningStockDetailsSerialGetVM GetById(int ID)
        {
            return _row.GetById(ID);
        }
        public List<StrOpeningStockDetailsSerialGetVM> GetByHeader(int ID)
        {
            return _row.GetByHeader(ID);
        }
        public List<StrOpeningStockDetailsSerialGetVM> GetByProduct(int ID)
        {
            return _row.GetByProduct(ID);
        }

    }
}
