using Entities.Models.TR;
using Entities.ViewModels.TR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Training
{
    public class TrTrainingCenterCourseRepository
    {

        private AppDbContext _context;
        public TrTrainingCenterCourseRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrTrainingCenterCourseVM TrainingCenterCourse)
        {
           
                var _TrainingCenterCourse = new TrTrainingCenterCourse()
                {
                    Rating = TrainingCenterCourse.Rating,
                    Price = TrainingCenterCourse.Price,
                    Notes = TrainingCenterCourse.Notes,
                    CourseId = TrainingCenterCourse.CourseId,
                    TrainingCenterId = TrainingCenterCourse.TrainingCenterId,





                    CreatedByID = TrainingCenterCourse.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.TrTrainingCenterCourse.Add(_TrainingCenterCourse);
                _context.SaveChanges();
                return "Succeeded";
           
        }
        //--------------------------------------------------
        // Update Data { By id => TrainingCenterCourse.id )} 
        //--------------------------------------------------
        public string Update(TrTrainingCenterCourseVM TrainingCenterCourse)
        {
         
                var _TrainingCenterCourse = _context.TrTrainingCenterCourse.Single(n => n.Id == TrainingCenterCourse.Id);
               
                    _TrainingCenterCourse.Rating = TrainingCenterCourse.Rating;
                    _TrainingCenterCourse.Price = TrainingCenterCourse.Price;
                    _TrainingCenterCourse.Notes = TrainingCenterCourse.Notes;
                    _TrainingCenterCourse.CourseId = TrainingCenterCourse.CourseId;
                    _TrainingCenterCourse.TrainingCenterId = TrainingCenterCourse.TrainingCenterId;


                    _TrainingCenterCourse.UpdateByID = TrainingCenterCourse.TransactionUserId;
                    _TrainingCenterCourse.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
          
        }
        //--------------------------------------------------
        // Delete Data { By id => TrainingCentereCourseId )} 
        //--------------------------------------------------
        public string Delete(int TrainingCentereCourseId)
        {
           
                var _TrainingCenterCourse = _context.TrTrainingCenterCourse.Single(n => n.Id == TrainingCentereCourseId);
              
                    _context.TrTrainingCenterCourse.Remove(_TrainingCenterCourse);
                    _context.SaveChanges();
                    return "Succeeded";
           
        }
        //--------------------------
        // GET All { For all Data )} 
        //--------------------------
        public List<TrTrainingCenterCourseGetVM> GetAll()
            => _context.TrTrainingCenterCourse.Select(
                n => new TrTrainingCenterCourseGetVM
                {
                    Id = n.Id,
                    Rating = n.Rating,
                    Price = n.Price,
                    Notes = n.Notes,
                    CourseId = n.CourseId,
                    CourseName = n.Course.Name,
                    TrainingCenterId = n.TrainingCenterId,
                    TraingingCenterName = n.TrainingCenter.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //-------------------------------------------------
        // GET All Data { By id => TrainingCenterCourseId )} 
        //-------------------------------------------------
        public TrTrainingCenterCourseGetVM GetById(int TrainingCenterCourseId)
            => _context.TrTrainingCenterCourse.Select(
                n => new TrTrainingCenterCourseGetVM
                {
                    Id = n.Id,
                    Rating = n.Rating,
                    Price = n.Price,
                    Notes = n.Notes,
                    CourseId = n.CourseId,
                    CourseName = n.Course.Name,
                    TrainingCenterId = n.TrainingCenterId,
                    TraingingCenterName = n.TrainingCenter.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == TrainingCenterCourseId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<TrTrainingCenterCourseGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrTrainingCenterCourse.Count();
            List<TrTrainingCenterCourseGetVM> Item = _context.TrTrainingCenterCourse
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrTrainingCenterCourseGetVM
                {
                    Id = n.Id,
                    Rating = n.Rating,
                    Price = n.Price,
                    Notes = n.Notes,
                    CourseId = n.CourseId,
                    CourseName = n.Course.Name,
                    TrainingCenterId = n.TrainingCenterId,
                    TraingingCenterName = n.TrainingCenter.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrTrainingCenterCourseGetVM>
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
