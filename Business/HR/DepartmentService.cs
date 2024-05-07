using DAL;
using DAL.HR;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class DepartmentService
    {
        public DepartmentRepository _DepartmentRepository;
        public DepartmentService(DepartmentRepository DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
        }
        public string Add(DepartmentGeneralVM Dep)
        {
            return _DepartmentRepository.Add(Dep);
        }
        public string Update(DepartmentVM Dep)
        {
            return _DepartmentRepository.Update(Dep);
        }
        public string Delete(int DepId)
        {
            return _DepartmentRepository.Delete(DepId);
        }
        public List<DepartmentGetVM> GetAll()
        {
            return _DepartmentRepository.GetAll();
        }
        public DepartmentGetVM GetById(int itemId)
        {
            return _DepartmentRepository.GetById(itemId);
        }
    }
}

