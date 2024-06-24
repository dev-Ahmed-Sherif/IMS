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
using Entities.ViewModels.VL.VlModelViewModels;

namespace Business.Vl
{
    public class VlModelService : GenericService<VlModel>
    {
        new readonly VlModelRepository _repository;
        public VlModelService(VlModelRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<VlModel> GetFiltered(VlModelFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
