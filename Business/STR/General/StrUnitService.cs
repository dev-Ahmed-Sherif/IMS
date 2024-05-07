using DAL;
using DAL.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.General
{
    public class StrUnitService
    {
        public StrUnitRepository _StrUnitRepository;
        public StrUnitService(StrUnitRepository StrUnitRepository)
        {
            _StrUnitRepository = StrUnitRepository;
        }
        public string Add(StrUnitVM unit)
        {
            return _StrUnitRepository.Add(unit);
        }

        public string Update(StrUnitVM unit)
        {
            return _StrUnitRepository.Update(unit);
        }

        public string Delete(int unitId)
        {
            return _StrUnitRepository.Delete(unitId);
        }
        public List<StrUnitGetVM> GetAll()
        {
            return _StrUnitRepository.GetAll();
        }
        public StrUnitGetVM GetById(int unitId)
        {
            return _StrUnitRepository.GetById(unitId);
        }
    }
}
