using DAL;
using DAL.TR.Plan;
using Entities.ViewModels.TR.Plan;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Plan.TrPlanInstructorRepository;

namespace Business.TR.Plan
{
    public class TrPlanInstructorService
    {
        public TrPlanInstructorRepository _TrPlanRepository;
        public TrPlanInstructorService(TrPlanInstructorRepository TrPlanInstructorRepository)
        {
            _TrPlanRepository = TrPlanInstructorRepository;
        }
        public string Add(TrPlanInstructorGeneralVM ID)
        {
            return _TrPlanRepository.Add(ID);
        }

        public string Update(TrPlanInstructorVM ID)
        {
            return _TrPlanRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _TrPlanRepository.Delete(ID);
        }
        public List<TrPlanInstructorGetVM> GetAll()
        {
            return _TrPlanRepository.GetAll();
        }
        public TrPlanInstructorGetVM GetById(int ID)
        {
            return _TrPlanRepository.GetById(ID);
        }

        public List<TrInstrctorDataVM> GetInstructorDataById(int itemId)
        {
            return _TrPlanRepository.GetInstructorDataById(itemId);
        }
        public PaginatedResult<TrPlanInstructorGetVM> getAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _TrPlanRepository.GetAllByPagination(page, pageSize, HeaderId);
        }
    }
}
