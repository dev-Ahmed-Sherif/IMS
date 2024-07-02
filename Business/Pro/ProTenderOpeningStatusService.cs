using DAL;
using DAL.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;
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

        public IQueryable<ProTenderOpeningStatus> GetFiltered(ProTenderOpeningStatusFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
