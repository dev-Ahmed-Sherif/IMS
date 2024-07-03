using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using Entities.ViewModels.Pro.ProQuotationReceiveTypeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProQuotationReceiveTypeRepository : GenericRepository<ProQuotationReceiveType>
    {
        public ProQuotationReceiveTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProQuotationReceiveType> Filter(ProQuotationReceiveTypeFilter filter)
        {
            IQueryable<ProQuotationReceiveType> result = _dbSet;
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name));
            }
            return result;
        }
    }
}
