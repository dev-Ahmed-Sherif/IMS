using Entities.Models.VL;
using Entities.ViewModels.VL.VlDrivierLicenseTypeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VL
{
    public class VlDrivierLicenseTypeRepository : GenericRepository<VlDrivierLicenseType>
    {
        public VlDrivierLicenseTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<VlDrivierLicenseType> Filter(VlDrivierLicenseTypeFilter filter)
        {
            IQueryable<VlDrivierLicenseType> result = _dbSet;
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
}
