using DAL;
using DAL.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace Business.STR.General
{
    //Book services class
    public class StrGroupService
    {
        public StrGroupRepository _StrGroupRepository;

        public StrGroupService(StrGroupRepository StrGroupRepository)
        {
            _StrGroupRepository = StrGroupRepository;
        }
        public string GetLastNo(int PlatoonId)
        {

            return _StrGroupRepository.GetLastNo(PlatoonId);
        }

        public string Add(StrGroupVM group)
        {
            if (Information.IsNumeric(group.Code))
            {
                return _StrGroupRepository.Add(group);
            }
            else
            {
                return "Code isn't numeric";
            }
        }
        public string Update(StrGroupVM group)
        {
            if (Information.IsNumeric(group.Code))
            {
                return _StrGroupRepository.Update(group);
            }
            else
            {
                return "Code isn't numeric";
            }

        }
        public string Delete(int groupId)
        {
            return _StrGroupRepository.Delete(groupId);
        }
        public List<StrGroupGetVM> GetAll()
        {
            return _StrGroupRepository.GetAll();
        }
        public StrGroupGetVM GetById(int groupId)
        {
            return _StrGroupRepository.GetById(groupId);
        }
    }
}
