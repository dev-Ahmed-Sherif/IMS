using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Business.HR
{
    public class HrEmployeeVacationBalanceService
    {
        public HrEmployeeVacationBalanceRepository _HrEmployeeVacationBalanceRepository;
        public HrEmployeeVacationBalanceService(HrEmployeeVacationBalanceRepository HrEmployeeVacationBalanceRepository)
        {
            _HrEmployeeVacationBalanceRepository = HrEmployeeVacationBalanceRepository;
        }
        public string Add(HrEmployeeVacationBalanceVM EmployeeVacationBalance)
        {
            return _HrEmployeeVacationBalanceRepository.Add(EmployeeVacationBalance);
        }

        public string Update(HrEmployeeVacationBalanceVM EmployeeVacationBalance)
        {
            return _HrEmployeeVacationBalanceRepository.Update(EmployeeVacationBalance);
        }

        public string Delete(int EmployeeVacationBalanceId)
        {
            return _HrEmployeeVacationBalanceRepository.Delete(EmployeeVacationBalanceId);
        }
        public List<HrEmployeeVacationBalanceGetVM> GetAll()
        {
            return _HrEmployeeVacationBalanceRepository.GetAll();
        }
        public HrEmployeeVacationBalanceGetVM GetById(int EmployeeVacationBalanceId)
        {
            return _HrEmployeeVacationBalanceRepository.GetById(EmployeeVacationBalanceId);
        }

    }
}
