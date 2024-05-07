using Entities.Models.TR.Course;
using Entities.ViewModels.TR.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.TR.Course
{
    public class TrTrackRepository
    {
        private AppDbContext _context;
        public TrTrackRepository(AppDbContext context)
        {
            _context = context;
        }
        //--------------
        // Add Data {  } 
        //--------------
        public string Add(TrTrackGeneralVM TR_Track)
        {
          
                var _Tr_Track = new TrTrack()
                {
                    Name = TR_Track.Name,
                    Description = TR_Track.Description,
                    Price = TR_Track.Price,

                    CreatedByID = TR_Track.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.TrTrack.Add(_Tr_Track);
                _context.SaveChanges();
                return _Tr_Track.Id.ToString();
           
        }
        //------------------------
        // Update Data { By id  )} 
        //------------------------
        public string Update(TrTrackVM TR_Track)
        {
           
                var _TR_Track = _context.TrTrack.Single(n => n.Id == TR_Track.Id);
               
                    _TR_Track.Name = TR_Track.Name;
                    _TR_Track.Description = TR_Track.Description;
                    _TR_Track.Price = TR_Track.Price;

                    _TR_Track.UpdateByID = TR_Track.TransactionUserId;
                    _TR_Track.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
            
        }
        //------------------------------
        // Delete Data { By id => instId )} 
        //------------------------------
        public string Delete(int TRTrack_Id)
        {
            
                var _TR_Track = _context.TrTrack.Single(n => n.Id == TRTrack_Id);
               
                    var DetailsToDelete = _context.TrTrackDetails.Where(n => n.TrackId == TRTrack_Id).ToList();
                    if (DetailsToDelete != null)
                    {
                        _context.TrTrackDetails.RemoveRange(DetailsToDelete);
                        _context.SaveChanges();
                    }
                    _context.TrTrack.Remove(_TR_Track);
                    _context.SaveChanges();
                    return "Succeeded";
             

        }
        //--------------------------
        // GET All { For all Data )} 
        //--------------------------
        public List<TrTrackGetVM> GetAll()
          => _context.TrTrack.Select(
              n => new TrTrackGetVM
              {
                  Id = n.Id,
                  Name = n.Name,
                  Description = n.Description,
                  Price = n.Price,
                  CreateUserName = n.CreatedBy.Name,
                  TransactionUserId = n.CreatedBy.Id
              }).ToList();
        //---------------------------------
        // GET All Data { By id => TrackId )} 
        //---------------------------------
        public TrTrackGetVM GetById(int TrackId)
            => _context.TrTrack.Select(
                n => new TrTrackGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    Price = n.Price,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                }).Single(n => n.Id == TrackId);
        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<TrTrackGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.TrTrack.Count();
            List<TrTrackGetVM> Item = _context.TrTrack
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new TrTrackGetVM
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    Price = n.Price,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id
                })
                .ToList();

            var paginatedResult = new PaginatedResult<TrTrackGetVM>
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
