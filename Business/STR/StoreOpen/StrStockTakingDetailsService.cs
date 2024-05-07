using DAL;
using DAL.STR.StoreOpen;
using Entities.Models.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.STR.StoreOpen.StrStockTakingDetailsRepository;

namespace Business.STR.StoreOpen
{
    public class StrStockTakingDetailsService

    {
        public StrStockTakingDetailsRepository _StrStockTakingDetailsRepository;
        public StrStockTakingDetailsService(StrStockTakingDetailsRepository StrStockTakingDetailsRepository)
        {
            _StrStockTakingDetailsRepository = StrStockTakingDetailsRepository;
        }
        public string Add(StrStockTakingDetailsGeneralVM StockTakingDetails)
        {
            return _StrStockTakingDetailsRepository.Add(StockTakingDetails);
        }

        public string Update( StrStockTakingDetailsVM StockTakingDetails)
        {
            return _StrStockTakingDetailsRepository.Update(StockTakingDetails);
        }

        public string Delete(int StockTakingDetailsId)
        {
            return _StrStockTakingDetailsRepository.Delete(StockTakingDetailsId);
        }

        public List<StrStockTakingDetailsGetVM> GetAll()
        {
            return _StrStockTakingDetailsRepository.GetAll();
        }
        public StrStockTakingDetailsGetVM GetById(int StockTakingdetailsId)
        {
            return _StrStockTakingDetailsRepository.GetById(StockTakingdetailsId);
        }
        public List<StrStockTakingDetailsGetVM> GetByHeader(int StockTakingid)
        {
            return _StrStockTakingDetailsRepository.GetByHeader(StockTakingid);
        }
        public List<StrStockTakingDetailsGetVM> Search(Search searchModel)
        {
            return _StrStockTakingDetailsRepository.Search(searchModel);
        }
        public List<StrStockTakingDetailsSumByStore> GetCommoditySum(Search searchModel)
        {
            return _StrStockTakingDetailsRepository.GetCommodityStockSum(searchModel);
        }
        public List<StrStockTakingDetailsSumByStore> GetPlatoonSum(Search searchModel)
        {
            return _StrStockTakingDetailsRepository.GetInvestComponentSum(searchModel);
        }
        public PaginatedResult<StrStockTakingDetailsGetVM> getAllByPagination(int StockTakingid, int page, int pageSize)
        {
            return _StrStockTakingDetailsRepository.GetAllByPagination(StockTakingid, page, pageSize);
        }

    }
}
