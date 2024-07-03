using AutoMapper;
using DAL.VL;
using DAL;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlVehicleStatusViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Vl
{
    public class VlVehicleStatusService : GenericService<VlVehicleStatus>
    {
        new readonly VlVehicleStatusRepository _repository;
        public VlVehicleStatusService(VlVehicleStatusRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<VlVehicleStatus> GetFiltered(VlVehicleStatusFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
