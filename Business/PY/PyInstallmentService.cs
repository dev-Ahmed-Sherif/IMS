using DAL;
using DAL.PY;
using Entities.ViewModels.PY;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.PY.PyInstallmentRepository;

namespace Business.PY
{
    public class PyInstallmentService
    {
        public PyInstallmentRepository _PyInstallmentRepository;
        public PyInstallmentService(PyInstallmentRepository PyInstallmentRepository)
        {
            _PyInstallmentRepository = PyInstallmentRepository;
        }
        public string Add(PyInstallmentVM Installment)
        {
            return _PyInstallmentRepository.Add(Installment);
        }

        public string Update(PyInstallmentVM Installment)
        {
            return _PyInstallmentRepository.Update(Installment);
        }

        public string Delete(int InstallmentId)
        {
            return _PyInstallmentRepository.Delete(InstallmentId);
        }
        public List<PyInstallmentGetVM> GetAll()
        {
            return _PyInstallmentRepository.GetAll();
        }
        public PyInstallmentGetVM GetById(int InstallmentId)
        {
            return _PyInstallmentRepository.GetById(InstallmentId);
        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //----------------------------------------------------------
        public PaginatedResult<PyInstallmentGetVM> GetAllByPagination(int page, int pageSize)
        {
            return _PyInstallmentRepository.GetAllByPagination(page, pageSize);
        }


    }
}
