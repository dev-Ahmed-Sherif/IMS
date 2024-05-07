using DAL;
using DAL.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.PR
{
    public class PrGroupService
    {
        public PrGroupRepository _PRRepository;
        public PrGroupService(PrGroupRepository PrGroupRepository)
        {
            _PRRepository = PrGroupRepository;
        }
        public string Add(PrGroupVM group)
        {
            return _PRRepository.Add(group);
        }

        public string Update(PrGroupVM group)
        {
            return _PRRepository.Update(group);
        }

        public string Delete(int groupId)
        {
            return _PRRepository.Delete(groupId);
        }

        public List<PrGroupGetVM> GetAll()
        {
            return _PRRepository.GetAll();
        }
        public PrGroupGetVM GetById(int groupId)
        {
            return _PRRepository.GetById(groupId);
        }

        //public PrGroupWithGroupRoleVM Get_PR_Group_With_Group_Role(int groupId)
        //{
        //    return _PRRepository.Get_PR_Group_With_Group_Role(groupId);
        //}

    }
}
