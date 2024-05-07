using DAL;
using DAL.STR.Add;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.Add
{
    public class AddTypeService
    {
        public AddTypeRepository _AddTypeRepository;
        public AddTypeService(AddTypeRepository AddTypeRepository)
        {
            _AddTypeRepository = AddTypeRepository;
        }
        public string Add(StrAddTypeGeneralVM vtype)
        {
            return _AddTypeRepository.Add(vtype);
        }
        public string Update(StrAddTypeVM type)
        {
            return _AddTypeRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _AddTypeRepository.Delete(typeId);
        }
        public List<StrAddTypeGetVM> GetAll()
        {
            return _AddTypeRepository.GetAll();
        }
        public StrAddTypeGetVM GetById(int typeId)
        {
            return _AddTypeRepository.GetById(typeId);
        }
    }
}
