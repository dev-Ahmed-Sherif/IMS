using DAL;
using DAL.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Pro
{
    public class ProOperationTypeService
    {
        public ProOperationTypeRepository _ProOperationTypeRepository;
        public ProOperationTypeService(ProOperationTypeRepository ProOperationTypeRepository)
        {
            _ProOperationTypeRepository = ProOperationTypeRepository;
        }
        public string Add(ProOperationTypeGeneralVM vtype)
        {
            return _ProOperationTypeRepository.Add(vtype);
        }
        public string Update(ProOperationTypeVM type)
        {
            return _ProOperationTypeRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _ProOperationTypeRepository.Delete(typeId);
        }
        public List<ProOperationTypeGetVM> GetAll()
        {
            return _ProOperationTypeRepository.GetAll();
        }
        public ProOperationTypeGetVM GetById(int typeId)
        {
            return _ProOperationTypeRepository.GetById(typeId);
        }
        public string GetLastNo()
        {
            return _ProOperationTypeRepository.GetLastNo();
        }
    }
}
