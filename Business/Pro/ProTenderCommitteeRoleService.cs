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
using Entities.ViewModels.Pro.ProTenderCommitteeRoleViewModels;
using AutoMapper;

namespace Business.Pro
{
    public class ProTenderCommitteeRoleService : GenericService<ProTenderCommitteeRole>
    {
        new readonly ProTenderCommitteeRoleRepository _repository;

        public ProTenderCommitteeRoleService(ProTenderCommitteeRoleRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public PaginatedResultUnMapped<ProTenderCommitteeRole> GetFilteredPaginated(PaginationInputViewModel pagination, ProTenderCommitteeRoleFilter filter)
        {
            IQueryable<ProTenderCommitteeRole> filteredSet = _repository.Filter(filter);
            return filteredSet.ToPaginatedResultUnMapped(pagination);
        }
    }
}
