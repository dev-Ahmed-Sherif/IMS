using AutoMapper;
using Entities.Enums;
using Entities.Helpers;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using Entities.ViewModels.Pro.ProQuotationDetailsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProQuotationDetailsProfile : Profile
    {
        public ProQuotationDetailsProfile()
        {
            CreateMap<ProQuotationDetails, ProQuotationDetailsOutputVM>();

            CreateMap<ProQuotationDetailsInputVM, ProQuotationDetails>()
                .AfterMap<ProQuotationDetailsInputMapping>();
        }
        public class ProQuotationDetailsInputMapping : IMappingAction<ProQuotationDetailsInputVM, ProQuotationDetails>
        {
            public async void Process(ProQuotationDetailsInputVM source, ProQuotationDetails destination, ResolutionContext context)
            {
                destination.Attachment = source.Attachment != null ? await FileHelper.UploadFile(source.Attachment) : "";
            }
        }
    }
}
