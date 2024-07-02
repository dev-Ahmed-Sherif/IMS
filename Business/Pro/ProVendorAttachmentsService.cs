using AutoMapper;
using DAL;
using DAL.Migrations;
using DAL.Pro;
using Entities.Helpers;
using Entities.Models.Pro;
using Entities.ViewModels.Pro;
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;
using Entities.ViewModels.Pro.ProVendorAttachments;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Pro
{
    public class ProVendorAttachmentService : GenericService<ProVendorAttachment>
    {
        public new ProVendorAttachmentRepository _repository;

        public ProVendorAttachmentService(ProVendorAttachmentRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
        public IQueryable<ProVendorAttachment> GetFiltered(ProVendorAttachmentFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
