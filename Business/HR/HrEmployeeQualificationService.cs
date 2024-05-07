using DAL;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrEmployeeQualificationService
    {
        public HrEmployeeQualificationRepository _HrEmployeeQualificationRepository;
        public HrEmployeeQualificationService(HrEmployeeQualificationRepository HrEmployeeQualificationRepository)
        {
            _HrEmployeeQualificationRepository = HrEmployeeQualificationRepository;
        }
        public string Add(HrEmployeeQualificationVM EmployeeQualification)
        {
            return _HrEmployeeQualificationRepository.Add(EmployeeQualification);
        }

        public string Update(HrEmployeeQualificationVM EmployeeQualification)
        {
            return _HrEmployeeQualificationRepository.Update(EmployeeQualification);
        }

        public string Delete(int EmployeeQualificationId)
        {
            return _HrEmployeeQualificationRepository.Delete(EmployeeQualificationId);
        }
        public List<HrEmployeeQualificationGetVM> GetAll()
        {
            return _HrEmployeeQualificationRepository.GetAll();
        }
        public HrEmployeeQualificationGetVM GetById(int EmployeeQualificationId)
        {
            return _HrEmployeeQualificationRepository.GetById(EmployeeQualificationId);
        }

    }
}
