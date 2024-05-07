using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrQualificationService
    {
        public HrQualificationRepository _HrQualificationRepository;
        public HrQualificationService(HrQualificationRepository HrQualificationRepository)
        {
            _HrQualificationRepository = HrQualificationRepository;
        }
        public string Add(HrQualificationVM ID)
        {
            return _HrQualificationRepository.Add(ID);
        }

        public string Update(HrQualificationVM ID)
        {
            return _HrQualificationRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrQualificationRepository.Delete(ID);
        }
        public List<HrQualificationGetVM> GetAll()
        {
            return _HrQualificationRepository.GetAll();
        }
        public HrQualificationGetVM GetById(int ID)
        {
            return _HrQualificationRepository.GetById(ID);
        }

    }
}
