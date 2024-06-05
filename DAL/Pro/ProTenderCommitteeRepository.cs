using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using System.Linq;

namespace DAL.Pro
{
    public class ProTenderCommitteeRepository : GenericRepository<ProTenderCommittee>
    {
        public ProTenderCommitteeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderCommittee> Filter(ProTenderDetailsFilter filter)
        {
            IQueryable<ProTenderCommittee> result = GetAll();
            //if (filter.TenderId.HasValue)
            //{
            //    result = result.Where(e => e.TenderId == filter.TenderId);
            //}
            //if (!string.IsNullOrEmpty(filter.Name))
            //{
            //    result = result.Where(e => e.Name.Contains(filter.Name));
            //}
            //if (filter.MinQty.HasValue)
            //{
            //    result = result.Where(e => e.Qty >= filter.MinQty);
            //}
            //if (filter.MaxQty.HasValue)
            //{
            //    result = result.Where(e => e.Qty <= filter.MaxQty);
            //}
            //if (filter.MinPrice.HasValue)
            //{
            //    result = result.Where(e => e.Price >= filter.MinPrice);
            //}
            //if (filter.MaxPrice.HasValue)
            //{
            //    result = result.Where(e => e.Price <= filter.MaxPrice);
            //}
            return result;
        }
    }
}
