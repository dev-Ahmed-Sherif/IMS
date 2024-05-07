using DAL;
using DAL.HR;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class GeneralDepartmentService
    {
        public GeneralDepartmentRepository _GeneralDepartmentRepository;
        public GeneralDepartmentService(GeneralDepartmentRepository GeneralDepartmentRepository)
        {
            _GeneralDepartmentRepository = GeneralDepartmentRepository;
        }
        public string Add(GeneralDepartmentgeneralVM Dep)
        {
            return _GeneralDepartmentRepository.Add(Dep);
        }

        public string Update(GeneralDepartmentVM Dep)
        {
            return _GeneralDepartmentRepository.Update(Dep);
        }

        public string Delete(int GDepId)
        {
            return _GeneralDepartmentRepository.Delete(GDepId);
        }

        public List<GeneralDepartmentGetVM> GetAll()
        {
            return _GeneralDepartmentRepository.GetAll();
        }
        public GeneralDepartmentGetVM GetById(int GDepId)
        {
            return _GeneralDepartmentRepository.GetById(GDepId);
        }
    }
}
