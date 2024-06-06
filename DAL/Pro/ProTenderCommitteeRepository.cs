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
            if (filter.Close.HasValue)
            {
                result = result.Where(e => e.Close == filter.Close);
            }
            if (filter.TenderId.HasValue)
            {
                result = result.Where(e => e.TenderId == filter.TenderId);
            }
            if (filter.EmployeeId.HasValue)
            {
                result = result.Where(e => e.EmployeeId == filter.EmployeeId);
            }
            if (filter.RoleId.HasValue)
            {
                result = result.Where(e => e.RoleId == filter.RoleId);
            }

            return result;
        }
    }
}
