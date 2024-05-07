using DAL;
using DAL.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.General
{
    public class StrGradeService
    {
        public StrGradeRepository _StrGradeRepository;
        public StrGradeService(StrGradeRepository StrGradeRepository)
        {
            _StrGradeRepository = StrGradeRepository;
        }
        public string GetLastNo(int commidtyId)
        {
            return _StrGradeRepository.GetLastNo(commidtyId);
        }
        public string Add(StrGradeVM grade)
        {
            return _StrGradeRepository.Add(grade);
        }
        public string Update(StrGradeVM grade)
        {
            return _StrGradeRepository.Update(grade);
        }

        public string Delete(int gradeId)
        {
            return _StrGradeRepository.Delete(gradeId);
        }

        public List<StrGradeGetVM> GetAll()
        {
            return _StrGradeRepository.GetAll();
        }
        public StrGradeGetVM GetById(int gradeId)
        {
            return _StrGradeRepository.GetById(gradeId);
        }
        public StrGradeVM GetWithPlatoons(int gradeId)
        {
            return _StrGradeRepository.GetWithPlatoons(gradeId);
        }
    }
}
