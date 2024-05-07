using DAL;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrDisciplinaryService
    {
        public HrDisciplinaryRepository _HrDisciplinaryRepository;
        public HrDisciplinaryService(HrDisciplinaryRepository HrDisciplinaryRepository)
        {
            _HrDisciplinaryRepository = HrDisciplinaryRepository;
        }
        public string Add(HrDisciplinaryVM Disciplinary)
        {
            return _HrDisciplinaryRepository.Add(Disciplinary);
        }

        public string Update(HrDisciplinaryVM Disciplinary)
        {
            return _HrDisciplinaryRepository.Update(Disciplinary);
        }

        public string Delete(int DisciplinaryId)
        {
            return _HrDisciplinaryRepository.Delete(DisciplinaryId);
        }
        public List<HrDisciplinaryGetVM> GetAll()
        {
            return _HrDisciplinaryRepository.GetAll();
        }
        public HrDisciplinaryGetVM GetById(int DisciplinaryId)
        {
            return _HrDisciplinaryRepository.GetById(DisciplinaryId);
        }

    }
}
