using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrHolidayService
    {
        public HrHolidayRepository _HrHolidayRepository;
        public HrHolidayService(HrHolidayRepository HrHolidayRepository)
        {
            _HrHolidayRepository = HrHolidayRepository;
        }
        public string Add(HrHolidayVM ID)
        {
            return _HrHolidayRepository.Add(ID);
        }

        public string Update(HrHolidayVM ID)
        {
            return _HrHolidayRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrHolidayRepository.Delete(ID);
        }
        public List<HrHolidayGetVM> GetAll()
        {
            return _HrHolidayRepository.GetAll();
        }
        public HrHolidayGetVM GetById(int ID)
        {
            return _HrHolidayRepository.GetById(ID);
        }

    }
}
