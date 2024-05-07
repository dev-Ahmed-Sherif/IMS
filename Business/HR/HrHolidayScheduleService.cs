using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrHolidayScheduleService
    {
        public HrHolidayScheduleRepository _HrHolidayScheduleRepository;
        public HrHolidayScheduleService(HrHolidayScheduleRepository HrHolidayScheduleRepository)
        {
            _HrHolidayScheduleRepository = HrHolidayScheduleRepository;
        }
        public string Add(HrHolidayScheduleVM ID)
        {
            return _HrHolidayScheduleRepository.Add(ID);
        }

        public string Update(HrHolidayScheduleVM ID)
        {
            return _HrHolidayScheduleRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrHolidayScheduleRepository.Delete(ID);
        }
        public List<HrHolidayScheduleGetVM> GetAll()
        {
            return _HrHolidayScheduleRepository.GetAll();
        }
        public HrHolidayScheduleGetVM GetById(int ID)
        {
            return _HrHolidayScheduleRepository.GetById(ID);
        }

    }
}
