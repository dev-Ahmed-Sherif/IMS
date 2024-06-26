using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderOpeningDetailsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTenderOpeningDetailsProfile : Profile
    {
        public ProTenderOpeningDetailsProfile()
        {
            CreateMap<ProTenderOpeningDetailsInputVM, ProTenderOpeningDetails>();
            CreateMap<ProTenderOpeningDetails, ProTenderOpeningDetailsOutputVM>();
        }
    }
}
