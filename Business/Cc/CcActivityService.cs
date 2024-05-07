using DAL;
using DAL.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Entities.ViewModels;

namespace Business.Cc
{
    public class CcActivityService
    {
        public CcActivityRepository _CcActivityRepository;
        public CcActivityService(CcActivityRepository CcActivityRepository)
        {
            _CcActivityRepository = CcActivityRepository;
        }
        public string GetLastNo()
        {
            return _CcActivityRepository.GetLastNo();
        }
        public string Add(CcActivityGeneralVM vtype)
        {
            return _CcActivityRepository.Add(vtype);
        }
        public string Update(CcActivityVM type)
        {
            return _CcActivityRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _CcActivityRepository.Delete(typeId);
        }
        public List<CcActivityGetVM> GetAll()
        {
            return _CcActivityRepository.GetAll();
        }
        public CcActivityGetVM GetById(int typeId)
        {
            return _CcActivityRepository.GetById(typeId);
        }
        public PaginatedResult<CcActivityGetVM> getAllByPagination(int page, int pageSize)
        {
            return _CcActivityRepository.GetAllByPagination(page, pageSize);
        }
    }
}
