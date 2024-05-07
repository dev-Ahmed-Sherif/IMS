using DAL;
using DAL.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.Cc.CcPlantRepository;

namespace Business.Cc
{
    public class CcPlantService
    {
        public CcPlantRepository _CcPlantRepository;
        public CcPlantService(CcPlantRepository CcPlantRepository)
        {
            _CcPlantRepository = CcPlantRepository;
        }
        public string GetLastNo(int SubRegionId)
        {
            return _CcPlantRepository.GetLastNo(SubRegionId);
        }
        public string Add(CcPlantGeneralVM vtype)
        {
            return _CcPlantRepository.Add(vtype);
        }
        public string Update(CcPlantVM type)
        {
            return _CcPlantRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _CcPlantRepository.Delete(typeId);
        }
        public List<CcPlantGetVM> GetAll()
        {
            return _CcPlantRepository.GetAll();
        }
        public CcPlantGetVM GetById(int typeId)
        {
            return _CcPlantRepository.GetById(typeId);
        }
        public PaginatedResult<CcPlantGetVM> getAllByPagination(int page, int pageSize)
        {
            return _CcPlantRepository.GetAllByPagination(page, pageSize);
        }
    }
}
