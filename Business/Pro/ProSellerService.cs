using DAL;
using DAL.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Pro
{
    public class ProSellerService
    {
        public ProSellerRepository _ProSellerRepository;
        public ProSellerService(ProSellerRepository ProSellerRepository)
        {
            _ProSellerRepository = ProSellerRepository;
        }
        public string Add(ProSellerVM seller)
        {
            return _ProSellerRepository.Add(seller);
        }

        public string Update(ProSellerVM seller)
        {
            return _ProSellerRepository.Update(seller);
        }

        public string Delete(int sellerId)
        {
            return _ProSellerRepository.Delete(sellerId);
        }

        public List<ProSellerGetVM> GetAll()
        {
            return _ProSellerRepository.GetAll();
        }
        public ProSellerGetVM GetById(int sellerId)
        {
            return _ProSellerRepository.GetById(sellerId);
        }
        public List<ProSellerGetVM> GetByName(string SellerName)
        {
            return _ProSellerRepository.GetByName(SellerName);
        }
        public string GetLastNo()
        {
            return _ProSellerRepository.GetLastNo();
        }
        public List<ProSellerGetVM> Search(SellerSearchGeneral searchModel)
        {
            return _ProSellerRepository.Search(searchModel);
        }
    }
}
