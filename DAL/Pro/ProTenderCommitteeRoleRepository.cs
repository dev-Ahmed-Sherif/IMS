using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderCommitteeRoleViewModels;
using Entities.ViewModels.Pro.ProTenderCommitteeViewModels;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using System.Linq;

namespace DAL.Pro
{
    public class ProTenderCommitteeRoleRepository : GenericRepository<ProTenderCommitteeRole>
    {
        public ProTenderCommitteeRoleRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderCommitteeRole> Filter(ProTenderCommitteeRoleFilter filter)
        {
            IQueryable<ProTenderCommitteeRole> result = GetAll();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = result.Where(e => e.Name.Contains(filter.Name));
            }

            return result;
        }
    }
}
