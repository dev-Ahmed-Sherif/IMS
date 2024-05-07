using Entities.Models.TR.Course;
using Entities.ViewModels.TR.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Course
{
    public class TrCourseRepository
    {
        private AppDbContext _context;

        public TrCourseRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrCourseGeneralVM TR_Course)
        {
                var _Tr_Course = new TrCourse()
                {
                    Name = TR_Course.Name,
                    Description = TR_Course.Description,
                    Hours = TR_Course.Hours,
                    Cost = TR_Course.Cost,
                    Price = TR_Course.Price,
                    IsActive = TR_Course.IsActive,
                    CategoryId = TR_Course.CategoryId,
                    CourseTypeId = TR_Course.CourseTypeId,
                    CreatedByID = TR_Course.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrCourse.Add(_Tr_Course);
                _context.SaveChanges();
                return _Tr_Course.Id.ToString();
           
        }
        //------------------------
        // Update Data { By id  )} 
        //------------------------
        public string Update(TrCourseVM TR_Course)
        {
          
                var _TR_Course = _context.TrCourse.Single(n => n.Id == TR_Course.Id);
            
                    _TR_Course.Name = TR_Course.Name;
                    _TR_Course.Description = TR_Course.Description;
                    _TR_Course.Hours = TR_Course.Hours;
                    _TR_Course.Cost = TR_Course.Cost;
                    _TR_Course.Price = TR_Course.Price;
                    _TR_Course.IsActive = TR_Course.IsActive;
                    _TR_Course.CategoryId = TR_Course.CategoryId;
                    _TR_Course.CourseTypeId = TR_Course.CourseTypeId;
                    _TR_Course.UpdateByID = TR_Course.TransactionUserId;
                    _TR_Course.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        //------------------------------
        // Delete Data { By id => instId )} 
        //------------------------------
        public string Delete(int TR_Course_Id)
        {
          
                var _TR_Course = _context.TrCourse.Single(n => n.Id == TR_Course_Id);
             

                    var DetailsToDelete = _context.TrInstructorCourse.Where(n => n.CourseId == TR_Course_Id).ToList();
                    if (DetailsToDelete != null)
                    {
                        _context.TrInstructorCourse.RemoveRange(DetailsToDelete);
                        _context.SaveChanges();
                    }
                    _context.TrCourse.Remove(_TR_Course);
                    _context.SaveChanges();
                    return "Succeeded";
           
        }
        //--------------------------
        // GET All { For all Data )} 
        //--------------------------
        public List<TrCourseGetVM> GetAll()
          => _context.TrCourse.Select(
              n => new TrCourseGetVM
              {
                  Id = n.Id,
                  Name = n.Name,
                  Description = n.Description,
                  Price = n.Price,
                  Cost = n.Cost,
                  Hours = n.Hours,
                  IsActive = n.IsActive,
                  CategoryId = n.CategoryId,
                  CourseTypeId = n.CourseTypeId,
                  CreateUserName = n.CreatedBy.Name,
                  TransactionUserId = n.CreatedBy.Id,
                  CourseTypeName = n.CourseType.Name,
                  CourseCategoryName = n.Category.Name
              }).ToList();
        //---------------------------------
        // GET All Data { By id => TRCourseId )} 
        //---------------------------------
        public TrCourseGetVM GetById(int TRCourseId)
            => _context.TrCourse.Select(
                n => new TrCourseGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    Price = n.Price,
                    Cost = n.Cost,
                    Hours = n.Hours,
                    IsActive = n.IsActive,
                    CategoryId = n.CategoryId,
                    CourseTypeId = n.CourseTypeId,
                    CourseTypeName = n.CourseType.Name,
                    CourseCategoryName = n.Category.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == TRCourseId);

        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<TrCourseGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrTrack.Count();
            List<TrCourseGetVM> Item = _context.TrCourse
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrCourseGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    Price = n.Price,
                    Cost = n.Cost,
                    Hours = n.Hours,
                    IsActive = n.IsActive,
                    CategoryId = n.CategoryId,
                    CourseTypeId = n.CourseTypeId,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id,
                    CourseTypeName = n.CourseType.Name,
                    CourseCategoryName = n.Category.Name
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrCourseGetVM>
            {
                Items = Item,
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };

            return paginatedResult;
        }

        public class PaginatedResult<T>
        {
            public List<T> Items { get; set; }
            public int TotalItems { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
        }
    }
}
