using AutoMapper;
using DAL.VL;
using DAL;
using Entities.Models.VL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ViewModels.VL.VlStaffPosition;

namespace Business.Vl
{
    public class VlStaffPositionService : GenericService<VlStaffPosition>
    {
        new readonly VlStaffPositionRepository _repository;
        public VlStaffPositionService(VlStaffPositionRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<VlStaffPosition> GetFiltered(VlStaffPositionFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
