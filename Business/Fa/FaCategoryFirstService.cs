using DAL;
using DAL.Fa;
using Entities.ViewModels.Fa;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Fa
{
    public class FaCategoryFirstService
    {
        public FaCategoryFirstRepository _FaCategoryFirstRepository;
        public FaCategoryFirstService(FaCategoryFirstRepository FaCategoryFirstRepository)
        {
            _FaCategoryFirstRepository = FaCategoryFirstRepository;
        }
        public string Add(FaCategoryFirstGeneralVM vtype)
        {
            return _FaCategoryFirstRepository.Add(vtype);
        }
        public string Update(FaCategoryFirstVM type)
        {
            return _FaCategoryFirstRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _FaCategoryFirstRepository.Delete(typeId);
        }
        public List<FaCategoryFirstGetVM> GetAll()
        {
            return _FaCategoryFirstRepository.GetAll();
        }
        public FaCategoryFirstGetVM GetById(int typeId)
        {
            return _FaCategoryFirstRepository.GetById(typeId);
        }
        public string GetLastNo()
        {
            return _FaCategoryFirstRepository.GetLastNo();
        }
    }
}
