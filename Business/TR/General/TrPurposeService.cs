using DAL;
using DAL.TR.General;
using Entities.ViewModels.TR.General;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.TR.General
{
    public class TrpurposeService
    {
        public TrPurposeRepository _TrPurposeRepository;
        public TrpurposeService(TrPurposeRepository TrPurposeRepository)
        {
            _TrPurposeRepository = TrPurposeRepository;
        }
        public string Add(TrPurposeGeneralVM ID)
        {
            return _TrPurposeRepository.Add(ID);
        }

        public string Update(TrPurposeVM ID)
        {
            return _TrPurposeRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _TrPurposeRepository.Delete(ID);
        }
        public List<TrPurposeGetVM> GetAll()
        {
            return _TrPurposeRepository.GetAll();
        }
        public TrPurposeGetVM GetById(int ID)
        {
            return _TrPurposeRepository.GetById(ID);
        }
        //public PaginatedResult<TrPurposeGetVM> getAllByPagination(int page, int pageSize)
        //{
        //    return _TrPurposeRepository.GetAllByPagination(page, pageSize);
        //}
    }
}
