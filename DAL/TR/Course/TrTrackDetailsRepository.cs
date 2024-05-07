using Entities.Models.TR.Course;
using Entities.ViewModels.TR.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Course
{
    public class TrTrackDetailsRepository
    {
        private AppDbContext _context;
        public TrTrackDetailsRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrTrackDetailsGeneralVM Inst)
        {
                var _Inst = new TrTrackDetails()
                {

                    CourseId = Inst.CourseId,
                    TrackId = Inst.TrackId,
                    CreatedByID = Inst.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrTrackDetails.Add(_Inst);
                _context.SaveChanges();
                return _Inst.Id.ToString();
            
        }
        //------------------------
        // Update Data { By id  )} 
        //------------------------
        public string Update(TrTrackDetailsVM Inst)
        {
           
                var _item = _context.TrTrackDetails.Single(n => n.Id == Inst.Id);
             


                    _item.CourseId = Inst.CourseId;
                    _item.TrackId = Inst.TrackId;


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
          
                var _receipt = _context.TrTrackDetails.Single(n => n.Id == InstId);
                
                    _context.TrTrackDetails.Remove(_receipt);
                    _context.SaveChanges();
                    return "Succeeded";
              

        }
        //--------------------------
        // GET All { For all Data )} 
        //--------------------------
        public List<TrTrackDetailsGetVM> GetAll()
            => _context.TrTrackDetails.Select(
                n => new TrTrackDetailsGetVM
                {
                    Id = n.Id,
                    CourseId = n.CourseId,
                    CourseName = n.Course.Name,
                    HeaderName = n.Track.Name,
                    TrackId = n.TrackId,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).ToList();
        //---------------------------------
        // GET All Data { By id => itemId )} 
        //---------------------------------
        public TrTrackDetailsGetVM GetById(int itemId)
            => _context.TrTrackDetails.Select(
                n => new TrTrackDetailsGetVM
                {
                    Id = n.Id,
                    CourseId = n.CourseId,
                    CourseName = n.Course.Name,
                    HeaderName = n.Track.Name,
                    TrackId = n.TrackId,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == itemId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<TrTrackDetailsGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrTrackDetails.Count();
            List<TrTrackDetailsGetVM> Item = _context.TrTrackDetails
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrTrackDetailsGetVM
                {
                    Id = n.Id,
                    CourseId = n.CourseId,
                    CourseName = n.Course.Name,
                    HeaderName = n.Track.Name,
                    TrackId = n.TrackId,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrTrackDetailsGetVM>
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
        //---------------------------------------------------
        // GET { Data From Table By HeaderID } 
        //---------------------------------------------------
        public List<TrTrackDetailsGetVM> GetByHeader(int HeaderId)
           => _context.TrTrackDetails
              .Where(n => n.TrackId == HeaderId)
                        .Select(n => new TrTrackDetailsGetVM
                        {
                            Id = n.Id,
                            CourseId = n.CourseId,
                            CourseName = n.Course.Name,
                            TrackId = n.TrackId,
                            HeaderName = n.Track.Name,
                            HeaderDescription = n.Track.Description,
                            HeaderPrice = n.Track.Price,
                            CreateUserName = n.CreatedBy.Name,
                            TransactionUserId = n.CreatedBy.Id,

                        }).ToList();
        //---------
        // Search 
        //---------
        public List<TrTrackDetailsGetVM> Search(search searchModel)
        {
            var query = _context.TrTrackDetails.AsQueryable();

            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.CreationDate >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                query = query.Where(p => p.CreationDate <= searchModel.EndDate.Value.Date);
            }
            if (searchModel.TrackId.HasValue)
            {
                query = query.Where(p => p.TrackId == searchModel.TrackId);
            }
            if (searchModel.CourseId.HasValue)
            {
                query = query.Where(p => p.CourseId == searchModel.CourseId);
            }

            var results = query.Select(n => new TrTrackDetailsGetVM
            {
                Id = n.Id,
                CourseId = n.CourseId,
                CourseName = n.Course.Name,
                HeaderName = n.Track.Name,
                TrackId = n.TrackId,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();

            return results;

        }
    }
}

