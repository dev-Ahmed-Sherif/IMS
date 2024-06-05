using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderOpeningViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProTenderOpeningRepository : GenericRepository<ProTenderOpening>
    {
        public ProTenderOpeningRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderOpening> Filter(ProTenderOpeningFilter filter)
        {
            IQueryable<ProTenderOpening> result = GetAll();
            if (filter.TenderId.HasValue)
            {
                result = result.Where(e => e.TenderId == filter.TenderId);
            }
            if (filter.SellerId.HasValue)
            {
                result = result.Where(e => e.SellerId == filter.SellerId);
            }
            if (filter.StatusId.HasValue)
            {
                result = result.Where(e => e.StatusId >= filter.StatusId);
            }
            return result;
        }
    }
}
