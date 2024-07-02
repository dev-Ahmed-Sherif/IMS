using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderOpeningDetailsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProTenderOpeningDetailsRepository : GenericRepository<ProTenderOpeningDetails>
    {
        public ProTenderOpeningDetailsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderOpeningDetails> Filter(ProTenderOpeningDetailsFilter filter)
        {
            IQueryable<ProTenderOpeningDetails> result = GetAll();
            if (filter.QuotationId.HasValue)
            {
                result = result.Where(e => e.QuotationId == filter.QuotationId);
            }
            if (filter.Accepted.HasValue)
            {
                result = result.Where(e => e.Accepted== filter.Accepted);
            }
            return result;
        }
    }
}
