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
using Entities.ViewModels.VL.VlManufacturerViewModels;
using Entities.ViewModels.VL.VlManufacturer;

namespace Business.Vl
{
    public class VlManufacturerService : GenericService<VlManufacturer>
    {
        new readonly VlManufacturerRepository _repository;
        public VlManufacturerService(VlManufacturerRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<VlManufacturer> GetFiltered(VlManufacturerFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
