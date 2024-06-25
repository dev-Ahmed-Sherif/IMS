using DAL;
using DAL.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Pro
{
    public class ProSupplierTypeService
    {

        public ProSupplierTypeRepository _ProContractorTypeRepository;
        public ProSupplierTypeService(ProSupplierTypeRepository ProContractorTypeRepository)
        {
            _ProContractorTypeRepository = ProContractorTypeRepository;
        }
        public string Add(ProSupplierTypeGeneralVM vtype)
        {
            return _ProContractorTypeRepository.Add(vtype);
        }
        public string Update(ProSupplierTypeVM type)
        {
            return _ProContractorTypeRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _ProContractorTypeRepository.Delete(typeId);
        }
        public List<ProSupplierTypeGetVM> GetAll()
        {
            return _ProContractorTypeRepository.GetAll();
        }
        public ProSupplierTypeGetVM GetById(int typeId)
        {
            return _ProContractorTypeRepository.GetById(typeId);
        }
        public string GetLastNo()
        {
            return _ProContractorTypeRepository.GetLastNo();
        }
    }
}
