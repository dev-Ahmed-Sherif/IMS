using DAL;
using DAL.STR.Add;
using DAL.STR.StoreOpen;
using Entities.Models.STR.StoreOpen;
using Entities.ViewModels.STR.AddDetails;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Business.STR.StoreOpen
{
    public class StrStoreService
    {
        public StrStoreRepository _StrStoreRepository;
        public StrStoreService(StrStoreRepository StrStoreRepository)
        {
            _StrStoreRepository = StrStoreRepository;
        }
        public string Add(StrStoreVM store)
        {
            return _StrStoreRepository.Add(store);
        }
        public string Update(StrStoreVM store)
        {
            return _StrStoreRepository.Update(store);
        }
        public string Delete(int storeId)
        {
            return _StrStoreRepository.Delete(storeId);
        }
        public List<StrStoreGetVM> GetAll()
        {
            return _StrStoreRepository.GetAll();
        }
        public List<StrStoreGetVM> Search(StoreSearch search)
        {
            return _StrStoreRepository.Search(search);
        }


        public StrStoreGetVM GetById(int storeId)
        {
            return _StrStoreRepository.GetById(storeId);
        }
        public int GetLastNo(int sectionId)
        {
            return _StrStoreRepository.GetLastNo(sectionId);
        }

    }
}
