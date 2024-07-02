using DAL;
using DAL.Pro;
using Entities.ExtensionMethods;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using Entities.ViewModels;
using Entities.ViewModels.Pro.ProTenderOpeningDetailsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Business.Pro
{
    public class ProTenderOpeningDetailsService : GenericService<ProTenderOpeningDetails>
    {
        new ProTenderOpeningDetailsRepository _repository;
        public ProTenderOpeningDetailsService(ProTenderOpeningDetailsRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }
        public IQueryable<ProTenderOpeningDetails> GetFiltered(ProTenderOpeningDetailsFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
