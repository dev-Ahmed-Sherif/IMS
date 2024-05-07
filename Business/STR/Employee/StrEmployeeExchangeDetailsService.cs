using DAL;
using DAL.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.STR.Employee.StrEmployeeExchangeDetailsRepository;

namespace Business.STR.Employee
{
    public class StrEmployeeExchangeDetailsService
    {
        public StrEmployeeExchangeDetailsRepository _STR_Employee_Exchange_DetailsRepository;
        public StrEmployeeExchangeDetailsService(StrEmployeeExchangeDetailsRepository StrEmployeeExchangeDetailsRepository)
        {
            _STR_Employee_Exchange_DetailsRepository = StrEmployeeExchangeDetailsRepository;
        }
        public string Add(StrEmployeeExchangeDetailsGeneralVM exch)
        {
            return _STR_Employee_Exchange_DetailsRepository.Add(exch);
        }
        public string Update(StrEmployeeExchangeDetailsVM exchdet)
        {
            return _STR_Employee_Exchange_DetailsRepository.Update(exchdet);
        }
        public string Delete(int Id)
        {
            return _STR_Employee_Exchange_DetailsRepository.Delete(Id);
        }
        public List<StrEmployeeExchangeDetailsGetVM> GetAll()
        {
            return _STR_Employee_Exchange_DetailsRepository.GetAll();
        }
        public StrEmployeeExchangeDetailsGetVM GetById(int exchId)
        {
            return _STR_Employee_Exchange_DetailsRepository.GetById(exchId);
        }
        public List<StrEmployeeExchangeDetailsGetVM> GetByHeader(int exchId)
        {
            return _STR_Employee_Exchange_DetailsRepository.GetByHeader(exchId);
        }
        public List<StrEmployeeExchangeDetailsGetVM> search(searchemployeeexchange searchModel)
        {
            return _STR_Employee_Exchange_DetailsRepository.search(searchModel);
        }

        public PaginatedResult<StrEmployeeExchangeDetailsGetVM> getAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _STR_Employee_Exchange_DetailsRepository.GetAllByPagination(page, pageSize, HeaderId);
        }

    }
}
