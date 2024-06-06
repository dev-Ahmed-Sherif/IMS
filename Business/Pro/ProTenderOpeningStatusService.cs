using DAL;
using DAL.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderSellerReqViewModels;
using Entities.ViewModels;
using System.Linq;
using Entities.ViewModels.Pro.ProTenderOpeningStatusViewModels;
using Entities.ExtensionMethods;
using AutoMapper;

namespace Business.Pro
{
    public class ProTenderOpeningStatusService : GenericService<ProTenderOpeningStatus>
    {
        new ProTenderOpeningStatusRepository _repository;

        public ProTenderOpeningStatusService(ProTenderOpeningStatusRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public PaginatedResultUnMapped<ProTenderOpeningStatus> GetFilteredPaginated(PaginationInputViewModel pagination, ProTenderOpeningStatusFilter filter)
        {
            IQueryable<ProTenderOpeningStatus> filteredSet = _repository.Filter(filter);
            return filteredSet.ToPaginatedResultUnMapped(pagination);
        }
    }
}
