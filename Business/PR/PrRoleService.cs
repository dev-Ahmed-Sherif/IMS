using DAL;
using DAL.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.PR
{
    public class PrRoleService
    {
        public PrRoleRepository _PRRepository;
        public PrRoleService(PrRoleRepository PrRoleRepository)
        {
            _PRRepository = PrRoleRepository;
        }

        public string Add(PrRoleVM role)
        {
            return _PRRepository.Add(role);
        }

        public string Update(PrRoleVM role)
        {
            return _PRRepository.Update(role);
        }

        public string Delete(int roleId)
        {
            return _PRRepository.Delete(roleId);
        }

        public List<PrRoleGetVM> GetAll()
        {
            return _PRRepository.GetAll();
        }
        public PrRoleGetVM GetById(int roleId)
        {
            return _PRRepository.GetById(roleId);
        }
    }
}
