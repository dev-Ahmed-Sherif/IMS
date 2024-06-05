using DAL;
using DAL.Pro;
using Entities.ExtensionMethods;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using Entities.ViewModels;
using Entities.ViewModels.Pro.ProTenderOpeningViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pro
{
    public class ProTenderOpeningService : GenericService<ProTenderOpening>
    {
        new ProTenderOpeningRepository _repository;
        public ProTenderOpeningService(ProTenderOpeningRepository repository, UnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }
        public PaginatedResultUnMapped<ProTenderOpening> GetFilteredPaginated(PaginationInputViewModel pagination, ProTenderOpeningFilter filter)
        {
            IQueryable<ProTenderOpening> filteredSet = _repository.Filter(filter);
            return filteredSet.ToPaginatedResultUnMapped(pagination);
        }
    }
}
