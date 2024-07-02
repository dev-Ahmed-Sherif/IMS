using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderVendorReqSendTypeViewModels;
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProTenderVendorReqSendTypeRepository : GenericRepository<ProTenderVendorReqSendType>
    {
        public ProTenderVendorReqSendTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderVendorReqSendType> Filter(ProTenderVendorReqSendTypeFilter filter)
        {
            IQueryable<ProTenderVendorReqSendType> result = GetAll();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name));
            }
            return result;
        }
    }
}
