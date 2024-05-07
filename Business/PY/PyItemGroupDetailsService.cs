using DAL;
using DAL.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.PY.PyItemGroupDetailsRepository;

namespace Business.PY
{
    public class PyItemGroupDetailsService
    {
        public PyItemGroupDetailsRepository _PyItemGroupDetailsRepository;
        public PyItemGroupDetailsService(PyItemGroupDetailsRepository PyItemGroupDetailsRepository)
        {
            _PyItemGroupDetailsRepository = PyItemGroupDetailsRepository;
        }
        public string Add(PyItemGroupDetailsVM ItemGroupDetails)
        {
            return _PyItemGroupDetailsRepository.Add(ItemGroupDetails);
        }

        public string Update(PyItemGroupDetailsVM ItemGroupDetails)
        {
            return _PyItemGroupDetailsRepository.Update(ItemGroupDetails);
        }

        public string Delete(int ItemGroupDetailsId)
        {
            return _PyItemGroupDetailsRepository.Delete(ItemGroupDetailsId);
        }
        public List<PyItemGroupDetailsGetVM> GetAll()
        {
            return _PyItemGroupDetailsRepository.GetAll();
        }
        public PyItemGroupDetailsGetVM GetById(int ItemGroupDetailsId)
        {
            return _PyItemGroupDetailsRepository.GetById(ItemGroupDetailsId);
        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //----------------------------------------------------------
        public PaginatedResult<PyItemGroupDetailsGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _PyItemGroupDetailsRepository.GetAllByPagination(page, pageSize, HeaderId);
        }

        public List<PyItemGroupDetailsGetVM> GetByHeader(int HeaderId)
        {
            return _PyItemGroupDetailsRepository.GetByHeader(HeaderId);
        }

    }
}
