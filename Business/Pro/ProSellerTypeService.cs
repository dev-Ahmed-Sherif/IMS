using DAL;
using DAL.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Pro
{
    public class ProSellerTypeService
    {
        public ProSellerTypeRepository _ProSellerTypeRepository;
        public ProSellerTypeService(ProSellerTypeRepository ProSellerTypeRepository)
        {
            _ProSellerTypeRepository = ProSellerTypeRepository;
        }
        public string Add(ProSellerTypeGeneralVM vtype)
        {
            return _ProSellerTypeRepository.Add(vtype);
        }
        public string Update(ProSellerTypeVM type)
        {
            return _ProSellerTypeRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _ProSellerTypeRepository.Delete(typeId);
        }
        public List<ProSellerTypeGetVM> GetAll()
        {
            return _ProSellerTypeRepository.GetAll();
        }
        public ProSellerTypeGetVM GetById(int typeId)
        {
            return _ProSellerTypeRepository.GetById(typeId);
        }
        public string GetLastNo()
        {
            return _ProSellerTypeRepository.GetLastNo();
        }
    }
}
