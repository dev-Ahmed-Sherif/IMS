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
using AutoMapper;

namespace Business.Pro
{
    public class ProTenderCommitteeService : GenericService<ProTenderCommittee>
    {
        new readonly ProTenderCommitteeRepository _repository;
        public ProTenderCommitteeService(ProTenderCommitteeRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }
        public IQueryable<ProTenderCommittee> GetFiltered(ProTenderCommitteeFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
