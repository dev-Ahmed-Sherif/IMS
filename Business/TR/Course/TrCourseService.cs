using DAL;
using DAL.TR.Course;
using Entities.ViewModels.TR.Course;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Course.TrCourseRepository;

namespace Business.TR.Course
{
    public class TrCourseService
    {
        public TrCourseRepository _Repository;
        public TrCourseService(TrCourseRepository TrCourseRepository)
        {
            _Repository = TrCourseRepository;
        }
        public string Add(TrCourseGeneralVM TR_Course)
        {
            return _Repository.Add(TR_Course);
        }
        public string Update(TrCourseVM TR_Course)
        {
            return _Repository.Update(TR_Course);
        }
        public string Delete(int TR_Course_Id)
        {
            return _Repository.Delete(TR_Course_Id);
        }
        public List<TrCourseGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        public TrCourseGetVM GetById(int TRCourseId)
        {
            return _Repository.GetById(TRCourseId);
        }
        public PaginatedResult<TrCourseGetVM> getAllByPagination(int page, int pageSize)
        {
            return _Repository.GetAllByPagination(page, pageSize);
        }
    }
}
