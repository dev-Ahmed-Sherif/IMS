using Entities.Models.VL;
using Entities.ViewModels.VL.VlVehicleStatusViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VL
{
    public class VlVehicleStatusRepository : GenericRepository<VlVehicleStatus>
    {
        public VlVehicleStatusRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<VlVehicleStatus> Filter(VlVehicleStatusFilter filter)
        {
            IQueryable<VlVehicleStatus> result = GetAll();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
}
