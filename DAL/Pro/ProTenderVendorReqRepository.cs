using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProTenderVendorReqRepository : GenericRepository<ProTenderVendorReq>
    {
        public ProTenderVendorReqRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderVendorReq> Filter(ProTenderVendorReqFilter filter)
        {
            IQueryable<ProTenderVendorReq> result = _dbSet;
            if (filter.TenderId.HasValue)
            {
                result = result.Where(e => e.TenderId == filter.TenderId);
            }
            if (filter.VendorId.HasValue)
            {
                result = result.Where(e => e.VendorId == filter.VendorId);
            }
            if (filter.StartSendDate.HasValue)
            {
                result = result.Where(e => e.SendDate >= filter.StartSendDate);
            }
            if (filter.EndSendDate.HasValue)
            {
                result = result.Where(e => e.SendDate <= filter.EndSendDate);
            }
            if (filter.SendTypeId.HasValue)
            {
                result = result.Where(e => e.SendTypeId == filter.SendTypeId);
            }
            return result;
        }
    }
}
