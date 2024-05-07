using DAL;
using DAL.TR.Plan;
using Entities.ViewModels.TR.Plan;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Plan.TrPlanCourseDataRepository;

namespace Business.TR.Plan
{
    public class TrPlanCourseDataService
    {
        public TrPlanCourseDataRepository _TrPlanCourseDataRepository;
        public TrPlanCourseDataService(TrPlanCourseDataRepository TrPlanCourseDataRepository)
        {
            _TrPlanCourseDataRepository = TrPlanCourseDataRepository;
        }
        public string Add(TrPlanCourseDataGeneralVM TR_PlanCourseData)
        {
            return _TrPlanCourseDataRepository.Add(TR_PlanCourseData);
        }
        public string Update(TrPlanCourseDataVM TR_PlanCourseData)
        {
            return _TrPlanCourseDataRepository.Update(TR_PlanCourseData);
        }
        public string Delete(int PlanCourseData_Id)
        {
            return _TrPlanCourseDataRepository.Delete(PlanCourseData_Id);
        }
        public List<TrPlanCourseDataGetVM> GetAll()
        {
            return _TrPlanCourseDataRepository.GetAll();
        }
        public TrPlanCourseDataGetVM GetById(int PlanCourseDataId)
        {
            return _TrPlanCourseDataRepository.GetById(PlanCourseDataId);
        }
        public PaginatedResult<TrPlanCourseDataGetVM> getAllByPagination(int page, int pageSize)
        {
            return _TrPlanCourseDataRepository.GetAllByPagination(page, pageSize);
        }
    }
}
