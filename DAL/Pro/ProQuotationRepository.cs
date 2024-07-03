using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using Entities.ViewModels.Pro.ProQuotationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProQuotationRepository : GenericRepository<ProQuotation>
    {
        public ProQuotationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProQuotation> Filter(ProQuotationFilter filter)
        {
            IQueryable<ProQuotation> result = _dbSet;
            if (filter.TenderId.HasValue)
            {
                result = result.Where(e => e.TenderId == filter.TenderId);
            }
            if (filter.VendorId.HasValue)
            {
                result = result.Where(e => e.VendorId == filter.VendorId);
            }
            if (filter.ReceiveTypeId.HasValue)
            {
                result = result.Where(e => e.ReceiveTypeId == filter.ReceiveTypeId);
            }
            if (filter.StartReceiveDate.HasValue)
            {
                result = result.Where(e => e.ReceiveDate >= filter.StartReceiveDate);
            }
            if (filter.EndReceiveDate.HasValue)
            {
                result = result.Where(e => e.ReceiveDate <= filter.EndReceiveDate);
            }
            if (filter.StartValidationDate.HasValue)
            {
                result = result.Where(e => e.ValidationDate >= filter.StartValidationDate);
            }
            if (filter.EndValidationDate.HasValue)
            {
                result = result.Where(e => e.ValidationDate <= filter.EndValidationDate);
            }
            return result;
        }
    }
}
