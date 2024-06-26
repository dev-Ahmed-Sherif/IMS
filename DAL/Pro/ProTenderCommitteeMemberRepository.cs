using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderComitteeMemberViewModels;
using Entities.ViewModels.Pro.ProTenderCommitteeMemberViewModels;
using System.Linq;

namespace DAL.Pro
{
    public class ProTenderCommitteeMemberRepository : GenericRepository<ProTenderCommitteeMember>
    {
        public ProTenderCommitteeMemberRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderCommitteeMember> Filter(ProTenderCommitteeMemberFilter filter)
        {
            IQueryable<ProTenderCommitteeMember> result = GetAll();
            if (filter.TenderCommitteeId.HasValue)
            {
                result = result.Where(e => e.TenderCommitteeId == filter.TenderCommitteeId);
            }
            if (filter.EmployeeId.HasValue)
            {
                result = result.Where(e => e.EmployeeId == filter.EmployeeId);
            }
            return result;
        }
    }
}
