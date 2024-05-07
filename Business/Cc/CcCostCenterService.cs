using DAL;
using DAL.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.Cc.CcCostCenterRepository;

namespace Business.Cc
{
    public class CcCostCenterService
    {
        public CcCostCenterRepository _CcCostCenterRepository;
        public CcCostCenterService(CcCostCenterRepository CcCostCenterRepository)
        {
            _CcCostCenterRepository = CcCostCenterRepository;
        }
        public string GetLastCode()
        {
            return _CcCostCenterRepository.GetLastCode();
        }
        public string Add(CcCostCenterGeneralVM vtype)
        {
            return _CcCostCenterRepository.Add(vtype);
        }
        public string Update(CcCostCenterVM type)
        {
            return _CcCostCenterRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _CcCostCenterRepository.Delete(typeId);
        }
        public List<CcCostCenterGetVM> GetAll()
        {
            return _CcCostCenterRepository.GetAll();
        }
        public CcCostCenterGetVM GetById(int typeId)
        {
            return _CcCostCenterRepository.GetById(typeId);
        }
        public PaginatedResult<CcCostCenterGetVM> getAllByPagination(int page, int pageSize)
        {
            return _CcCostCenterRepository.GetAllByPagination(page, pageSize);
        }
    }
}
