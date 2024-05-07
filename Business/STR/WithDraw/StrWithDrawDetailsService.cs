using DAL;
using DAL.STR.WithDraw;
using Entities.ViewModels.STR.WithDraw;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DAL.STR.WithDraw.StrWithDrawDetailsRepository;

namespace Business.STR.WithDraw
{
    public class StrWithDrawDetailsService
    {
        public StrWithDrawDetailsRepository _StrWithDrawDetailsRepository;
        public StrWithDrawDetailsService(StrWithDrawDetailsRepository StrWithDrawDetailsRepository)
        {
            _StrWithDrawDetailsRepository = StrWithDrawDetailsRepository;
        }
        public async Task<string> Add(StrWithDrawDetailsVM Type)
        {
            return await _StrWithDrawDetailsRepository.AddAsync(Type);
        }
        public string Update(StrWithDrawDetailsVM item)
        {
            return _StrWithDrawDetailsRepository.Update(item);
        }
        public string Delete(int itemId)
        {
            return _StrWithDrawDetailsRepository.Delete(itemId);
        }
        public List<StrWithDrawDetailsGetVM> GetAll()
        {
            return _StrWithDrawDetailsRepository.GetAll(); ;
        }
        public StrWithDrawDetailsGetVM GetById(int itemId)
        {
            return _StrWithDrawDetailsRepository.GetById(itemId);
        }
        public List<StrWithDrawDetailsGetVM> GetByHeader(int WithDrawId)
        {
            return _StrWithDrawDetailsRepository.GetByHeader(WithDrawId);
        }
        public List<StrWithDrawDetailsGetVM> Search(searchwithdraw searchModel)
        {
            return _StrWithDrawDetailsRepository.Search(searchModel);
        }
        public PaginatedResult<StrWithDrawDetailsGetVM> getAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _StrWithDrawDetailsRepository.GetAllByPagination(page, pageSize, HeaderId);
        }

    }
}
