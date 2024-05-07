using DAL;
using DAL.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.Cc.CcPlantComponentRepository;

namespace Business.Cc
{
    public class CcPlantComponentService
    {
        public CcPlantComponentRepository _CcPlantComponentRepository;
        public CcPlantComponentService(CcPlantComponentRepository CcPlantComponentRepository)
        {
            _CcPlantComponentRepository = CcPlantComponentRepository;
        }
        public string GetLastNo()
        {
            return _CcPlantComponentRepository.GetLastNo();
        }
        public string Add(CcPlantComponentGeneralVM vtype)
        {
            return _CcPlantComponentRepository.Add(vtype);
        }
        public string Update(CcPlantComponentVM type)
        {
            return _CcPlantComponentRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _CcPlantComponentRepository.Delete(typeId);
        }
        public List<CcPlantComponentGetVM> GetAll()
        {
            return _CcPlantComponentRepository.GetAll();
        }
        public CcPlantComponentGetVM GetById(int typeId)
        {
            return _CcPlantComponentRepository.GetById(typeId);
        }
        public PaginatedResult<CcPlantComponentGetVM> getAllByPagination(int page, int pageSize)
        {
            return _CcPlantComponentRepository.GetAllByPagination(page, pageSize);
        }
    }
}
