using Entities.Models.Pro;
using Entities.Models.VL;
using Entities.ViewModels.Pro.ProQuotationDetailsViewModels;
using Entities.ViewModels.VL.VlManufacturer;
using Entities.ViewModels.VL.VlManufacturerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VL
{
    public class VlManufacturerRepository : GenericRepository<VlManufacturer>
    {
        public VlManufacturerRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<VlManufacturer> Filter(VlManufacturerFilter filter)
        {
            IQueryable<VlManufacturer> result = GetAll();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
}
