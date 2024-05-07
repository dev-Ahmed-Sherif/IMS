using DAL;
using DAL.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.PR
{
    public class PrPrivilegesService
    {
        public PrPrivilegesRepository _PRRepository;
        public PrPrivilegesService(PrPrivilegesRepository PrPrivilegesRepository)
        {
            _PRRepository = PrPrivilegesRepository;
        }
        public string Add(PrPrivilegesVM group)
        {
            return _PRRepository.Add(group);
        }

        public string Update(PrPrivilegesVM group)
        {
            return _PRRepository.Update(group);
        }

        public string Delete(int groupId)
        {
            return _PRRepository.Delete(groupId);
        }

        public List<PrPrivilegesGetVM> GetAll()
        {
            return _PRRepository.GetAll();
        }
        public PrPrivilegesGetVM GetById(int groupId)
        {
            return _PRRepository.GetById(groupId);
        }

    }
}
