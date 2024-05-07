using DAL;
using DAL.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.Cc.CcRegionRepository;

namespace Business.Cc
{
    public class CcRegionService
    {
        public CcRegionRepository _CcRegionRepository;
        public CcRegionService(CcRegionRepository CcRegionRepository)
        {
            _CcRegionRepository = CcRegionRepository;
        }
        public string GetLastNo()
        {
            return _CcRegionRepository.GetLastNo();
        }
        public string Add(CcRegionGeneralVM vtype)
        {
            return _CcRegionRepository.Add(vtype);
        }
        public string Update(CcRegionVM type)
        {
            return _CcRegionRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _CcRegionRepository.Delete(typeId);
        }
        public List<CcRegionGetVM> GetAll()
        {
            return _CcRegionRepository.GetAll();
        }
        public CcRegionGetVM GetById(int typeId)
        {
            return _CcRegionRepository.GetById(typeId);
        }
        public PaginatedResult<CcRegionGetVM> getAllByPagination(int page, int pageSize)
        {
            return _CcRegionRepository.GetAllByPagination(page, pageSize);
        }
    }
}
