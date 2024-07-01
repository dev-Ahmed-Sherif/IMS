using DAL;
using DAL.Pro;
using Entities.ViewModels.Pro;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Pro
{
    public class ProTenderBiddingMethodService
    {
        public ProTenderBiddingMethodRepository _ProTenderBiddingMethodRepository;
        public ProTenderBiddingMethodService(ProTenderBiddingMethodRepository ProTenderBiddingMethodRepository)
        {
            _ProTenderBiddingMethodRepository = ProTenderBiddingMethodRepository;
        }
        public string Add(ProTenderBiddingMethodGeneralVM vtype)
        {
            return _ProTenderBiddingMethodRepository.Add(vtype);
        }
        public string Update(ProTenderBiddingMethodVM type)
        {
            return _ProTenderBiddingMethodRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _ProTenderBiddingMethodRepository.Delete(typeId);
        }
        public List<ProTenderBiddingMethodGetVM> GetAll()
        {
            return _ProTenderBiddingMethodRepository.GetAll();
        }
        public ProTenderBiddingMethodGetVM GetById(int typeId)
        {
            return _ProTenderBiddingMethodRepository.GetById(typeId);
        }
        public string GetLastNo()
        {
            return _ProTenderBiddingMethodRepository.GetLastNo();
        }
    }
}
