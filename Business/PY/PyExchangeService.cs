using DAL;
using DAL.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.PY
{
    public class PyExchangeService
    {
        public PyExchangeRepository _PyExchangeRepository;
        public PyExchangeService(PyExchangeRepository PyExchangeRepository)
        {
            _PyExchangeRepository = PyExchangeRepository;
        }
        public string Add(PyExchangeVM Exchange)
        {
            return _PyExchangeRepository.Add(Exchange);
        }

        public string Update(PyExchangeVM Exchange)
        {
            return _PyExchangeRepository.Update(Exchange);
        }

        public string Delete(int ExchangeId)
        {
            return _PyExchangeRepository.Delete(ExchangeId);
        }
        public List<PyExchangeGetVM> GetAll()
        {
            return _PyExchangeRepository.GetAll();
        }
        public PyExchangeGetVM GetById(int ExchangeId)
        {
            return _PyExchangeRepository.GetById(ExchangeId);
        }
        public PyExchangeRepository.PaginatedResult<PyExchangeGetVM> getAllByPagination(int page, int pageSize)
        {
            return _PyExchangeRepository.getAllByPagination(page, pageSize);
        }
        public List<PyExchangeGetVM> Search(search searchModel)
        {
            return _PyExchangeRepository.Search(searchModel);
        }

    }
}
