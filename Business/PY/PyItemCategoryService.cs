using DAL;
using DAL.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.PY.PyItemCategoryRepository;

namespace Business.PY
{
    public class PyItemCategoryService
    {
        public PyItemCategoryRepository _PyItemCategoryRepository;
        public PyItemCategoryService(PyItemCategoryRepository PyItemCategoryRepository)
        {
            _PyItemCategoryRepository = PyItemCategoryRepository;
        }
        public string Add(PyItemCategoryVM ItemCategory)
        {
            return _PyItemCategoryRepository.Add(ItemCategory);
        }

        public string Update(PyItemCategoryVM ItemCategory)
        {
            return _PyItemCategoryRepository.Update(ItemCategory);
        }

        public string Delete(int ItemCategoryId)
        {
            return _PyItemCategoryRepository.Delete(ItemCategoryId);
        }
        public List<PyItemCategoryGetVM> GetAll()
        {
            return _PyItemCategoryRepository.GetAll();
        }
        public PyItemCategoryGetVM GetById(int ItemCategoryId)
        {
            return _PyItemCategoryRepository.GetById(ItemCategoryId);
        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //----------------------------------------------------------
        public PaginatedResult<PyItemCategoryGetVM> GetAllByPagination(int page, int pageSize)
        {
            return _PyItemCategoryRepository.GetAllByPagination(page, pageSize);
        }

    }
}
