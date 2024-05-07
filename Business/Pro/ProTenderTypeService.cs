using DAL;
using DAL.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Pro
{
    public class ProTenderTypeService
    {
        public ProTenderTypeRepository _ProTenderTypeRepository;
        public ProTenderTypeService(ProTenderTypeRepository ProTenderTypeRepository)
        {
            _ProTenderTypeRepository = ProTenderTypeRepository;
        }
        public string Add(ProTenderTypeGeneralVM vtype)
        {
            return _ProTenderTypeRepository.Add(vtype);
        }
        public string Update(ProTenderTypeVM type)
        {
            return _ProTenderTypeRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _ProTenderTypeRepository.Delete(typeId);
        }
        public List<ProTenderTypeGetVM> GetAll()
        {
            return _ProTenderTypeRepository.GetAll();
        }
        public ProTenderTypeGetVM GetById(int typeId)
        {
            return _ProTenderTypeRepository.GetById(typeId);
        }
        public string GetLastNo()
        {
            return _ProTenderTypeRepository.GetLastNo();
        }
    }
}
