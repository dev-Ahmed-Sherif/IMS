using Entities.Models.Pro;
using Entities.Models.VL;
using Entities.ViewModels.Pro.ProQuotationDetailsViewModels;
using Entities.ViewModels.VL.VlModelViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VL
{
    public class VlModelRepository : GenericRepository<VlModel>
    {
        public VlModelRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<VlModel> Filter(VlModelFilter filter)
        {
            IQueryable<VlModel> result = GetAll();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
}
