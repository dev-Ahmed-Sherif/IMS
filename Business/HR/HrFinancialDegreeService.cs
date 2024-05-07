using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;



namespace Business.HR
{
    public class HrFinancialDegreeService
    {
        public HrFinancialDegreeRepository _HrFinancialDegreeRepository;
        public HrFinancialDegreeService(HrFinancialDegreeRepository HrFinancialDegreeRepository)
        {
            _HrFinancialDegreeRepository = HrFinancialDegreeRepository;
        }
        public string Add(HrFinancialDegreeVM ID)
        {
            return _HrFinancialDegreeRepository.Add(ID);
        }

        public string Update(HrFinancialDegreeVM ID)
        {
            return _HrFinancialDegreeRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrFinancialDegreeRepository.Delete(ID);
        }
        public List<HrFinancialDegreeGetVM> GetAll()
        {
            return _HrFinancialDegreeRepository.GetAll();
        }
        public HrFinancialDegreeVM GetById(int ID)
        {
            return _HrFinancialDegreeRepository.GetById(ID);
        }

    }
}
