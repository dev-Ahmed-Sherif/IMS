using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderSellerReqViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProTenderSellerReqRepository : GenericRepository<ProTenderSellerReq>
    {
        public ProTenderSellerReqRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderSellerReq> Filter(ProTenderSellerReqFilter filter)
        {
            IQueryable<ProTenderSellerReq> result = GetAll();
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
