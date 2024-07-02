using AutoMapper;
using DAL.VL;
using DAL;
using Entities.Models.VL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ViewModels.VL.VlStaffStatus;

namespace Business.Vl
{
   public class VlStaffStatusService : GenericService<VlStaffStatus>
    {
        new readonly VlStaffStatusRepository _repository;
        public VlStaffStatusService(VlStaffStatusRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<VlStaffStatus> GetFiltered(VlStaffStatusFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
