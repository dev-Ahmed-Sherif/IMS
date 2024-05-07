using DAL;
using DAL.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.PY.PyItemGroupRepository;

namespace Business.PY
{
    public class PyItemGroupService
    {
        public PyItemGroupRepository _PyItemGroupRepository;
        public PyItemGroupService(PyItemGroupRepository PyItemGroupRepository)
        {
            _PyItemGroupRepository = PyItemGroupRepository;
        }
        public string Add(PyItemGroupVM ItemGroup)
        {
            return _PyItemGroupRepository.Add(ItemGroup);
        }

        public string Update(PyItemGroupVM ItemGroup)
        {
            return _PyItemGroupRepository.Update(ItemGroup);
        }

        public string Delete(int ItemGroupId)
        {
            return _PyItemGroupRepository.Delete(ItemGroupId);
        }
        public List<PyItemGroupGetVM> GetAll()
        {
            return _PyItemGroupRepository.GetAll();
        }
        public PyItemGroupGetVM GetById(int ItemGroupId)
        {
            return _PyItemGroupRepository.GetById(ItemGroupId);
        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //----------------------------------------------------------
        public PaginatedResult<PyItemGroupGetVM> GetAllByPagination(int page, int pageSize)
        {
            return _PyItemGroupRepository.GetAllByPagination(page, pageSize);
        }

    }
}

