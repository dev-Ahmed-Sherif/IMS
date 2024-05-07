using DAL;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrIncentiveAllowanceService
    {
        public HrIncentiveAllowanceRepository _HrIncentiveAllowanceRepository;
        public HrIncentiveAllowanceService(HrIncentiveAllowanceRepository HrIncentiveAllowanceRepository)
        {
            _HrIncentiveAllowanceRepository = HrIncentiveAllowanceRepository;
        }
        public string Add(HrIncentiveAllowanceVM IncentiveAllowance)
        {
            return _HrIncentiveAllowanceRepository.Add(IncentiveAllowance);
        }

        public string Update(HrIncentiveAllowanceVM IncentiveAllowance)
        {
            return _HrIncentiveAllowanceRepository.Update(IncentiveAllowance);
        }

        public string Delete(int IncentiveAllowanceId)
        {
            return _HrIncentiveAllowanceRepository.Delete(IncentiveAllowanceId);
        }
        public List<HrIncentiveAllowanceGetVM> GetAll()
        {
            return _HrIncentiveAllowanceRepository.GetAll();
        }
        public HrIncentiveAllowanceGetVM GetById(int IncentiveAllowanceId)
        {
            return _HrIncentiveAllowanceRepository.GetById(IncentiveAllowanceId);
        }

    }
}
