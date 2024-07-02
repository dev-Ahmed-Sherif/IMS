using DAL;
using DAL.Pro;
using Entities.ExtensionMethods;
using Entities.Models.Pro;
using Entities.ViewModels;
using System.Linq;
using AutoMapper;
using Entities.ViewModels.Pro.ProTenderVendorReqSendTypeViewModels;

namespace Business.Pro
{
    public class ProTenderVendorReqSendTypeService : GenericService<ProTenderVendorReqSendType>
    {
        new readonly ProTenderVendorReqSendTypeRepository _repository;

        public ProTenderVendorReqSendTypeService(ProTenderVendorReqSendTypeRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<ProTenderVendorReqSendType> GetFiltered(ProTenderVendorReqSendTypeFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
