using DAL;
using DAL.Pro;
using static DAL.Pro.ProVendorRepository;
using Entities.ViewModels.FI.Account;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Pro
{
    public class ProVendorService
    {
        public ProVendorRepository _ProVendorRepository;
        public ProVendorService(ProVendorRepository ProVendorRepository)
        {
            _ProVendorRepository = ProVendorRepository;
        }
        public async Task<int> Add(ProVendorVM Vendor)
        {
            return await _ProVendorRepository.Add(Vendor);
        }

        public async Task<string> Update(ProVendorVM Vendor)
        {
            return await _ProVendorRepository.Update(Vendor);
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
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //----------------------------------------------------------
        public PaginatedResult<ProVendorGetVM> GetAllByPagination(int page, int pageSize)
        {
            return _ProVendorRepository.GetAllByPagination(page, pageSize);
        }
    }
}
