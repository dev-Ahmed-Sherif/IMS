using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrEmployeeFinancialDegreeService
    {
        public HrEmployeeFinancialDegreeRepository _EmployeeFinancialDegreeRepository;
        public HrEmployeeFinancialDegreeService(HrEmployeeFinancialDegreeRepository HrEmployeeFinancialDegreeRepository)
        {
            _EmployeeFinancialDegreeRepository = HrEmployeeFinancialDegreeRepository;
        }
        public string Add(HrEmployeeFinancialDegreeVM ID)
        {
            return _EmployeeFinancialDegreeRepository.Add(ID);
        }

        public string Update(HrEmployeeFinancialDegreeVM ID)
        {
            return _EmployeeFinancialDegreeRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _EmployeeFinancialDegreeRepository.Delete(ID);
        }
        public List<HrEmployeeFinancialDegreeGetVM> GetAll()
        {
            return _EmployeeFinancialDegreeRepository.GetAll();
        }
        public HrEmployeeFinancialDegreeGetVM GetById(int ID)
        {
            return _EmployeeFinancialDegreeRepository.GetById(ID);
        }

    }
}
