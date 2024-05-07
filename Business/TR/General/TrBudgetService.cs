using DAL;
using DAL.TR.General;
using Entities.ViewModels.TR.General;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.TR.General
{
    public class TrBudgetService
    {
        public TrBudgetRepository _TrBudgetRepository;
        public TrBudgetService(TrBudgetRepository TrBudgetRepository)
        {
            _TrBudgetRepository = TrBudgetRepository;
        }
        public string Add(TrBudgetGeneralVM ID)
        {
            return _TrBudgetRepository.Add(ID);
        }

        public string Update(TrBudgetVM ID)
        {
            return _TrBudgetRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _TrBudgetRepository.Delete(ID);
        }
        public List<TrBudgetGetVM> GetAll()
        {
            return _TrBudgetRepository.GetAll();
        }
        public TrBudgetGetVM GetById(int ID)
        {
            return _TrBudgetRepository.GetById(ID);
        }
        //public PaginatedResult<TrBudgetGetVM> getAllByPagination(int page, int pageSize)
        //{
        //    return _TrBudgetRepository.GetAllByPagination(page, pageSize);
        //}
    }
}
