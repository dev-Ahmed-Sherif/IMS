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
    }
}
