using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderComitteeMemberViewModels;
using Entities.ViewModels.Pro.ProTenderCommitteeMemberViewModels;
using Microsoft.IdentityModel.Tokens;
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
            if (filter.RoleId.HasValue)
            {
                result = result.Where(e => e.RoleId == filter.RoleId);
            }
            if (filter.EmployeeId.HasValue)
            {
                result = result.Where(e => e.EmployeeId == filter.EmployeeId);
            }
            if (!filter.EmployeeName.IsNullOrEmpty())
            {
                result =
                    result
                    .Where(e =>
                        e
                        .Employee
                        .Name
                        .Contains(filter.EmployeeName, System.StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
}
