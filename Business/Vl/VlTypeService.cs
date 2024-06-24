using AutoMapper;
using DAL.Pro;
using DAL;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProQuotationDetailsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.VL;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlTypeModels;

namespace Business.Vl
{
    public class VlTypeService : GenericService<VlType>
    {
        new readonly VlTypeRepository _repository;
        public VlTypeService(VlTypeRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<VlType> GetFiltered(VlTypeFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
