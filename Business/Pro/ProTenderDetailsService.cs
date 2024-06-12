using AutoMapper;
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
        public ProTenderDetailsService(ProTenderDetailsRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }
        public IQueryable<ProTenderDetails> GetFiltered(ProTenderDetailsFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
