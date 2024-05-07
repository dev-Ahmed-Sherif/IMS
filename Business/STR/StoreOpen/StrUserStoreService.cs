using DAL;
using DAL.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.StoreOpen
{
    public class StrUserStoreService
    {
        public StrUserStoreRepository _StrUserStoreRepository;
        public StrUserStoreService(StrUserStoreRepository StrUserStoreRepository)
        {
            _StrUserStoreRepository = StrUserStoreRepository;
        }
        public string Add(StrUserStoreGeneralVM store)
        {
            return _StrUserStoreRepository.Add(store);
        }
        public string Update(StrUserStoreVM store)
        {
            return _StrUserStoreRepository.Update(store);
        }
        public string Delete(int storeId)
        {
            return _StrUserStoreRepository.Delete(storeId);
        }
        public List<StrUserStoreGetVM> GetAll()
        {
            return _StrUserStoreRepository.GetAll();
        }
        public StrUserStoreGetVM GetById(int storeId)
        {
            return _StrUserStoreRepository.GetById(storeId);
        }
        public List<StrUserStoreGetVM> GetByUser(int storeId)
        {
            return _StrUserStoreRepository.GetByUser(storeId);
        }
    }
}
