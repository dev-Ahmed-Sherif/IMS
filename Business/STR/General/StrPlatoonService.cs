using DAL;
using DAL.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace Business.STR.General
{
    public class StrPlatoonService
    {
        public StrPlatoonRepository _StrPlatoonRepository;
        public StrPlatoonService(StrPlatoonRepository StrPlatoonRepository)
        {
            _StrPlatoonRepository = StrPlatoonRepository;
        }
        public string GetLastNo(int GradeId)
        {
            return _StrPlatoonRepository.GetLastNo(GradeId);
        }
        public string Add(StrPlatoonVM platoon)
        {
            if (Information.IsNumeric(platoon.Code))
            {
                return _StrPlatoonRepository.Add(platoon);
            }
            else
            {
                return "Code isn't numeric";
            }
        }


        public string Update(StrPlatoonVM platoon)
        {
            if (Information.IsNumeric(platoon.Code))
            {
                return _StrPlatoonRepository.Update(platoon);
            }
            else
            {
                return "Code isn't numeric";
            }
        }

        public string Delete(int platoonId)
        {
            return _StrPlatoonRepository.Delete(platoonId);
        }

        public List<StrPlatoonGetVM> GetAll()
        {
            return _StrPlatoonRepository.GetAll();
        }
        public StrPlatoonGetVM GetById(int platoonId)
        {
            return _StrPlatoonRepository.GetById(platoonId);
        }
        public StrPlatoonVM GetWithGroups(int gradeId)
        {
            return _StrPlatoonRepository.GetWithGroups(gradeId);
        }
    }
}
