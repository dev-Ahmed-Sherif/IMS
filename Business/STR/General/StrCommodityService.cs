using DAL;
using DAL.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.General
{
    public class StrCommodityService
    {
        public StrCommodityRepository _STR_CommodityRepository;
        public StrCommodityService(StrCommodityRepository StrCommodityRepository)
        {
            _STR_CommodityRepository = StrCommodityRepository;
        }
        public string GetLastNo()
        {
            return _STR_CommodityRepository.GetLastNo();
        }
        public string Add(StrCommodityVM commodity)
        {
            return _STR_CommodityRepository.Add(commodity);
        }

        public string Update(StrCommodityVM commodity)
        {
            return _STR_CommodityRepository.Update(commodity);
        }

        public string Delete(int commodityId)
        {
            return _STR_CommodityRepository.Delete(commodityId);
        }

        public List<StrCommodityGetVM> GetAll()
        {
            return _STR_CommodityRepository.GetAll();
        }
        public StrCommodityGetVM GetById(int commodityId)
        {
            return _STR_CommodityRepository.GetById(commodityId);
        }

        public StrCommodityVM GetWithGrades(int groupId)
        {
            return _STR_CommodityRepository.GetWithGrades(groupId);
        }
    }
}
