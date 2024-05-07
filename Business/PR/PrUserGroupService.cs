using DAL;
using DAL.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.PR
{
    public class PrUserGroupService
    {
        public PrUserGroupRepository _PRRepository;

        public PrUserGroupService(PrUserGroupRepository PrUserGroupRepository)
        {
            _PRRepository = PrUserGroupRepository;
        }

        public string Add(PrUserGroupVM userGroup)
        {
            return _PRRepository.Add(userGroup);
        }


        public string Update(PrUserGroupVM userGroup)
        {
            return _PRRepository.Update(userGroup);
        }

        public string Delete(int userGroupId)
        {
            return _PRRepository.Delete(userGroupId);
        }

        public List<PrUserGroupWithGroupVM> GetAll()
        {
            return _PRRepository.GetAll();
        }
        public PrUserGroupWithGroupVM GetById(int userGroupId)
        {
            return _PRRepository.GetById(userGroupId);
        }
        public List<PrUserGroupWithGroupVM> GetByUser(int UserId)
        {
            return _PRRepository.GetByUser(UserId);
        }
    }
}
