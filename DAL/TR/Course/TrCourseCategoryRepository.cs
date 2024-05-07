using Entities.Models.TR.Course;
using Entities.ViewModels.TR.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Course
{
    public class TrCourseCategoryRepository
    {
        private AppDbContext _context;

        public TrCourseCategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrCourseCategoryGeneralVM Tr_courseCategory)
        {
           
                var _Tr_courseCategory = new TrCourseCategory()
                {
                    Name = Tr_courseCategory.Name,
                    CreatedByID = Tr_courseCategory.TransactionUserId,


                    CreationDate = DateTime.Now

                };
                _context.TrCourseCategory.Add(_Tr_courseCategory);
                _context.SaveChanges();
                return _Tr_courseCategory.Id.ToString();
             
        }
        public string Update(TrCourseCategoryVM TR_courseCategory)
        {
             var _TR_courseCategory = _context.TrCourseCategory.Single(n => n.Id == TR_courseCategory.Id);
               
                    _TR_courseCategory.Name = TR_courseCategory.Name;


                    _TR_courseCategory.UpdateByID = TR_courseCategory.TransactionUserId;
                    _TR_courseCategory.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
            
        }


        public string Delete(int TRCourseCategory_Id)
        {


           
                var _TR_courseCategory = _context.TrCourseCategory.Single(n => n.Id == TRCourseCategory_Id);
               

                    var DetailsToDelete = _context.TrCourse.Where(n => n.CategoryId == TRCourseCategory_Id).ToList();
                    if (DetailsToDelete != null)
                    {
                        _context.TrCourse.RemoveRange(DetailsToDelete);
                        _context.SaveChanges();
                    }
                    _context.TrCourseCategory.Remove(_TR_courseCategory);
                    _context.SaveChanges();
                    return "Succeeded";
               
              

        }
        public List<TrCourseCategoryGetVM> GetAll()
        => _context.TrCourseCategory.Select(
            n => new TrCourseCategoryGetVM
            {
                Id = n.Id,
                Name = n.Name,

                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();
        public TrCourseCategoryGetVM GetById(int TRCourseCategoryId)
          => _context.TrCourseCategory.Select(
              n => new TrCourseCategoryGetVM
              {
                  Id = n.Id,
                  Name = n.Name,

                  CreateUserName = n.CreatedBy.Name,
                  TransactionUserId = n.CreatedBy.Id
              }).Single(n => n.Id == TRCourseCategoryId);
    }
}
