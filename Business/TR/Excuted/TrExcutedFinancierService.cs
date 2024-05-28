using DAL;
using DAL.TR.Excuted;
using Entities.ViewModels.TR.Excuted;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Excuted.TrExcutedFinancierRepository;

namespace Business.TR.Excuted
{
    public class TrExcutedFinancierService
    {
        public TrExcutedFinancierRepository _TrPurposeRepository;
        public TrExcutedFinancierService(TrExcutedFinancierRepository TrExcutedFinancierRepository)
        {
            _TrPurposeRepository = TrExcutedFinancierRepository;
        }
        public string Add(TrExcutedFinancierGeneralVM ID)
        {
            return _TrPurposeRepository.Add(ID);
        }

        public string Update(TrExcutedFinancierVM ID)
        {
            return _TrPurposeRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _TrPurposeRepository.Delete(ID);
        }
        public List<TrExcutedFinancierGetVM> GetAll()
        {
            return _TrPurposeRepository.GetAll();
        }
        public TrExcutedFinancierGetVM GetById(int ID)
        {
            return _TrPurposeRepository.GetById(ID);
        }
        public PaginatedResult<TrExcutedFinancierGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _TrPurposeRepository.GetAllByPagination(page, pageSize, HeaderId);
        }
    }
}
