using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderSellerReqSendTypeViewModels;
using Entities.ViewModels.Pro.ProTenderSellerReqViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProTenderSellerReqSendTypeRepository : GenericRepository<ProTenderSellerReqSendType>
    {
        public ProTenderSellerReqSendTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderSellerReqSendType> Filter(ProTenderSellerReqSendTypeFilter filter)
        {
            IQueryable<ProTenderSellerReqSendType> result = GetAll();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name));
            }
            return result;
        }
    }
}
