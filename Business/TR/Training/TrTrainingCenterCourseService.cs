using DAL;
using DAL.TR.Training;
using Entities.ViewModels.TR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Training.TrTrainingCenterCourseRepository;

namespace Business.TR.Training
{
    public class TrTrainingCenterCourseService
    {
        public TrTrainingCenterCourseRepository _Repository;
        public TrTrainingCenterCourseService(TrTrainingCenterCourseRepository TrTrainingCenterCourseRepository)
        {
            _Repository = TrTrainingCenterCourseRepository;
        }
        public string Add(TrTrainingCenterCourseVM ID)
        {
            return _Repository.Add(ID);
        }

        public string Update(TrTrainingCenterCourseVM ID)
        {
            return _Repository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _Repository.Delete(ID);
        }
        public List<TrTrainingCenterCourseGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        public TrTrainingCenterCourseGetVM GetById(int ID)
        {
            return _Repository.GetById(ID);
        }
        public PaginatedResult<TrTrainingCenterCourseGetVM> getAllByPagination(int page, int pageSize)
        {
            return _Repository.GetAllByPagination(page, pageSize);
        }
    }
}
