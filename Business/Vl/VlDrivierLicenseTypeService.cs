using AutoMapper;
using DAL.VL;
using DAL;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlDrivierLicenseTypeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Vl
{
    public class VlDrivierLicenseTypeService : GenericService<VlDrivierLicenseType>
    {
        new readonly VlDrivierLicenseTypeRepository _repository;
        public VlDrivierLicenseTypeService(VlDrivierLicenseTypeRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<VlDrivierLicenseType> GetFiltered(VlDrivierLicenseTypeFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
