using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderCommitteeViewModels;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using Microsoft.IdentityModel.Tokens;
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
            if (filter.Result.HasValue)
            {
                result = result.Where(e => e.Result == filter.Result);
            }
            if (filter.TenderId.HasValue)
            {
                result = result.Where(e => e.TenderId == filter.TenderId);
            }
            if (filter.Date.HasValue)
            {
                result = result.Where(e => e.Date.Date == filter.Date.Value.Date);
            }
            if (!filter.Code.IsNullOrEmpty())
            {
                result = result.Where(e => e.Code.Equals(filter.Code, System.StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
}
