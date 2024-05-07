using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrCityService
    {
        public HrCityRepository _HrCityRepository;
        public HrCityService(HrCityRepository HrCityRepository)
        {
            _HrCityRepository = HrCityRepository;
        }
        public string Add(HrCityVM ID)
        {
            return _HrCityRepository.Add(ID);
        }

        public string Update(HrCityVM ID)
        {
            return _HrCityRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrCityRepository.Delete(ID);
        }
        public List<HrCityGetVM> GetAll()
        {
            return _HrCityRepository.GetAll();
        }
        public HrCityGetVM GetById(int ID)
        {
            return _HrCityRepository.GetById(ID);
        }

    }
}
