using DAL;
using DAL.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Pro
{
    public class ProVendorTypeService
    {

        public ProVendorTypeRepository _ProVendorTypeRepository;
        public ProVendorTypeService(ProVendorTypeRepository ProVendorTypeRepository)
        {
            _ProVendorTypeRepository = ProVendorTypeRepository;
        }
        public string Add(ProVendorTypeGeneralVM vtype)
        {
            return _ProVendorTypeRepository.Add(vtype);
        }
        public string Update(ProVendorTypeVM type)
        {
            return _ProVendorTypeRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _ProVendorTypeRepository.Delete(typeId);
        }
        public List<ProVendorTypeGetVM> GetAll()
        {
            return _ProVendorTypeRepository.GetAll();
        }
        public ProVendorTypeGetVM GetById(int typeId)
        {
            return _ProVendorTypeRepository.GetById(typeId);
        }
        public string GetLastNo()
        {
            return _ProVendorTypeRepository.GetLastNo();
        }
    }
}
