using DAL;
using DAL.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.General
{
    public class StrVendorService
    {
        public StrVendorRepository _StrVendorRepository;
        public StrVendorService(StrVendorRepository StrVendorRepository)
        {
            _StrVendorRepository = StrVendorRepository;
        }

        public string Add(StrVendorGeneralVM vendor)
        {
            return _StrVendorRepository.Add(vendor);
        }

        public string Update(StrVendorVM vendor)
        {
            return _StrVendorRepository.Update(vendor);
        }

        public string Delete(int vendorId)
        {
            return _StrVendorRepository.Delete(vendorId);
        }
        public List<StrVendorGetVM> GetAll()
        {
            return _StrVendorRepository.GetAll();
        }
        public StrVendorGetVM GetById(int vendorId)
        {
            return _StrVendorRepository.GetById(vendorId);
        }
        public List<StrVendorGetVM> GetByName(string vendorName)
        {
            return _StrVendorRepository.GetByName(vendorName);
        }
    }
}
