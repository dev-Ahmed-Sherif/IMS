using DAL;
using DAL.TR.Course;
using Entities.ViewModels.TR.Course;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Course.TrTrackRepository;

namespace Business.TR.Course
{
    public class TrTrackService
    {
        public TrTrackRepository _TrTrackRepository;
        public TrTrackService(TrTrackRepository TrTrackRepository)
        {
            _TrTrackRepository = TrTrackRepository;
        }
        public string Add(TrTrackGeneralVM TR_Track)
        {
            return _TrTrackRepository.Add(TR_Track);
        }
        public string Update(TrTrackVM TR_Track)
        {
            return _TrTrackRepository.Update(TR_Track);
        }
        public string Delete(int TRTrack_Id)
        {
            return _TrTrackRepository.Delete(TRTrack_Id);
        }
        public List<TrTrackGetVM> GetAll()
        {
            return _TrTrackRepository.GetAll();
        }
        public TrTrackGetVM GetById(int TrackId)
        {
            return _TrTrackRepository.GetById(TrackId);
        }
        public PaginatedResult<TrTrackGetVM> getAllByPagination(int page, int pageSize)
        {
            return _TrTrackRepository.GetAllByPagination(page, pageSize);
        }
    }
}
