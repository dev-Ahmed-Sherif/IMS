using DAL;
using DAL.TR.Plan;
using Entities.ViewModels.TR.Plan;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Plan.TrPlanRepository;

namespace Business.TR.Plan
{
    public class TrPlanService
    {
        public TrPlanRepository _TrPlanRepository;
        public TrPlanService(TrPlanRepository TrPlanRepository)
        {
            _TrPlanRepository = TrPlanRepository;
        }
        public string Add(TrPlanGeneralVM ID)
        {
            return _TrPlanRepository.Add(ID);
        }

        public string Update(TrPlanVM ID)
        {
            return _TrPlanRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _TrPlanRepository.Delete(ID);
        }
        public List<TrPlanGetVM> GetAll()
        {
            return _TrPlanRepository.GetAll();
        }
        public TrPlanGetVM GetById(int ID)
        {
            return _TrPlanRepository.GetById(ID);
        }
        public PaginatedResult<TrPlanGetVM> getAllByPagination(int page, int pageSize)
        {
            return _TrPlanRepository.GetAllByPagination(page, pageSize);
        }
    }
}
