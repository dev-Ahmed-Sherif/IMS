using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrAttendancePermissionService
    {
        public HrAttendancePermissionRepository _HrAttendancePermissionRepository;
        public HrAttendancePermissionService(HrAttendancePermissionRepository HrAttendancePermissionRepository)
        {
            _HrAttendancePermissionRepository = HrAttendancePermissionRepository;
        }
        public string Add(HrAttendancePermissionVM ID)
        {
            return _HrAttendancePermissionRepository.Add(ID);
        }

        public string Update(HrAttendancePermissionVM ID)
        {
            return _HrAttendancePermissionRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrAttendancePermissionRepository.Delete(ID);
        }
        public List<HrAttendancePermissionGetVM> GetAll()
        {
            return _HrAttendancePermissionRepository.GetAll();
        }
        public HrAttendancePermissionGetVM GetById(int ID)
        {
            return _HrAttendancePermissionRepository.GetById(ID);
        }

    }
}
