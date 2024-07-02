using AutoMapper;
using Entities.Helpers;
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
            CreateMap<ProPurchaseOrderInputVM, ProPurchaseOrder>()
                .ForMember(
                dest => dest.DeliverDelayInDays, 
                cfg => cfg.MapFrom(src => 
                    src.AdditionDate !=
                    src.StoreDeliverDate ?
                    (src.AdditionDate - src.StoreDeliverDate).Value.TotalDays :
                    0))
                .AfterMap<ProPurchaseOrderInputVMAttachmentMapping>();

            CreateMap<ProPurchaseOrder, ProPurchaseOrderOutputVM>()
                .ForMember(
                dest => dest.VendorsNames,
                cfg => cfg.MapFrom(src =>
                    src.Details
                    .Select(e => e.QuotationDetails.Quotation.Vendor.Name)));
        }
        public class ProPurchaseOrderInputVMAttachmentMapping : IMappingAction<ProPurchaseOrderInputVM, ProPurchaseOrder>
        {
            public async void Process(ProPurchaseOrderInputVM source, ProPurchaseOrder destination, ResolutionContext context)
            {
                destination.Attachment = await FileHelper.UploadFile(source.Attachment);
            }
        }
    }
}
