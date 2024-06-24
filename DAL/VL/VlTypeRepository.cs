using Entities.Models.Pro;
using Entities.Models.VL;
using Entities.ViewModels.Pro.ProQuotationDetailsViewModels;
using Entities.ViewModels.VL.VlTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VL
{
    public class VlTypeRepository : GenericRepository<VlType>
    {
        public VlTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<VlType> Filter(VlTypeFilter filter)
        {
            IQueryable<VlType> result = GetAll();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
}
