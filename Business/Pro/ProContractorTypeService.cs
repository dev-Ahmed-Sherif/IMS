using DAL;
using DAL.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Pro
{
    public class ProContractorTypeService
    {

        public ProContractorTypeRepository _ProContractorTypeRepository;
        public ProContractorTypeService(ProContractorTypeRepository ProContractorTypeRepository)
        {
            _ProContractorTypeRepository = ProContractorTypeRepository;
        }
        public string Add(ProContractorTypeGeneralVM vtype)
        {
            return _ProContractorTypeRepository.Add(vtype);
        }
        public string Update(ProContractorTypeVM type)
        {
            return _ProContractorTypeRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _ProContractorTypeRepository.Delete(typeId);
        }
        public List<ProContractorTypeGetVM> GetAll()
        {
            return _ProContractorTypeRepository.GetAll();
        }
        public ProContractorTypeGetVM GetById(int typeId)
        {
            return _ProContractorTypeRepository.GetById(typeId);
        }
        public string GetLastNo()
        {
            return _ProContractorTypeRepository.GetLastNo();
        }
    }
}
