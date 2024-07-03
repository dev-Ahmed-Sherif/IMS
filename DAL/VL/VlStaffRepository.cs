using Entities.Models.VL;
using Entities.ViewModels.VL.VlStaff;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VL
{
    public class VlStaffRepository : GenericRepository<VlStaff>
    {
        public VlStaffRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<VlStaff> Filter(VlStaffFilter filter)
        {
            IQueryable<VlStaff> result = _dbSet;
            if (filter.EmployeeId.HasValue)
            {
                result = result.Where(e => e.EmployeeId == filter.EmployeeId);
            }
            if (filter.PositionId.HasValue)
            {
                result = result.Where(e => e.PositionId == filter.PositionId);
            }
            if (filter.StatusId.HasValue)
            {
                result = result.Where(e => e.StatusId == filter.StatusId);
            }
            return result;
        }

    }
}
