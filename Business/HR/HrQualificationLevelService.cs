using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrQualificationLevelService
    {
        public HrQualificationLevelRepository _HrQualificationLevelRepository;
        public HrQualificationLevelService(HrQualificationLevelRepository HrQualificationLevelRepository)
        {
            _HrQualificationLevelRepository = HrQualificationLevelRepository;
        }
        public string Add(HrQualificationLevelVM ID)
        {
            return _HrQualificationLevelRepository.Add(ID);
        }

        public string Update(HrQualificationLevelVM ID)
        {
            return _HrQualificationLevelRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrQualificationLevelRepository.Delete(ID);
        }
        public List<HrQualificationLevelGetVM> GetAll()
        {
            return _HrQualificationLevelRepository.GetAll();
        }
        public HrQualificationLevelGetVM GetById(int ID)
        {
            return _HrQualificationLevelRepository.GetById(ID);
        }

    }
}
