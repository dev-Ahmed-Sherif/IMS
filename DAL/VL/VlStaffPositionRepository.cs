using Entities.Models.VL;
using Entities.ViewModels.VL.VlStaffPosition;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VL
{
    public class VlStaffPositionRepository:GenericRepository<VlStaffPosition>
    {
        public VlStaffPositionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    public IQueryable<VlStaffPosition>Filter(VlStaffPositionFilter filter)
    {
        IQueryable<VlStaffPosition> result = _dbSet;
        if (!string.IsNullOrEmpty(filter.Name))
        {
            result = result.Where(e => e.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
        }
        return result;
    }
}
}
