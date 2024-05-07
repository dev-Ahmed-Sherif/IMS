using DAL;
using DAL.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.Cc.CcSourceRepository;

namespace Business.Cc
{
    public class CcSourceService
    {
        public CcSourceRepository _CcSourceRepository;
        public CcSourceService(CcSourceRepository CcSourceRepository)
        {
            _CcSourceRepository = CcSourceRepository;
        }
        public string GetLastNo()
        {
            return _CcSourceRepository.GetLastNo();
        }
        public string Add(CcSourceGeneralVM vtype)
        {
            return _CcSourceRepository.Add(vtype);
        }
        public string Update(CcSourceVM type)
        {
            return _CcSourceRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _CcSourceRepository.Delete(typeId);
        }
        public List<CcSourceGetVM> GetAll()
        {
            return _CcSourceRepository.GetAll();
        }
        public CcSourceGetVM GetById(int typeId)
        {
            return _CcSourceRepository.GetById(typeId);
        }
        public PaginatedResult<CcSourceGetVM> getAllByPagination(int page, int pageSize)
        {
            return _CcSourceRepository.GetAllByPagination(page, pageSize);
        }
    }
}
