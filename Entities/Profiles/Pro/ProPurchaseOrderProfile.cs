using AutoMapper;
using Entities.Helpers;
using Entities.Models.Cc;
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
                    (src.StoreDeliverDate - src.AdditionDate).Value.TotalDays :
                    0))
                .AfterMap<ProPurchaseOrderInputVMAttachmentMapping>();

            CreateMap<ProPurchaseOrder, ProPurchaseOrderOutputVM>()
                .BeforeMap<ProPurchaseOrderVendorsNamesMapping>();
        }
        public class ProPurchaseOrderInputVMAttachmentMapping : IMappingAction<ProPurchaseOrderInputVM, ProPurchaseOrder>
        {
            public async void Process(ProPurchaseOrderInputVM source, ProPurchaseOrder destination, ResolutionContext context)
            {
                destination.Attachment = await FileHelper.UploadFile(source.Attachment);
            }
        }
        public class ProPurchaseOrderVendorsNamesMapping : IMappingAction<ProPurchaseOrder, ProPurchaseOrderOutputVM>
        {
            public void Process(ProPurchaseOrder source, ProPurchaseOrderOutputVM destination, ResolutionContext context)
            {
                destination.VendorsNames = source.Details?.Select(e => e.QuotationDetails?.Quotation?.Vendor?.Name).ToHashSet();
            }
        }
    }
}
