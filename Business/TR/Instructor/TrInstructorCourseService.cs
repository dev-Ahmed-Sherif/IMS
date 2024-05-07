using DAL;
using DAL.TR.Instructor;
using Entities.ViewModels.TR.Instructor;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Instructor.TrInstructorCourseRepository;
namespace Business.TR.Instructor
{
    public class TrInstructorCourseService
    {

        public TrInstructorCourseRepository _Repository;


        public TrInstructorCourseService(TrInstructorCourseRepository TrInstructorCourseRepository)
        {
            _Repository = TrInstructorCourseRepository;

        }

        public string Add(TrInstructorCourseGeneralVM sTR_Add)
        {
            return _Repository.Add(sTR_Add);
        }

        public string Update(TrInstructorCourseVM sTR_Add)
        {
            return _Repository.Update(sTR_Add);
        }
        public string Delete(int sTR_Add_Id)
        {
            return _Repository.Delete(sTR_Add_Id);
        }
        public List<TrInstructorCourseGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        public TrInstructorCourseGetVM GetById(int sTR_AddId)
        {
            return _Repository.GetById(sTR_AddId);
        }
        public PaginatedResult<TrInstructorCourseGetVM> getAllByPagination(int page, int pageSize)
        {
            return _Repository.GetAllByPagination(page, pageSize);
        }
    }
}
