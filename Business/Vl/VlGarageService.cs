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
using Entities.ViewModels.VL.VlGarageViewModels;

namespace Business.Vl
{
    public class VlGarageService : GenericService<VlGarage>
    {
        new readonly VlGarageRepository _repository;
        public VlGarageService(VlGarageRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<VlGarage> GetFiltered(VlGarageFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
