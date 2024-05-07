using DAL;
using DAL.TR.Course;
using Entities.ViewModels.TR.Course;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Course.TrTrackDetailsRepository;

namespace Business.TR.Course
{
    public class TrTrackDetailService
    {

        public TrTrackDetailsRepository _TrTrackDetailsRepository;


        public TrTrackDetailService(TrTrackDetailsRepository TrTrackDetailsRepository)
        {
            _TrTrackDetailsRepository = TrTrackDetailsRepository;

        }

        public string Add(TrTrackDetailsGeneralVM sTR_Add)
        {
            return _TrTrackDetailsRepository.Add(sTR_Add);
        }

        public string Update(TrTrackDetailsVM sTR_Add)
        {
            return _TrTrackDetailsRepository.Update(sTR_Add);
        }
        public string Delete(int sTR_Add_Id)
        {
            return _TrTrackDetailsRepository.Delete(sTR_Add_Id);
        }
        public List<TrTrackDetailsGetVM> GetAll()
        {
            return _TrTrackDetailsRepository.GetAll();
        }
        public TrTrackDetailsGetVM GetById(int sTR_AddId)
        {
            return _TrTrackDetailsRepository.GetById(sTR_AddId);
        }
        public List<TrTrackDetailsGetVM> GetByHeader(int HeaderId)
        {
            return _TrTrackDetailsRepository.GetByHeader(HeaderId);
        }
        public List<TrTrackDetailsGetVM> Search(search searchModel)
        {
            return _TrTrackDetailsRepository.Search(searchModel);
        }
        /*------------------------*/
        /* --- GET Pagenation --- */
        /*------------------------*/
        public PaginatedResult<TrTrackDetailsGetVM> getAllByPagination(int page, int pageSize)
        {
            return _TrTrackDetailsRepository.GetAllByPagination(page, pageSize);
        }
    }
}
