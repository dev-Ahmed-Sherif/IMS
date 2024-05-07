using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrVacationService
    {
        public HrVacationRepository _HrVacationRepository;
        public HrVacationService(HrVacationRepository HrVacationRepository)
        {
            _HrVacationRepository = HrVacationRepository;
        }
        public string Add(HrVacationVM ID)
        {
            return _HrVacationRepository.Add(ID);
        }

        public string Update(HrVacationVM ID)
        {
            return _HrVacationRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrVacationRepository.Delete(ID);
        }
        public List<HrVacationGetVM> GetAll()
        {
            return _HrVacationRepository.GetAll();
        }
        public HrVacationGetVM GetById(int ID)
        {
            return _HrVacationRepository.GetById(ID);
        }

    }
}
