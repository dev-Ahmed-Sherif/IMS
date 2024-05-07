using DAL;
using DAL.STR.StoreOpen;
using Entities.Models.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.STR.StoreOpen.StrOpeningStockDetailsRepository;

namespace Business.STR.StoreOpen
{
    public class StrOpeningStockDetailsService
    {
        public StrOpeningStockDetailsRepository _StrOpeningStockDetailsRepository;
        public StrOpeningStockDetailsService(StrOpeningStockDetailsRepository StrOpeningStockDetailsRepository)
        {
            _StrOpeningStockDetailsRepository = StrOpeningStockDetailsRepository;
        }
        public string Add(StrOpeningStockDetailsGeneralVM opening_Stock_Details)
        {
            return _StrOpeningStockDetailsRepository.Add(opening_Stock_Details);
        }

        public string Update( StrOpeningStockDetailsVM opening_Stock_Details)
        {
            return _StrOpeningStockDetailsRepository.Update(opening_Stock_Details);
        }

        public string Delete(int opening_Stock_DetailsId)
        {
            return _StrOpeningStockDetailsRepository.Delete(opening_Stock_DetailsId);
        }

        public List<StrOpeningStockDetailsGetVM> GetAll()
        {
            return _StrOpeningStockDetailsRepository.GetAll();
        }
        public StrOpeningStockDetailsGetVM GetById(int opening_StockdetailsId)
        {
            return _StrOpeningStockDetailsRepository.GetById(opening_StockdetailsId);
        }

        public List<StrOpeningStockDetailsGetVM> Search(searchopeningstock searchModel)
        {
            return _StrOpeningStockDetailsRepository.Search(searchModel);
        }
        public List<StrOpeningStockDetailsGetVM> GetByHeader(int id)
        {
            return _StrOpeningStockDetailsRepository.GetByHeader(id);
        }
        public PaginatedResult<StrOpeningStockDetailsGetVM> getAllByPagination(int page, int pageSize, int id)
        {
            return _StrOpeningStockDetailsRepository.GetAllByPagination(page, pageSize, id);
        }
        public StrOpeningStockDetailsGetVM GetopenstockdetailsByStore(int storeid, int itemid, int fiscalyearid)
        {
            return _StrOpeningStockDetailsRepository.GetopenstockdetailsByStore(storeid, itemid, fiscalyearid);
        }

    }
}
