using Entities.Models.Pro;
using Entities.Models.VL;
using Entities.ViewModels.Pro.ProQuotationDetailsViewModels;
using Entities.ViewModels.VL.VlGarageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VL
{
    public class VlGarageRepository : GenericRepository<VlGarage>
    {
        public VlGarageRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<VlGarage> Filter(VlGarageFilter filter)
        {
            IQueryable<VlGarage> result = _dbSet;
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
}
