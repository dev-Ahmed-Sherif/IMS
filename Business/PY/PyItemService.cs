using DAL;
using DAL.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.PY.PyItemRepository;

namespace Business.PY
{
    public class PyItemService
    {
        public PyItemRepository _PyItemRepository;
        public PyItemService(PyItemRepository PyItemRepository)
        {
            _PyItemRepository = PyItemRepository;
        }
        public string Add(PyItemVM Item)
        {
            return _PyItemRepository.Add(Item);
        }

        public string Update(PyItemVM Item)
        {
            return _PyItemRepository.Update(Item);
        }

        public string Delete(int ItemId)
        {
            return _PyItemRepository.Delete(ItemId);
        }
        public List<PyItemGetVM> GetAll()
        {
            return _PyItemRepository.GetAll();
        }
        public PyItemGetVM GetById(int ItemId)
        {
            return _PyItemRepository.GetById(ItemId);
        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //----------------------------------------------------------
        public PaginatedResult<PyItemGetVM> GetAllByPagination(int page, int pageSize)
        {
            return _PyItemRepository.GetAllByPagination(page, pageSize);
        }
        public List<PyItemGetVM> GetByHeader(int HeaderId)
        {
            return _PyItemRepository.GetByHeader(HeaderId);
        }

    }
}
