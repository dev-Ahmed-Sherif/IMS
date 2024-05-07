using DAL;
using DAL.TR.Course;
using Entities.ViewModels.TR.Course;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Course.TrCourseTypeRepository;

namespace Business.TR.Course
{
    public class TrCourseTypeService
    {
        public TrCourseTypeRepository _Repository;
        public TrCourseTypeService(TrCourseTypeRepository TrCourseTypeRepository)
        {
            _Repository = TrCourseTypeRepository;
        }
        public string Add(TrCourseTypeGeneralVM TR_CourseType)
        {
            return _Repository.Add(TR_CourseType);
        }
        public string Update(TrCourseTypeVM TR_CourseType)
        {
            return _Repository.Update(TR_CourseType);
        }
        public string Delete(int TRCourseType_Id)
        {
            return _Repository.Delete(TRCourseType_Id);
        }
        //--------------------------
        // GET All { For all Data )} 
        //--------------------------
        public List<TrCourseTypeGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        //-------------------
        // GET All Data By ID 
        //-------------------
        public TrCourseTypeGetVM GetById(int TRCourseType_Id)
        {
            return _Repository.GetById(TRCourseType_Id);
        }
        /*------------------------*/
        /* --- GET Pagenation --- */
        /*------------------------*/
        public PaginatedResult<TrCourseTypeGetVM> getAllByPagination(int page, int pageSize)
        {
            return _Repository.GetAllByPagination(page, pageSize);
        }
    }
}
