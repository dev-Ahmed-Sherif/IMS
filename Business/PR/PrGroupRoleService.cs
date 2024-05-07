using DAL;
using DAL.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.PR
{
    public class PrGroupRoleService
    {
        public PrGroupRoleRepository _PRRepository;

        public PrGroupRoleService(PrGroupRoleRepository PrGroupRoleRepository)
        {
            _PRRepository = PrGroupRoleRepository;
        }

        public string Add(PrGroupRoleGeneralVM groupRole)
        {
            return _PRRepository.Add(groupRole);
        }


        public string Update(PrGroupRoleVM group_Role)
        {
            return _PRRepository.Update(group_Role);
        }

        public string Delete(int group_RoleId)
        {
            return _PRRepository.Delete(group_RoleId);
        }
        public List<PrGroupRoleGetVM> GetAll()
        {
            return _PRRepository.GetAll();
        }
        public PrGroupRoleGetVM GetById(int group_RoleId)
        {
            return _PRRepository.GetById(group_RoleId);
        }
        public List<PrGroupRoleGetVM> GetByGroup(int GroupId)
        {
            return _PRRepository.GetByGroup(GroupId);
        }
    }
}
