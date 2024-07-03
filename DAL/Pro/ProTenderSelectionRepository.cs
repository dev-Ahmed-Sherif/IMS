using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderSelectionViewModels;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using System.Linq;

namespace DAL.Pro
{
    public class ProTenderSelectionRepository : GenericRepository<ProTenderSelection>
    {
        public ProTenderSelectionRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<ProTenderSelection> Filter(ProTenderSelectionFilter filter)
        {
            IQueryable<ProTenderSelection> result = _dbSet;
            if (filter.TenderDetailsId.HasValue)
            {
                result = result.Where(e => e.TenderDetailsId == filter.TenderDetailsId);
            }
            if (filter.QuotationDetailsId.HasValue)
            {
                result = result.Where(e => e.QuotationDetailsId == filter.QuotationDetailsId);
            }
            if (filter.CommitteeId.HasValue)
            {
                result = result.Where(e => e.CommitteeId == filter.CommitteeId);
            }
            if (filter.TechnicalPass.HasValue)
            {
                result = result.Where(e => e.TechnicalPass == filter.TechnicalPass);
            }
            if (filter.TechnicalScore.HasValue)
            {
                result = result.Where(e => e.TechnicalScore == filter.TechnicalScore);
            }
            if (filter.FinancialScore.HasValue)
            {
                result = result.Where(e => e.FinancialScore == filter.FinancialScore);
            }
            if (filter.TotalScore.HasValue)
            {
                result = result.Where(e => e.TotalScore == filter.TotalScore);
            }

            return result;
        }
    }
}
