using DAL;
using DAL.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.PR
{
    public class PrGroupPrivilegesService
    {
        public PrGroupPrivilegesRepository _PRRepository;

        public PrGroupPrivilegesService(PrGroupPrivilegesRepository PrGroupPrivilegesRepository)
        {
            _PRRepository = PrGroupPrivilegesRepository;
        }

        public string Add(PrGroupPrivilegesGeneralVM groupPrivileges)
        {
            return _PRRepository.Add(groupPrivileges);
        }


        public string Update(PrGroupPrivilegesVM group_Privileges)
        {
            return _PRRepository.Update(group_Privileges);
        }

        public string Delete(int group_PrivilegesId)
        {
            return _PRRepository.Delete(group_PrivilegesId);
        }
        public List<PrGroupPrivilegesGetVM> GetAll()
        {
            return _PRRepository.GetAll();
        }
        public PrGroupPrivilegesGetVM GetById(int group_PrivilegesId)
        {
            return _PRRepository.GetById(group_PrivilegesId);
        }
    }
}
