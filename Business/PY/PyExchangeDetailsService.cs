using DAL;
using DAL.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.PY.PyExchangeDetailsRepository;

namespace Business.PY
{
    public class PyExchangeDetailsService
    {
        public PyExchangeDetailsRepository _PyExchangeDetailsRepository;
        public PyExchangeDetailsService(PyExchangeDetailsRepository PyExchangeDetailsRepository)
        {
            _PyExchangeDetailsRepository = PyExchangeDetailsRepository;
        }
        public string Add(PyExchangeDetailsVM ExchangeDetails)
        {
            return _PyExchangeDetailsRepository.Add(ExchangeDetails);
        }

        public string Update(PyExchangeDetailsVM ExchangeDetails)
        {
            return _PyExchangeDetailsRepository.Update(ExchangeDetails);
        }

        public string Delete(int ExchangeDetailsId)
        {
            return _PyExchangeDetailsRepository.Delete(ExchangeDetailsId);
        }
        public List<PyExchangeDetailsGetVM> GetAll()
        {
            return _PyExchangeDetailsRepository.GetAll();
        }
        public PyExchangeDetailsGetVM GetById(int ExchangeDetailsId)
        {
            return _PyExchangeDetailsRepository.GetById(ExchangeDetailsId);
        }
        public List<PyExchangeDetailsGetVM> GetByHeader(int HeaderId)
        {
            return _PyExchangeDetailsRepository.GetByHeader(HeaderId);
        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //----------------------------------------------------------
        public PaginatedResult<PyExchangeDetailsGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _PyExchangeDetailsRepository.GetAllByPagination(page, pageSize, HeaderId);
        }
        public List<PyExchangeDetailsGetVM> Search(search searchModel)
        {
            return _PyExchangeDetailsRepository.Search(searchModel);
        }


    }
}
