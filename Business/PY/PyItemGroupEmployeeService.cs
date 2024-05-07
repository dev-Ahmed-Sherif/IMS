using DAL;
using DAL.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.PY.PyItemGroupEmployeeRepository;

namespace Business.PY
{
    public class PyItemGroupEmployeeService
    {
        public PyItemGroupEmployeeRepository _PyItemGroupEmployeeRepository;
        public PyItemGroupEmployeeService(PyItemGroupEmployeeRepository PyItemGroupEmployeeRepository)
        {
            _PyItemGroupEmployeeRepository = PyItemGroupEmployeeRepository;
        }
        public string Add(PyItemGroupEmployeeVM ItemGroupEmployee)
        {
            return _PyItemGroupEmployeeRepository.Add(ItemGroupEmployee);
        }

        public string Update(PyItemGroupEmployeeVM ItemGroupEmployee)
        {
            return _PyItemGroupEmployeeRepository.Update(ItemGroupEmployee);
        }

        public string Delete(int ItemGroupEmployeeId)
        {
            return _PyItemGroupEmployeeRepository.Delete(ItemGroupEmployeeId);
        }
        public List<PyItemGroupEmployeeGetVM> GetAll()
        {
            return _PyItemGroupEmployeeRepository.GetAll();
        }
        public PyItemGroupEmployeeGetVM GetById(int ItemGroupEmployeeId)
        {
            return _PyItemGroupEmployeeRepository.GetById(ItemGroupEmployeeId);
        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //----------------------------------------------------------
        public PaginatedResult<PyItemGroupEmployeeGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _PyItemGroupEmployeeRepository.GetAllByPagination(page, pageSize, HeaderId);
        }
        public List<PyItemGroupEmployeeGetVM> GetByHeader(int HeaderId)
        {
            return _PyItemGroupEmployeeRepository.GetByHeader(HeaderId);
        }

    }
}
