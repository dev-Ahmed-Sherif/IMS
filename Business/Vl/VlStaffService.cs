using AutoMapper;
using DAL.VL;
using DAL;
using Entities.Models.VL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ViewModels.VL.VlStaff;

namespace Business.Vl
{
    public  class VlStaffService : GenericService<VlStaff>
    {
        new readonly VlStaffRepository _repository;
        public VlStaffService(VlStaffRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<VlStaff> GetFiltered(VlStaffFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
