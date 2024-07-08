using AutoMapper;
using Entities.Helpers;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProVendorAttachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProVendorAttachmentProfile : Profile
    {
        public ProVendorAttachmentProfile()
        {
            CreateMap<ProVendorAttachmentInputVM, ProVendorAttachment>();
            CreateMap<ProVendorAttachment, ProVendorAttachmentOutputVM>();
        }
        
    }
}
