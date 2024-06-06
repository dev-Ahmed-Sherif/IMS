using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderDetailsViewModels;
using Entities.ViewModels.Pro.ProTenderCommitteeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProPurchaseOrderDetailsRepository : GenericRepository<ProPurchaseOrderDetails>
    {
        public ProPurchaseOrderDetailsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProPurchaseOrderDetails> Filter(ProPurchaseOrderDetailsFilter filter)
        {
            IQueryable<ProPurchaseOrderDetails> result = GetAll();
            if (filter.PurchaseOrderId.HasValue)
            {
                result = result.Where(e => e.PurchaseOrderId == filter.PurchaseOrderId);
            }
            if (filter.TenderDetailsId.HasValue)
            {
                result = result.Where(e => e.TenderDetailsId == filter.TenderDetailsId);
            }
            if (filter.QuotationDetailsId.HasValue)
            {
                result = result.Where(e => e.QuotationDetailsId == filter.QuotationDetailsId);
            }
            return result;
        }
    }
}
