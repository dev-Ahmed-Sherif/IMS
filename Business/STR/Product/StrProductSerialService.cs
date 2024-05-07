using DAL;
using DAL.STR.Product;
using Entities.ViewModels.STR.Product;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.Product
{
    public class StrProductSerialService
    {
        public StrProductSerialRepository _StrProductSerialRepository;

        public StrProductSerialService(StrProductSerialRepository StrProductSerialRepository)
        {
            _StrProductSerialRepository = StrProductSerialRepository;
        }
        public string Add(StrProductSerialGeneralVM sTR_Add)
        {
            return _StrProductSerialRepository.Add(sTR_Add);
        }

        public string Update(StrProductSerialVM sTR_Add)
        {
            return _StrProductSerialRepository.Update(sTR_Add);
        }
        public string Delete(int sTR_Add_Id)
        {
            return _StrProductSerialRepository.Delete(sTR_Add_Id);
        }
        public List<StrProductSerialGetVM> GetAll()
        {
            return _StrProductSerialRepository.GetAll();
        }
        public StrProductSerialGetVM GetById(int sTR_AddId)
        {
            return _StrProductSerialRepository.GetById(sTR_AddId);
        }
    }
}
