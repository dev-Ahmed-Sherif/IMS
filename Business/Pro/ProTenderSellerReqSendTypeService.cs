using DAL;
using DAL.Pro;
using Entities.ExtensionMethods;
using Entities.Models.Pro;
using Entities.ViewModels;
using System.Linq;
using AutoMapper;
using Entities.ViewModels.Pro.ProTenderSellerReqSendTypeViewModels;

namespace Business.Pro
{
    public class ProTenderSellerReqSendTypeService : GenericService<ProTenderSellerReqSendType>
    {
        new readonly ProTenderSellerReqSendTypeRepository _repository;

        public ProTenderSellerReqSendTypeService(ProTenderSellerReqSendTypeRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<ProTenderSellerReqSendType> GetFiltered(ProTenderSellerReqSendTypeFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
