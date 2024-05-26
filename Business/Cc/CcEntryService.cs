using DAL;
using DAL.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.Cc.CcEntryRepository;

namespace Business.Cc
{
    public class CcEntryService
    {
        public CcEntryRepository _CcEntryRepository;
        public CcEntryService(CcEntryRepository CcEntryRepository)
        {
            _CcEntryRepository = CcEntryRepository;
        }
        public string Add(CcEntryGeneralVM vtype)
        {
            return _CcEntryRepository.Add(vtype);
        }
        public string Update(CcEntryVM type)
        {
            return _CcEntryRepository.Update(type);
        }
        public string Delete(int EntryId)
        {
            return _CcEntryRepository.Delete(EntryId);
        }
        public List<CcEntryGetVM> GetAll()
        {
            return _CcEntryRepository.GetAll();
        }
        public CcEntryGetVM GetById(int typeId)
        {
            return _CcEntryRepository.GetById(typeId);
        }
        public PaginatedResult<CcEntryGetVM> getAllByPagination(int page, int pageSize, int YearId)
        {
            return _CcEntryRepository.GetAllByPagination(page, pageSize ,YearId);
        }
    }
}
