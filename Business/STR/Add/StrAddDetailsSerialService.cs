using DAL;
using DAL.STR.Add;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.Add
{
    public class StrAddDetailsSerialService
    {
        public StrAddDetailsSerialRepository _row;
        public StrAddDetailsSerialService(StrAddDetailsSerialRepository StrAddDetailsSerialRepository)
        {
            _row = StrAddDetailsSerialRepository;
        }
        public string Add(StrAddDetailsSerialVM ID)
        {
            return _row.Add(ID);
        }
        public string Update(StrAddDetailsSerialVM ID)
        {
            return _row.Update(ID);
        }
        public string Delete(int ID)
        {
            return _row.Delete(ID);
        }
        public List<StrAddDetailsSerialGetVM> GetAll()
        {
            return _row.GetAll();
        }
        public StrAddDetailsSerialGetVM GetById(int ID)
        {
            return _row.GetById(ID);
        }
        public StrAddDetailsSerialGetVM GetByHeader(int ID)
        {
            return _row.GetByHeader(ID);
        }
        public StrAddDetailsSerialGetVM GetByProduct(int ID)
        {
            return _row.GetByProduct(ID);
        }
    }
}
