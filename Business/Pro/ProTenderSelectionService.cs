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
using Entities.ViewModels.Pro.ProTenderSelectionViewModels;
using AutoMapper;

namespace Business.Pro
{
    public class ProTenderSelectionService : GenericService<ProTenderSelection>
    {
        new readonly ProTenderSelectionRepository _repository;
        public ProTenderSelectionService(ProTenderSelectionRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }
        public PaginatedResultUnMapped<ProTenderSelection> GetFilteredPaginated(PaginationInputViewModel pagination, ProTenderSelectionFilter filter)
        {
            IQueryable<ProTenderSelection> filteredSet = _repository.Filter(filter);
            return filteredSet.ToPaginatedResultUnMapped(pagination);
        }
    }
}
