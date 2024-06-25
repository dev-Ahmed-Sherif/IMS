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
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;
using AutoMapper;

namespace Business.Pro
{
    public class ProTenderVendorReqService : GenericService<ProTenderVendorReq>
    {
        new readonly ProTenderVendorReqRepository _repository;

        public ProTenderVendorReqService(ProTenderVendorReqRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<ProTenderVendorReq> GetFiltered(ProTenderVendorReqFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
