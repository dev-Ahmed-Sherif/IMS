using DAL;
using DAL.Pro;
using Entities.ExtensionMethods;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ViewModels.Pro.ProTenderSellerReqViewModels;
using AutoMapper;

namespace Business.Pro
{
    public class ProTenderSellerReqService : GenericService<ProTenderSellerReq>
    {
        new readonly ProTenderSellerReqRepository _repository;

        public ProTenderSellerReqService(ProTenderSellerReqRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public PaginatedResultUnMapped<ProTenderSellerReq> GetFilteredPaginated(PaginationInputViewModel pagination, ProTenderSellerReqFilter filter)
        {
            IQueryable<ProTenderSellerReq> filteredSet = _repository.Filter(filter);
            return filteredSet.ToPaginatedResultUnMapped(pagination);
        }
    }
}
