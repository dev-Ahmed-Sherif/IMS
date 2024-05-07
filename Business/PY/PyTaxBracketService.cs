using DAL;
using DAL.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.PY.PyTaxBracketRepository;

namespace Business.PY
{
    public class PyTaxBracketService
    {
        public PyTaxBracketRepository _PyTaxBracketRepository;
        public PyTaxBracketService(PyTaxBracketRepository PyTaxBracketRepository)
        {
            _PyTaxBracketRepository = PyTaxBracketRepository;
        }
        public string Add(PyTaxBracketVM TaxBracket)
        {
            return _PyTaxBracketRepository.Add(TaxBracket);
        }

        public string Update(PyTaxBracketVM TaxBracket)
        {
            return _PyTaxBracketRepository.Update(TaxBracket);
        }

        public string Delete(int TaxBracketId)
        {
            return _PyTaxBracketRepository.Delete(TaxBracketId);
        }
        public List<PyTaxBracketGetVM> GetAll()
        {
            return _PyTaxBracketRepository.GetAll();
        }
        public PyTaxBracketGetVM GetById(int TaxBracketId)
        {
            return _PyTaxBracketRepository.GetById(TaxBracketId);
        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //----------------------------------------------------------
        public PaginatedResult<PyTaxBracketGetVM> GetAllByPagination(int page, int pageSize)
        {
            return _PyTaxBracketRepository.GetAllByPagination(page, pageSize);
        }

    }
}
