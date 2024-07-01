using AutoMapper;
using DAL;
using DAL.Pro;
using Entities.Helpers;
using Entities.Models.Pro;
using Entities.ViewModels.Pro;
using Entities.ViewModels.Pro.ProVendorAttachments;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Pro
{
    public class ProVendorAttachmentService : GenericService<ProVendorAttachment>
    {
        public ProVendorAttachmentRepository _ProVendorAttachmentsRepository;

        public ProVendorAttachmentService(GenericRepository<ProVendorAttachment> repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
