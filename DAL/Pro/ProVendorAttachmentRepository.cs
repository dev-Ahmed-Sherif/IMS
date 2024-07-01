using Entities.Models.Pro;
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
    }
}
