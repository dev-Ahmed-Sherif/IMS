using DAL;
using DAL.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.Employee
{
    public class StrEmployeeExchangeSerialService
    {
        public StrEmployeeExchangeSerialRepository _row;
        public StrEmployeeExchangeSerialService(StrEmployeeExchangeSerialRepository StrEmployeeExchangeSerialRepository)
        {
            _row = StrEmployeeExchangeSerialRepository;
        }
        public string Add(StrEmployeeExchangeSerialVM ID)
        {
            return _row.Add(ID);
        }
        public string Update(StrEmployeeExchangeSerialVM ID)
        {
            return _row.Update(ID);
        }
        public string Delete(int ID)
        {
            return _row.Delete(ID);
        }
        public List<StrEmployeeExchangeSerialGetVM> GetAll()
        {
            return _row.GetAll();
        }
        public StrEmployeeExchangeSerialGetVM GetById(int ID)
        {
            return _row.GetById(ID);
        }
        public List<StrEmployeeExchangeSerialGetVM> GetByHeader(int ID)
        {
            return _row.GetByHeader(ID);
        }
        public List<StrEmployeeExchangeSerialGetVM> GetByProduct(int ID)
        {
            return _row.GetByProduct(ID);
        }
    }
}
