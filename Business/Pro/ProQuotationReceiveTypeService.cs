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
using Entities.ViewModels.Pro.ProQuotationReceiveTypeViewModels;
using AutoMapper;

namespace Business.Pro
{
    public class ProQuotationReceiveTypeService : GenericService<ProQuotationReceiveType>
    {
        new readonly ProQuotationReceiveTypeRepository _repository;
        public ProQuotationReceiveTypeService(ProQuotationReceiveTypeRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<ProQuotationReceiveType> GetFiltered(ProQuotationReceiveTypeFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
