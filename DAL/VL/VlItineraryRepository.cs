using Entities.Models.VL;
using Entities.ViewModels.VL.VlItineraryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VL
{
    public class VlItineraryRepository : GenericRepository<VlItinerary>
    {
        public VlItineraryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<VlItinerary> Filter(VlItineraryFilter filter)
        {
            IQueryable<VlItinerary> result = _dbSet;
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
}
