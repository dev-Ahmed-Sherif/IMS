using DAL;
using DAL.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Pro
{
    public class ProVendorService
    {
        public ProVendorRepository _ProVendorRepository;
        public ProVendorService(ProVendorRepository ProVendorRepository)
        {
            _ProVendorRepository = ProVendorRepository;
        }
        public string Add(ProVendorVM Vendor)
        {
            return _ProVendorRepository.Add(Vendor);
        }

        public string Update(ProVendorVM Vendor)
        {
            return _ProVendorRepository.Update(Vendor);
        }

        public string Delete(int VendorId)
        {
            return _ProVendorRepository.Delete(VendorId);
        }

        public List<ProVendorGetVM> GetAll()
        {
            return _ProVendorRepository.GetAll();
        }
        public ProVendorGetVM GetById(int VendorId)
        {
            return _ProVendorRepository.GetById(VendorId);
        }
        public List<ProVendorGetVM> GetByName(string VendorName)
        {
            return _ProVendorRepository.GetByName(VendorName);
        }
        public string GetLastNo()
        {
            return _ProVendorRepository.GetLastNo();
        }
        public List<ProVendorGetVM> Search(VendorSearchGeneral searchModel)
        {
            return _ProVendorRepository.Search(searchModel);
        }
    }
}
