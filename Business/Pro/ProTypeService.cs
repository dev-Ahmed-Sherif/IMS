using AutoMapper;
using DAL;
using DAL.Migrations;
using DAL.Pro;
using Entities.Helpers;
using Entities.Models.Pro;
using Entities.ViewModels.Pro;
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Pro
{
    public class ProTypeService : GenericService<ProType>
    {
        public new ProTypeRepository _repository;

        public ProTypeService(ProTypeRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }
    }
}
