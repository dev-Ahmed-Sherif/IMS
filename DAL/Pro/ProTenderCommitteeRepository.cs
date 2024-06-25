using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderCommitteeViewModels;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using System.Linq;

namespace DAL.Pro
{
    public class ProTenderCommitteeRepository : GenericRepository<ProTenderCommittee>
    {
        public ProTenderCommitteeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderCommittee> Filter(ProTenderCommitteeFilter filter)
        {
            IQueryable<ProTenderCommittee> result = GetAll();
            if (filter.StatusId.HasValue)
            {
                result = result.Where(e => e.StatusId == filter.StatusId);
            }
            if (filter.TenderId.HasValue)
            {
                result = result.Where(e => e.TenderId == filter.TenderId);
            }
            return result;
        }
    }
}
