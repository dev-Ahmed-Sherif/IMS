using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrFinancialDegreeSalaryService
    {

        public HrFinancialDegreeSalaryRepository _HrFinancialDegreeSalaryRepository;
        public HrFinancialDegreeSalaryService(HrFinancialDegreeSalaryRepository HrFinancialDegreeSalaryRepository)
        {
            _HrFinancialDegreeSalaryRepository = HrFinancialDegreeSalaryRepository;
        }
        public string Add(HrFinancialDegreeSalaryVM ID)
        {
            return _HrFinancialDegreeSalaryRepository.Add(ID);
        }

        public string Update(HrFinancialDegreeSalaryVM ID)
        {
            return _HrFinancialDegreeSalaryRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrFinancialDegreeSalaryRepository.Delete(ID);
        }
        public List<HrFinancialDegreeSalaryGetVM> GetAll()
        {
            return _HrFinancialDegreeSalaryRepository.GetAll();
        }
        public HrFinancialDegreeSalaryVM GetById(int ID)
        {
            return _HrFinancialDegreeSalaryRepository.GetById(ID);
        }

    }
}
