using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using Entities.ViewModels.Pro.ProQuotationDetailsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProQuotationDetailsRepository : GenericRepository<ProQuotationDetails>
    {
        public ProQuotationDetailsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProQuotationDetails> Filter(ProQuotationDetailsFilter filter)
        {
            IQueryable<ProQuotationDetails> result = _dbSet;
            if (filter.QuotationId.HasValue)
            {
                result = result.Where(e => e.QuotationId == filter.QuotationId);
            }
            if (filter.TenderDetailsId.HasValue)
            {
                result = result.Where(e => e.TenderDetailsId == filter.TenderDetailsId);
            }
            if (filter.MinPrice.HasValue)
            {
                result = result.Where(e => e.Price >= filter.MinPrice);
            }
            if (filter.MaxPrice.HasValue)
            {
                result = result.Where(e => e.Price <= filter.MaxPrice);
            }
            return result;
        }
    }
}
