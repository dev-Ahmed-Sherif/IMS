using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderOpeningStatusViewModels;
using Entities.ViewModels.Pro.ProTenderOpeningViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProTenderOpeningStatusRepository : GenericRepository<ProTenderOpeningStatus>
    {
        public ProTenderOpeningStatusRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderOpeningStatus> Filter(ProTenderOpeningStatusFilter filter)
        {
            IQueryable<ProTenderOpeningStatus> result = _dbSet;
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name));
            }
            return result;
        }
    }
}
