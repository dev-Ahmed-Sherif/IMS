using DAL;
using DAL.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.Cc.CcEntryDetailsRepository;

namespace Business.Cc
{
    public class CcEntryDetailsService
    {
        public CcEntryDetailsRepository _CcEntryDetailsRepository;
        public CcEntryDetailsService(CcEntryDetailsRepository CcEntryDetailsRepository)
        {
            _CcEntryDetailsRepository = CcEntryDetailsRepository;
        }
        public string Add(CcEntryDetailsGeneralVM vtype)
        {
            return _CcEntryDetailsRepository.Add(vtype);
        }
        public string Update(CcEntryDetailsVM type)
        {
            return _CcEntryDetailsRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _CcEntryDetailsRepository.Delete(typeId);
        }
        public List<CcEntryDetailsGetVM> GetAll()
        {
            return _CcEntryDetailsRepository.GetAll();
        }
        public CcEntryDetailsGetVM GetById(int typeId)
        {
            return _CcEntryDetailsRepository.GetById(typeId);
        }
        public List<CcEntryDetailsGetVM> GetByHeader(int HeaderID)
        {
            return _CcEntryDetailsRepository.GetByHeader(HeaderID);
        }
        public PaginatedResult<CcEntryDetailsGetVM> getAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _CcEntryDetailsRepository.GetAllByPagination(page, pageSize, HeaderId);
        }
    }
}
