using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using Entities.ViewModels.Pro.ProTenderCommitteeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProPurchaseOrderRepository : GenericRepository<ProPurchaseOrder>
    {
        public ProPurchaseOrderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProPurchaseOrder> Filter(ProPurchaseOrderFilter filter)
        {
            IQueryable<ProPurchaseOrder> result = _dbSet;
            if (filter.TenderId.HasValue)
            {
                result = result.Where(e => e.TenderId == filter.TenderId);
            }
            if (filter.StoreId.HasValue)
            {
                result = result.Where(e => e.StoreId == filter.StoreId);
            }
            if (filter.StartDate.HasValue)
            {
                result = result.Where(e => e.Date >= filter.StartDate);
            }
            if (filter.EndDate.HasValue)
            {
                result = result.Where(e => e.Date <= filter.EndDate);
            }
            if (filter.VendorId.HasValue)
            {
                result = result.Where(e => e.Details.Any(e => e.QuotationDetails.Quotation.VendorId == filter.VendorId));
            }
            if (filter.InspectionDate.HasValue)
            {
                result = result.Where(e => e.InspectionDate == filter.InspectionDate);
            }
            if (filter.AdditionDate.HasValue)
            {
                result = result.Where(e => e.AdditionDate == filter.AdditionDate);
            }
            if (filter.StoreDeliverDate.HasValue)
            {
                result = result.Where(e => e.StoreDeliverDate == filter.StoreDeliverDate);
            }
            if (filter.Delivered.HasValue)
            {
                result = result.Where(e => e.Delivered == filter.Delivered);
            }
            if (filter.DeliverDelayInDays.HasValue)
            {
                result = result.Where(e => e.DeliverDelayInDays == filter.DeliverDelayInDays);
            }
            return result;
        }
    }
}
