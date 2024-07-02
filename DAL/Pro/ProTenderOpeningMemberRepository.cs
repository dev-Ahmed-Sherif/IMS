using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderComitteeMemberViewModels;
using Entities.ViewModels.Pro.ProTenderOpeningMemberViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace DAL.Pro
{
    public class ProTenderOpeningMemberRepository : GenericRepository<ProTenderOpeningMember>
    {
        public ProTenderOpeningMemberRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderOpeningMember> Filter(ProTenderOpeningMemberFilter filter)
        {
            IQueryable<ProTenderOpeningMember> result = GetAll();
            if (filter.TenderOpeningId.HasValue)
            {
                result = result.Where(e => e.TenderOpeningId == filter.TenderOpeningId);
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
                result = result.Where(e => e.Employee.Name.Contains(filter.EmployeeName, System.StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }
    }
}
