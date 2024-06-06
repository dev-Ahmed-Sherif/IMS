using AutoMapper;
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
using Entities.ViewModels.Pro.ProPurchaseOrderDetailsViewModels;

namespace Business.Pro
{
    public class ProPurchaseOrderDetailsService : GenericService<ProPurchaseOrderDetails>
    {
        private new readonly ProPurchaseOrderDetailsRepository _repository;
        public ProPurchaseOrderDetailsService(ProPurchaseOrderDetailsRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }
        public PaginatedResultUnMapped<ProPurchaseOrderDetails> GetFilteredPaginated(PaginationInputViewModel pagination, ProPurchaseOrderDetailsFilter filter)
        {
            IQueryable<ProPurchaseOrderDetails> filteredSet = _repository.Filter(filter);
            return filteredSet.ToPaginatedResultUnMapped(pagination);
        }
    }
}
