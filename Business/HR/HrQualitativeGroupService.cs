using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrQualitativeGroupService
    {
        public HrQualitativeGroupRepository _HrQualitativeGroupRepository;
        public HrQualitativeGroupService(HrQualitativeGroupRepository HrQualitativeGroupRepository)
        {
            _HrQualitativeGroupRepository = HrQualitativeGroupRepository;
        }
        public string Add(HrQualitativeGroupVM ID)
        {
            return _HrQualitativeGroupRepository.Add(ID);
        }

        public string Update(HrQualitativeGroupVM ID)
        {
            return _HrQualitativeGroupRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrQualitativeGroupRepository.Delete(ID);
        }
        public List<HrQualitativeGroupGetVM> GetAll()
        {
            return _HrQualitativeGroupRepository.GetAll();
        }
        public HrQualitativeGroupGetVM GetById(int ID)
        {
            return _HrQualitativeGroupRepository.GetById(ID);
        }

    }
}
