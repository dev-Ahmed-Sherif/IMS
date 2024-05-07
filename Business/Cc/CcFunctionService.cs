using DAL;
using DAL.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.Cc.CcFunctionRepository;

namespace Business.Cc
{
    public class CcFunctionService
    {
        public CcFunctionRepository _CcFunctionRepository;
        public CcFunctionService(CcFunctionRepository CcFunctionRepository)
        {
            _CcFunctionRepository = CcFunctionRepository;
        }
        public string GetLastNo()
        {
            return _CcFunctionRepository.GetLastNo();
        }
        public string Add(CcFunctionGeneralVM vtype)
        {
            return _CcFunctionRepository.Add(vtype);
        }
        public string Update(CcFunctionVM type)
        {
            return _CcFunctionRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _CcFunctionRepository.Delete(typeId);
        }
        public List<CcFunctionGetVM> GetAll()
        {
            return _CcFunctionRepository.GetAll();
        }
        public CcFunctionGetVM GetById(int typeId)
        {
            return _CcFunctionRepository.GetById(typeId);
        }
        public PaginatedResult<CcFunctionGetVM> getAllByPagination(int page, int pageSize)
        {
            return _CcFunctionRepository.GetAllByPagination(page, pageSize);
        }
    }
}
