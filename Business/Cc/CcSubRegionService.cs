using DAL;
using DAL.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.Cc.CcSubRegionRepository;

namespace Business.Cc
{
    public class CcSubRegionService
    {
        public CcSubRegionRepository _CcSubRegionRepository;
        public CcSubRegionService(CcSubRegionRepository CcSubRegionRepository)
        {
            _CcSubRegionRepository = CcSubRegionRepository;
        }
        public string GetLastNo(int RegionId)
        {
            return _CcSubRegionRepository.GetLastNo(RegionId);
        }
        public string Add(CcSubRegionGeneralVM vtype)
        {
            return _CcSubRegionRepository.Add(vtype);
        }
        public string Update(CcSubRegionVM type)
        {
            return _CcSubRegionRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _CcSubRegionRepository.Delete(typeId);
        }
        public List<CcSubRegionGetVM> GetAll()
        {
            return _CcSubRegionRepository.GetAll();
        }
        public CcSubRegionGetVM GetById(int typeId)
        {
            return _CcSubRegionRepository.GetById(typeId);
        }
        public PaginatedResult<CcSubRegionGetVM> getAllByPagination(int page, int pageSize)
        {
            return _CcSubRegionRepository.GetAllByPagination(page, pageSize);
        }
    }
}
