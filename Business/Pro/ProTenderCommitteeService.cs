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
using Entities.ViewModels.Pro.ProTenderCommitteeViewModels;

namespace Business.Pro
{
    public class ProTenderCommitteeService : GenericService<ProTenderCommittee>
    {
        new readonly ProTenderCommitteeRepository _repository;
        public ProTenderCommitteeService(ProTenderCommitteeRepository repository, UnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }
        public PaginatedResultUnMapped<ProTenderCommittee> GetFilteredPaginated(PaginationInputViewModel pagination, ProTenderCommitteeFilter filter)
        {
            IQueryable<ProTenderCommittee> filteredSet = _repository.Filter(filter);
            return filteredSet.ToPaginatedResultUnMapped(pagination);
        }
    }
}
