using DAL;
using DAL.Pro;
using Entities.ExtensionMethods;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using Entities.ViewModels;
using Entities.ViewModels.Pro.ProTenderOpeningViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Business.Pro
{
    public class ProTenderOpeningService : GenericService<ProTenderOpening>
    {
        new ProTenderOpeningRepository _repository;
        public ProTenderOpeningService(ProTenderOpeningRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }
        public IQueryable<ProTenderOpening> GetFiltered(ProTenderOpeningFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
