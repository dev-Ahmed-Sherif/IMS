using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProPurchaseOrderProfile : Profile
    {
        public ProPurchaseOrderProfile()
        {
            CreateMap<ProPurchaseOrder, ProPurchaseOrderGeneralVM>()
                .ReverseMap();
        }
    }
}
