using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrAttendanceScheduleService
    {
        public HrAttendanceScheduleRepository _HrAttendanceScheduleRepository;
        public HrAttendanceScheduleService(HrAttendanceScheduleRepository HrAttendanceScheduleRepository)
        {
            _HrAttendanceScheduleRepository = HrAttendanceScheduleRepository;
        }
        public string Add(HrAttendanceScheduleVM ID)
        {
            return _HrAttendanceScheduleRepository.Add(ID);
        }

        public string Update(HrAttendanceScheduleVM ID)
        {
            return _HrAttendanceScheduleRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrAttendanceScheduleRepository.Delete(ID);
        }
        public List<HrAttendanceScheduleGetVM> GetAll()
        {
            return _HrAttendanceScheduleRepository.GetAll();
        }
        public HrAttendanceScheduleGetVM GetById(int ID)
        {
            return _HrAttendanceScheduleRepository.GetById(ID);
        }

    }
}
