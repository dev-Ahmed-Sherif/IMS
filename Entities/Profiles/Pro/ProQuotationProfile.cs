using AutoMapper;
using Entities.Enums;
using Entities.Helpers;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using Entities.ViewModels.Pro.ProQuotationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProQuotationProfile : Profile
    {
        public ProQuotationProfile()
        {
            CreateMap<ProQuotation, ProQuotationOutputVM>()
             .ForMember(dest => dest.SellerName, cfg => cfg.MapFrom(src => src.Seller.Name))
             .ForMember(dest => dest.TenderName, cfg => cfg.MapFrom(src => src.Tender.Name))
            .ForMember(dest => dest.ReceiveTypeName, cfg => cfg.MapFrom(src => src.ReceiveType.Name));
            CreateMap<ProQuotationInputVM, ProQuotation>()

                .AfterMap<ProQuotationInputMapping>();
        }
        public class ProQuotationInputMapping : IMappingAction<ProQuotationInputVM, ProQuotation>
        {
            public async void Process(ProQuotationInputVM source, ProQuotation destination, ResolutionContext context)
            {
                destination.Attachment = source.Attachment != null ? await FileHelper.UploadFile(source.Attachment) : "";
            }
        }
    }
}
