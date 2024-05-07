using DAL;
using DAL.TR.Plan;
using Entities.ViewModels.TR.Plan;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Plan.TrPlanPositionRepository;

namespace Business.TR.Plan
{
    public class TrPlanPositionService
    {
        public TrPlanPositionRepository _TrPlanRepository;
        public TrPlanPositionService(TrPlanPositionRepository TrPlanPositionRepository)
        {
            _TrPlanRepository = TrPlanPositionRepository;
        }
        public string Add(TrPlanPositionGeneralVM ID)
        {
            return _TrPlanRepository.Add(ID);
        }

        public string Update(TrPlanPositionVM ID)
        {
            return _TrPlanRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _TrPlanRepository.Delete(ID);
        }
        public List<TrPlanPositionGetVM> GetAll()
        {
            return _TrPlanRepository.GetAll();
        }
        public TrPlanPositionGetVM GetById(int ID)
        {
            return _TrPlanRepository.GetById(ID);
        }
        public List<TrPlanPositionGetVM> GetByHeaderId(int Id)
        {
            return _TrPlanRepository.GetByHeaderId(Id);
        }
        public PaginatedResult<TrPlanPositionGetVM> getAllByPagination(int page, int pageSize)
        {
            return _TrPlanRepository.GetAllByPagination(page, pageSize);
        }
    }
}
