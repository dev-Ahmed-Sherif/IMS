using AutoMapper;
using DAL;
using DAL.Pro;
using Entities.ExtensionMethods;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using Entities.Helpers;

namespace Business.Pro
{
    public class ProPurchaseOrderService : GenericService<ProPurchaseOrder>
    {
        private new readonly ProPurchaseOrderRepository _repository;
        public ProPurchaseOrderService(ProPurchaseOrderRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }
        public IQueryable<ProPurchaseOrder> GetFiltered(ProPurchaseOrderFilter filter)
        {
            return _repository.Filter(filter);
        }
        public async Task<int> Add(ProPurchaseOrderInputVM input)
        {
            ProPurchaseOrder model = _mapper.Map<ProPurchaseOrder>(input);
            double deliverDelayInDays =
                input.AdditionDate != input.StoreDeliverDate ?
                (input.StoreDeliverDate! - input.AdditionDate!).Value.TotalDays :
                0;

            model.DeliverDelayInDays = Convert.ToInt32(deliverDelayInDays);
            if (input.Attachment != null)
            {
                model.AttachmentUrl = await FileHelper.UploadFile(input.Attachment);
            }
            else
            {
                model.AttachmentUrl = string.Empty;
            }
            await base.Add(model);
            return model.Id;
        }
        public async Task<int?> Update(int id, ProPurchaseOrderInputVM input)
        {
            ProPurchaseOrder model = _repository.GetById(id);
            if (model == null) return null;
            double deliverDelayInDays =
                input.AdditionDate != input.StoreDeliverDate ?
                (input.StoreDeliverDate! - input.AdditionDate!).Value.TotalDays :
                0;

            model.DeliverDelayInDays = Convert.ToInt32(deliverDelayInDays);
            if (input.Attachment != null)
            {
                model.AttachmentUrl = await FileHelper.UploadFile(input.Attachment);
            }
            else
            {
                model.AttachmentUrl = string.Empty;
            }
            await base.Update(model);
            return model.Id;
        }
    }
}
