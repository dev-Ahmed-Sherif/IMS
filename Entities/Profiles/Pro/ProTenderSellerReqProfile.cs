using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderSellerReqViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTenderSellerReqProfile : Profile
    {
        public ProTenderSellerReqProfile()
        {
            CreateMap<ProTenderSellerReqInputVM, ProTenderSellerReq>();
            CreateMap<ProTenderSellerReq, ProTenderSellerReqOutputVM>();
        }
    }
}
