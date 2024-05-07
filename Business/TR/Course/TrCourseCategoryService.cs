using DAL;
using DAL.TR.Course;
using Entities.ViewModels.TR.Course;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.TR.Course
{
    public class TrCourseCategoryService
    {
        public TrCourseCategoryRepository _Repository;
        public TrCourseCategoryService(TrCourseCategoryRepository TrCourseCategoryRepository)
        {
            _Repository = TrCourseCategoryRepository;
        }

        public string Add(TrCourseCategoryGeneralVM TR_courseCategory)
        {
            return _Repository.Add(TR_courseCategory);
        }
        public string Update(TrCourseCategoryVM TR_courseCategory)
        {
            return _Repository.Update(TR_courseCategory);
        }
        public string Delete(int TRCourseCategory_Id)
        {
            return _Repository.Delete(TRCourseCategory_Id);
        }
        public List<TrCourseCategoryGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        public TrCourseCategoryGetVM GetById(int TRCourseCategoryId)
        {
            return _Repository.GetById(TRCourseCategoryId);
        }
        //public PaginatedResult<TrPurposeGetVM> getAllByPagination(int page, int pageSize)
        //{
        //    return _TrPurposeRepository.GetAllByPagination(page, pageSize);
        //}
    }
}
