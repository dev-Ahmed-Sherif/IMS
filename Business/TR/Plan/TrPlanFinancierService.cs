using DAL;
using DAL.TR.Plan;
using Entities.ViewModels.TR.Plan;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Plan.TrPlanFinancierRepository;

namespace Business.TR.Plan
{
    public class TrPlanFinancierService
    {
        public TrPlanFinancierRepository _TrPlanFinancierRepository;
        public TrPlanFinancierService(TrPlanFinancierRepository TrPlanFinancierRepository)
        {
            _TrPlanFinancierRepository = TrPlanFinancierRepository;
        }

        public string Add(TrPlanFinancierGeneralVM TR_PlanFinancier)
        {
            return _TrPlanFinancierRepository.Add(TR_PlanFinancier);
        }
        public string Update(TrPlanFinancierVM TR_PlanFinancier)
        {
            return _TrPlanFinancierRepository.Update(TR_PlanFinancier);
        }
        public string Delete(int PlanFinancier_Id)
        {
            return _TrPlanFinancierRepository.Delete(PlanFinancier_Id);
        }
        public List<TrPlanFinancierGetVM> GetAll()
        {
            return _TrPlanFinancierRepository.GetAll();
        }
        public TrPlanFinancierGetVM GetById(int PlanFinancierId)
        {
            return _TrPlanFinancierRepository.GetById(PlanFinancierId);
        }
        public List<TrPlanFinancierGetVM> GetByHeaderId(int Id)
        {
            return _TrPlanFinancierRepository.GetByHeaderId(Id);
        }
        public PaginatedResult<TrPlanFinancierGetVM> getAllByPagination(int page, int pageSize)
        {
            return _TrPlanFinancierRepository.GetAllByPagination(page, pageSize);
        }
    }
}
