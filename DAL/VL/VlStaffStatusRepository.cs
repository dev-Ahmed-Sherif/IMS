using Entities.Models.VL;
using Entities.ViewModels.VL.VlStaffStatus;
using Entities.ViewModels.VL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VL
{
    public class VlStaffStatusRepository:GenericRepository<VlStaffStatus>
    {
        public VlStaffStatusRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<VlStaffStatus> Filter(VlStaffStatusFilter filter)
        {
            IQueryable<VlStaffStatus> result = _dbSet;
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
}
