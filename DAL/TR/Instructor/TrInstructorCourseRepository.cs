using Entities.Models.TR.Instructor;
using Entities.ViewModels.TR.Instructor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Instructor
{
    public class TrInstructorCourseRepository
    {
        private AppDbContext _context;
        public TrInstructorCourseRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrInstructorCourseGeneralVM Inst)
        {
            
                var _Inst = new TrInstructorCourse()
                {
                    Rating = Inst.Rating,
                    price = Inst.price,
                    Notes = Inst.Notes,
                    CourseId = Inst.CourseId,
                    InstructorId = Inst.InstructorId,
                    CreatedByID = Inst.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrInstructorCourse.Add(_Inst);
                _context.SaveChanges();
                return _Inst.Id.ToString();
          
        }
        //-------------------------------
        // Update Data { By id => inst.id )} 
        //-------------------------------
        public string Update(TrInstructorCourseVM Inst)
        {
          
                var _item = _context.TrInstructorCourse.Single(n => n.Id == Inst.Id);
               


                    _item.CourseId = Inst.CourseId;
                    _item.InstructorId = Inst.InstructorId;
                    _item.Rating = Inst.Rating;
                    _item.price = Inst.price;
                    _item.Notes = Inst.Notes;

                    _item.UpdateByID = Inst.TransactionUserId;
                    _item.LastUpdateDate = DateTime.Now;
                    _context.SaveChanges();
                    return "Succeeded";
                
              
        }
        //------------------------------
        // Delete Data { By id => instId )} 
        //------------------------------
        public string Delete(int InstId)
        {
           
                var _receipt = _context.TrInstructorCourse.Single(n => n.Id == InstId);
               
                    _context.TrInstructorCourse.Remove(_receipt);
                    _context.SaveChanges();
                    return "Succeeded";
             

        }
        //--------------------------
        // GET All { For all Data )} 
        //--------------------------
        public List<TrInstructorCourseGetVM> GetAll()
            => _context.TrInstructorCourse.Select(
                n => new TrInstructorCourseGetVM
                {
                    Id = n.Id,
                    Rating = n.Rating,
                    price = n.price,
                    Notes = n.Notes,
                    CourseName = n.Course.Name,
                    CourseId = n.CourseId,
                    InstructorId = n.InstructorId,
                    HeaderName = n.Instructor.EmployeeId == null ? n.Instructor.InstructorData.Name : n.Instructor.Employee.Name,
                    employeeName = n.Instructor.EmployeeId != null ? n.Instructor.Employee.Name : null,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //---------------------------------
        // GET All Data { By id => itemId )} 
        //---------------------------------
        public TrInstructorCourseGetVM GetById(int itemId)
            => _context.TrInstructorCourse.Select(
                n => new TrInstructorCourseGetVM
                {
                    Id = n.Id,
                    Rating = n.Rating,
                    price = n.price,
                    Notes = n.Notes,
                    CourseName = n.Course.Name,
                    CourseId = n.CourseId,
                    InstructorId = n.InstructorId,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).FirstOrDefault(n => n.Id == itemId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<TrInstructorCourseGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrInstructorCourse.Count();
            List<TrInstructorCourseGetVM> Item = _context.TrInstructorCourse
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrInstructorCourseGetVM
                {
                    Id = n.Id,
                    Rating = n.Rating,
                    price = n.price,
                    Notes = n.Notes,
                    CourseName = n.Course.Name,
                    CourseId = n.CourseId,
                    InstructorId = n.InstructorId,
                    //InstructorId = n.InstructorId,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrInstructorCourseGetVM>
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

