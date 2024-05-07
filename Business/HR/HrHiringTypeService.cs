using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Business.HR
{
    public class HrHiringTypeService
    {
        public HrHiringTypeRepository _HrHiringTypeRepository;
        public HrHiringTypeService(HrHiringTypeRepository HrHiringTypeRepository)
        {
            _HrHiringTypeRepository = HrHiringTypeRepository;
        }
        public string Add(HrHiringTypeVM HiringType)
        {
            return _HrHiringTypeRepository.Add(HiringType);
        }

        public string Update(HrHiringTypeVM HiringType)
        {
            return _HrHiringTypeRepository.Update(HiringType);
        }

        public string Delete(int HiringTypeId)
        {
            return _HrHiringTypeRepository.Delete(HiringTypeId);
        }
        public List<HrHiringTypeGetVM> GetAll()
        {
            return _HrHiringTypeRepository.GetAll();
        }
        public HrHiringTypeGetVM GetById(int HiringTypeId)
        {
            return _HrHiringTypeRepository.GetById(HiringTypeId);
        }

    }
}
