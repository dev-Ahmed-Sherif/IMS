using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrAttendanceMachineService
    {
        public HrAttendanceMachineRepository _HrAttendanceMachineRepository;
        public HrAttendanceMachineService(HrAttendanceMachineRepository HrAttendanceMachineRepository)
        {
            _HrAttendanceMachineRepository = HrAttendanceMachineRepository;
        }
        public string Add(HrAttendanceMachineVM AttendanceMachine)
        {
            return _HrAttendanceMachineRepository.Add(AttendanceMachine);
        }

        public string Update(HrAttendanceMachineVM ID)
        {
            return _HrAttendanceMachineRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrAttendanceMachineRepository.Delete(ID);
        }
        public List<HrAttendanceMachineGetVM> GetAll()
        {
            return _HrAttendanceMachineRepository.GetAll();
        }
        public HrAttendanceMachineGetVM GetById(int ID)
        {
            return _HrAttendanceMachineRepository.GetById(ID);
        }

    }
}
