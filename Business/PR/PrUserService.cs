using DAL;
using DAL.PR;
using Entities.ViewModels;
using Entities.ViewModels.PR;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.PR
{
    public class PrUserService
    {
        public PrUserRepository _PRRepository;
        public PrUserService(PrUserRepository PrUserRepository)
        {
            _PRRepository = PrUserRepository;
        }
        public string Add(PrUserVM user)
        {
            return _PRRepository.Add(user);
        }

        public string Update(PrUserVM user)
        {
            return _PRRepository.Update(user);
        }
        public string Delete(int id)
        {
            return _PRRepository.Delete(id);
        }
        public List<PrUserVM> GetAll(UserFilter filter)
        {
            return _PRRepository.GetAll(filter);
        }

        public PaginatedResult<PrUserVM> GetAllPaginated(int pageIndex, int pageSize, UserFilter filter)
        {
            return _PRRepository.GetAllPaginated(pageIndex, pageSize, filter);
        }
        public PrUserVM GetById(int userId)
        {
            return _PRRepository.GetById(userId);
        }
        public PrUserVM GetUserGroup(int userId)
        {
            return _PRRepository.GetUserGroup(userId);
        }
        public async Task<UserVM> authentication(UserLogin login)
        {
            return await _PRRepository.authenticationAsync(login);
        }
        public List<FiscalYearData> GetFiscalYear(string fiscalyear)
        {
            return _PRRepository.GetFiscalYear(fiscalyear);
        }
    }
}
