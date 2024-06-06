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
            IQueryable<ProPurchaseOrder> result = GetAll();
            if (filter.TenderId.HasValue)
            {
                result = result.Where(e => e.TenderId == filter.TenderId);
            }
            if (filter.SellerId.HasValue)
            {
                result = result.Where(e => e.SellerId == filter.SellerId);
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
            return result;
        }
    }
}
