using Entities.Models.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProVendorAttachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProVendorAttachmentRepository : GenericRepository<ProVendorAttachment>
    {
        public ProVendorAttachmentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProVendorAttachment> Filter(ProVendorAttachmentFilter filter)
        {
            IQueryable<ProVendorAttachment> result = _dbSet;

            if (filter.VendorId.HasValue)
            {
                result = result.Where(e => e.VendorId == filter.VendorId);
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
}
