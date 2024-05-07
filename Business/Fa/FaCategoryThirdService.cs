using DAL;
using DAL.Fa;
using Entities.ViewModels.Fa;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Fa
{
    public class FaCategoryThirdService
    {
        public FaCategoryThirdRepository _FaCategoryThirdRepository;
        public FaCategoryThirdService(FaCategoryThirdRepository FaCategoryThirdRepository)
        {
            _FaCategoryThirdRepository = FaCategoryThirdRepository;
        }
        public string Add(FaCategoryThirdGeneralVM vtype)
        {
            return _FaCategoryThirdRepository.Add(vtype);
        }
        public string Update(FaCategoryThirdVM type)
        {
            return _FaCategoryThirdRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _FaCategoryThirdRepository.Delete(typeId);
        }
        public List<FaCategoryThirdGetVM> GetAll()
        {
            return _FaCategoryThirdRepository.GetAll();
        }
        public FaCategoryThirdGetVM GetById(int typeId)
        {
            return _FaCategoryThirdRepository.GetById(typeId);
        }
        public string GetLastNo()
        {
            return _FaCategoryThirdRepository.GetLastNo();
        }
    }
}
