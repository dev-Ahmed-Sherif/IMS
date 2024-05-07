using DAL;
using DAL.Fa;
using Entities.ViewModels.Fa;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Fa
{
    public class FaCategorySecondService
    {
        public FaCategorySecondRepository _FaCategorySecondRepository;
        public FaCategorySecondService(FaCategorySecondRepository FaCategorySecondRepository)
        {
            _FaCategorySecondRepository = FaCategorySecondRepository;
        }
        public string Add(FaCategorySecondGeneralVM vtype)
        {
            return _FaCategorySecondRepository.Add(vtype);
        }
        public string Update(FaCategorySecondVM type)
        {
            return _FaCategorySecondRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _FaCategorySecondRepository.Delete(typeId);
        }
        public List<FaCategorySecondGetVM> GetAll()
        {
            return _FaCategorySecondRepository.GetAll();
        }
        public FaCategorySecondGetVM GetById(int typeId)
        {
            return _FaCategorySecondRepository.GetById(typeId);
        }
        public string GetLastNo()
        {
            return _FaCategorySecondRepository.GetLastNo();
        }
    }
}
