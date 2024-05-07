using DAL;
using DAL.TR.General;
using Entities.ViewModels.TR.General;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.TR.General
{
    public class TrFinancierService
    {
        public TrFinancierRepository _TrPurposeRepository;
        public TrFinancierService(TrFinancierRepository TrFinancierRepository)
        {
            _TrPurposeRepository = TrFinancierRepository;
        }
        public string Add(TrFinancierGeneralVM ID)
        {
            return _TrPurposeRepository.Add(ID);
        }

        public string Update(TrFinancierVM ID)
        {
            return _TrPurposeRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _TrPurposeRepository.Delete(ID);
        }
        public List<TrFinancierGetVM> GetAll()
        {
            return _TrPurposeRepository.GetAll();
        }
        public TrFinancierGetVM GetById(int ID)
        {
            return _TrPurposeRepository.GetById(ID);
        }
        //public PaginatedResult<TrFinancierGetVM> getAllByPagination(int page, int pageSize)
        //{
        //    return _TrPurposeRepository.GetAllByPagination(page, pageSize);
        //}
    }
}
