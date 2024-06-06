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
using Entities.ViewModels.Pro.ProQuotationViewModels;
using AutoMapper;

namespace Business.Pro
{
    public class ProQuotationService : GenericService<ProQuotation>
    {
        new readonly ProQuotationRepository _repository;
        public ProQuotationService(ProQuotationRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public PaginatedResultUnMapped<ProQuotation> GetFilteredPaginated(PaginationInputViewModel pagination, ProQuotationFilter filter)
        {
            IQueryable<ProQuotation> filteredSet = _repository.Filter(filter);
            return filteredSet.ToPaginatedResultUnMapped(pagination);
        }
    }
}
