using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrSeveranceReasonService
    {
        public HrSeveranceReasonRepository _HrSeveranceReasonRepository;
        public HrSeveranceReasonService(HrSeveranceReasonRepository HrSeveranceReasonRepository)
        {
            _HrSeveranceReasonRepository = HrSeveranceReasonRepository;
        }
        public string Add(HrSeveranceReasonVM ID)
        {
            return _HrSeveranceReasonRepository.Add(ID);
        }

        public string Update(HrSeveranceReasonVM ID)
        {
            return _HrSeveranceReasonRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrSeveranceReasonRepository.Delete(ID);
        }
        public List<HrSeveranceReasonGetVM> GetAll()
        {
            return _HrSeveranceReasonRepository.GetAll();
        }
        public HrSeveranceReasonGetVM GetById(int ID)
        {
            return _HrSeveranceReasonRepository.GetById(ID);
        }

    }
}
