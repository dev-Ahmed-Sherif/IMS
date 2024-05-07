using DAL;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrEmployeeDisciplinaryService
    {
        public HrEmployeeDisciplinaryRepository _HrEmployeeDisciplinaryRepository;
        public HrEmployeeDisciplinaryService(HrEmployeeDisciplinaryRepository HrEmployeeDisciplinaryRepository)
        {
            _HrEmployeeDisciplinaryRepository = HrEmployeeDisciplinaryRepository;
        }
        public string Add(HrEmployeeDisciplinaryVM EmployeeDisciplinary)
        {
            return _HrEmployeeDisciplinaryRepository.Add(EmployeeDisciplinary);
        }

        public string Update(HrEmployeeDisciplinaryVM EmployeeDisciplinary)
        {
            return _HrEmployeeDisciplinaryRepository.Update(EmployeeDisciplinary);
        }

        public string Delete(int EmployeeDisciplinaryId)
        {
            return _HrEmployeeDisciplinaryRepository.Delete(EmployeeDisciplinaryId);
        }
        public List<HrEmployeeDisciplinaryGetVM> GetAll()
        {
            return _HrEmployeeDisciplinaryRepository.GetAll();
        }
        public HrEmployeeDisciplinaryGetVM GetById(int EmployeeDisciplinaryId)
        {
            return _HrEmployeeDisciplinaryRepository.GetById(EmployeeDisciplinaryId);
        }

    }
}
