using DAL;
using DAL.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.STR.Employee.StrEmployeeOpeningCustodyDetailsRepository;

namespace Business.STR.Employee
{
    public class StrEmployeeOpeningCustodyDetailsService
    {
        public StrEmployeeOpeningCustodyDetailsRepository _StrEmployeeOpeningCustodyDetailsService;
        public StrEmployeeOpeningCustodyDetailsService(StrEmployeeOpeningCustodyDetailsRepository StrEmployeeOpeningCustodyDetailsRepository)
        {
            _StrEmployeeOpeningCustodyDetailsService = StrEmployeeOpeningCustodyDetailsRepository;
        }
        public string Add(StrEmployeeOpeningCustodyDetailsVM STR_Employee_Opening_Custody_Details)
        {
            return _StrEmployeeOpeningCustodyDetailsService.Add(STR_Employee_Opening_Custody_Details);
        }
        public string Update(StrEmployeeOpeningCustodyDetailsVM STR_Employee_Opening_Custody_Details)
        {
            return _StrEmployeeOpeningCustodyDetailsService.Update(STR_Employee_Opening_Custody_Details);
        }
        public string Delete(int itemId)
        {
            return _StrEmployeeOpeningCustodyDetailsService.Delete(itemId);
        }
        public List<StrEmployeeOpeningCustodyDetailsGetVM> GetAll()
        {
            return _StrEmployeeOpeningCustodyDetailsService.GetAll();
        }
        public StrEmployeeOpeningCustodyDetailsGetVM GetById(int itemId)
        {
            return _StrEmployeeOpeningCustodyDetailsService.GetById(itemId);
        }
        public List<StrEmployeeOpeningCustodyDetailsGetVM> GetByHeader(int Id)
        {
            return _StrEmployeeOpeningCustodyDetailsService.GetByHeader(Id);
        }
        public List<StrEmployeeOpeningCustodyDetailsGetVM> search(searchemployeeopeningcustody searchModel)
        {
            return _StrEmployeeOpeningCustodyDetailsService.search(searchModel);
        }
        public PaginatedResult<StrEmployeeOpeningCustodyDetailsGetVM> getAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _StrEmployeeOpeningCustodyDetailsService.GetAllByPagination(page, pageSize, HeaderId);
        }

    }
}
