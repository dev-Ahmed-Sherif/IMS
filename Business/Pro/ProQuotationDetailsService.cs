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
using Entities.ViewModels.Pro.ProQuotationDetailsViewModels;
using AutoMapper;

namespace Business.Pro
{
    public class ProQuotationDetailsService : GenericService<ProQuotationDetails>
    {
        new readonly ProQuotationDetailsRepository _repository;
        public ProQuotationDetailsService(ProQuotationDetailsRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public PaginatedResultUnMapped<ProQuotationDetails> GetFilteredPaginated(PaginationInputViewModel pagination, ProQuotationDetailsFilter filter)
        {
            IQueryable<ProQuotationDetails> filteredSet = _repository.Filter(filter);
            return filteredSet.ToPaginatedResultUnMapped(pagination);
        }
    }
}
