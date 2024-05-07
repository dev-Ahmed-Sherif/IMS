using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Business.HR
{
    public class HrSpecializationService
    {
        public HrSpecializationRepository _HrSpecializationRepository;
        public HrSpecializationService(HrSpecializationRepository HrSpecializationRepository)
        {
            _HrSpecializationRepository = HrSpecializationRepository;
        }
        public string Add(HrSpecializationVM ID)
        {
            return _HrSpecializationRepository.Add(ID);
        }

        public string Update(HrSpecializationVM ID)
        {
            return _HrSpecializationRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrSpecializationRepository.Delete(ID);
        }
        public List<HrSpecializationGetVM> GetAll()
        {
            return _HrSpecializationRepository.GetAll();
        }
        public HrSpecializationGetVM GetById(int ID)
        {
            return _HrSpecializationRepository.GetById(ID);
        }

    }
}
