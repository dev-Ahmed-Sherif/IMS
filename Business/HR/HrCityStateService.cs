using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrCityStateService
    {
        public HrCityStateRepository _HrCityStateRepository;
        public HrCityStateService(HrCityStateRepository HrCityStateRepository)
        {
            _HrCityStateRepository = HrCityStateRepository;
        }
        public string Add(HrCityStateVM ID)
        {
            return _HrCityStateRepository.Add(ID);
        }

        public string Update(HrCityStateVM ID)
        {
            return _HrCityStateRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrCityStateRepository.Delete(ID);
        }
        public List<HrCityStateGetVM> GetAll()
        {
            return _HrCityStateRepository.GetAll();
        }
        public HrCityStateGetVM GetById(int ID)
        {
            return _HrCityStateRepository.GetById(ID);
        }

    }
}
