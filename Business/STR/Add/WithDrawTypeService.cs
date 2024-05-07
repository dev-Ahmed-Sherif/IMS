using DAL;
using DAL.STR.Add;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.Add
{
    public class WithDrawTypeService
    {
        public StrWithDrawTypeRepository _StrWithDrawTypeRepository;
        public WithDrawTypeService(StrWithDrawTypeRepository StrWithDrawTypeRepository)
        {
            _StrWithDrawTypeRepository = StrWithDrawTypeRepository;
        }
        public string Add(StrWithDrawTypeGeneralVM receipt)
        {
            return _StrWithDrawTypeRepository.Add(receipt);
        }
        public string Update(StrWithDrawTypeVM receipt)
        {
            return _StrWithDrawTypeRepository.Update(receipt);
        }
        public string Delete(int receiptId)
        {
            return _StrWithDrawTypeRepository.Delete(receiptId);
        }
        public List<StrWithDrawTypeGetVM> GetAll()
        {
            return _StrWithDrawTypeRepository.GetAll();
        }
        public StrWithDrawTypeGetVM GetById(int receiptId)
        {
            return _StrWithDrawTypeRepository.GetById(receiptId);
        }
    }
}
