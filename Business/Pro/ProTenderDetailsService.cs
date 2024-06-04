using DAL;
using DAL.Pro;
using Entities.ExtensionMethods;
using Entities.Models.Pro;
using Entities.ViewModels;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pro
{
    public class ProTenderDetailsService : GenericService<ProTenderDetails>
    {
        private new readonly ProTenderDetailsRepository _repository;
        public ProTenderDetailsService(ProTenderDetailsRepository repository, UnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }
        public PaginatedResultUnMapped<ProTenderDetails> GetFilteredPaginated(PaginationInputViewModel pagination, ProTenderDetailsFilter filter)
        {
            IQueryable<ProTenderDetails> filteredSet = _repository.Filter(filter);
            return filteredSet.ToPaginatedResultUnMapped(pagination);
        }
    }
}
