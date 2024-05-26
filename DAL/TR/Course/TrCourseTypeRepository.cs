using Entities.Models.TR.Course;
using Entities.ViewModels.TR.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Course
{
    public class TrCourseTypeRepository
    {
        private AppDbContext _context;

        public TrCourseTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrCourseTypeGeneralVM TR_CourseType)
        {
         
                var _Tr_CourseType = new TrCourseType()
                {
                    Name = TR_CourseType.Name,


                    CreatedByID = TR_CourseType.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrCourseType.Add(_Tr_CourseType);
                _context.SaveChanges();
                return _Tr_CourseType.Id.ToString();
         
        }
        //------------------------
        // Update Data { By id  )} 
        //------------------------
        public string Update(TrCourseTypeVM TR_CourseType)
        {
          
                var _TR_CourseType = _context.TrCourseType.Single(n => n.Id == TR_CourseType.Id);
              
                    _TR_CourseType.Name = TR_CourseType.Name;


                    _TR_CourseType.UpdateByID = TR_CourseType.TransactionUserId;
                    _TR_CourseType.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
           
            
        }
        //------------------------------
        // Delete Data { By id => instId )} 
        //------------------------------
        public string Delete(int TRCourseType_Id)
        {
           
                var _TR_CourseType = _context.TrCourseType.Single(n => n.Id == TRCourseType_Id);
              

                    var DetailsToDelete = _context.TrCourse.Where(n => n.CourseTypeId == TRCourseType_Id).ToList();
                    
                        _context.TrCourse.RemoveRange(DetailsToDelete);
                        _context.SaveChanges();
                   
                    _context.TrCourseType.Remove(_TR_CourseType);
                    _context.SaveChanges();
                    return "Succeeded";
                
        }
        //--------------------------
        // GET All { For all Data )} 
        //--------------------------
        public List<TrCourseTypeGetVM> GetAll()
          => _context.TrCourseType.Select(
              n => new TrCourseTypeGetVM
              {
                  Id = n.Id,
                  Name = n.Name,
                  CreateUserName = n.CreatedBy.Name,
                  TransactionUserId = n.CreatedBy.Id
              }).ToList();
        //---------------------------------
        // GET All Data { By id => TRCourseType_Id )} 
        //---------------------------------
        public TrCourseTypeGetVM GetById(int TRCourseType_Id)
            => _context.TrCourseType.Select(
                n => new TrCourseTypeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,

                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == TRCourseType_Id);



        public List<TrCourseTypeGetVM> Search(TrCourseTypeSearch searchModel)
        {

            return new List<TrCourseTypeGetVM>() ;

        }



        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<TrCourseTypeGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrCourseType.Count();
            List<TrCourseTypeGetVM> Item = _context.TrCourseType
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrCourseTypeGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrCourseTypeGetVM>
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
