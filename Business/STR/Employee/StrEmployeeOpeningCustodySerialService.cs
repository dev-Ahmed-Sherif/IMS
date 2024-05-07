using DAL;
using DAL.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.Employee
{
    public class StrEmployeeOpeningCustodySerialService
    {
        public StrEmployeeOpeningCustodySerialRepository _row;
        public StrEmployeeOpeningCustodySerialService(StrEmployeeOpeningCustodySerialRepository StrEmployeeOpeningCustodySerialRepository)
        {
            _row = StrEmployeeOpeningCustodySerialRepository;
        }
        public string Add(StrEmployeeOpeningCustodySerialVM ID)
        {
            return _row.Add(ID);
        }
        public string Update(StrEmployeeOpeningCustodySerialVM ID)
        {
            return _row.Update(ID);
        }
        public string Delete(int ID)
        {
            return _row.Delete(ID);
        }
        public List<StrEmployeeOpeningCustodySerialGetVM> GetAll()
        {
            return _row.GetAll();
        }
        public StrEmployeeOpeningCustodySerialGetVM GetById(int ID)
        {
            return _row.GetById(ID);
        }
        public List<StrEmployeeOpeningCustodySerialGetVM> GetByHeader(int ID)
        {
            return _row.GetByHeader(ID);
        }
        public List<StrEmployeeOpeningCustodySerialGetVM> GetByProduct(int ID)
        {
            return _row.GetByProduct(ID);
        }
    }
}
