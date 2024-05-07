using DAL;
using DAL.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Pro
{
    public class ProPlanTypeService
    {

        public ProPlanTypeRepository _ProPlantTypeRepository;
        public ProPlanTypeService(ProPlanTypeRepository ProPlanTypeRepository)
        {
            _ProPlantTypeRepository = ProPlanTypeRepository;
        }
        public string Add(ProPlantTypeGeneralVM vtype)
        {
            return _ProPlantTypeRepository.Add(vtype);
        }
        public string Update(ProPlanTypeVM type)
        {
            return _ProPlantTypeRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _ProPlantTypeRepository.Delete(typeId);
        }
        public List<ProPlantTypeGetVM> GetAll()
        {
            return _ProPlantTypeRepository.GetAll();
        }
        public ProPlantTypeGetVM GetById(int typeId)
        {
            return _ProPlantTypeRepository.GetById(typeId);
        }
        public string GetLastNo()
        {
            return _ProPlantTypeRepository.GetLastNo();
        }
    }
}
