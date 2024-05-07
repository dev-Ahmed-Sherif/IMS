using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrAttendanceMachineWorkPlaceService
    {
        public HrAttendanceMachineWorkPlaceRepository _HrAttendanceMachineWorkPlaceRepository;
        public HrAttendanceMachineWorkPlaceService(HrAttendanceMachineWorkPlaceRepository HrAttendanceMachineWorkPlaceRepository)
        {
            _HrAttendanceMachineWorkPlaceRepository = HrAttendanceMachineWorkPlaceRepository;
        }
        public string Add(HrAttendanceMachineWorkPlaceVM ID)
        {
            return _HrAttendanceMachineWorkPlaceRepository.Add(ID);
        }

        public string Update(HrAttendanceMachineWorkPlaceVM ID)
        {
            return _HrAttendanceMachineWorkPlaceRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrAttendanceMachineWorkPlaceRepository.Delete(ID);
        }
        public List<HrAttendanceMachineWorkPlaceGetVM> GetAll()
        {
            return _HrAttendanceMachineWorkPlaceRepository.GetAll();
        }
        public HrAttendanceMachineWorkPlaceGetVM GetById(int ID)
        {
            return _HrAttendanceMachineWorkPlaceRepository.GetById(ID);
        }

    }
}
