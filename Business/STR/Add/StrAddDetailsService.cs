using DAL;
using DAL.STR.Add;
using Entities.Models.STR.Add;
using Entities.ViewModels;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Entities.ViewModels.STR.AddDetails.StrAddDetailsGeneralVM;

namespace Business.STR.Add
{
    public class StrAddDetailsService
    {
        public StrAddDetailsRepository _STR_AddDetailsRepository;

        public StrAddDetailsService(StrAddDetailsRepository StrAddDetailsRepository)
        {
            _STR_AddDetailsRepository = StrAddDetailsRepository;
        }
        public string Add(StrAddWithavgprice add_Details)
        {
            return _STR_AddDetailsRepository.Add(add_Details);
        }
        public string Update(StrAddWithavgprice sTR_AddDetails)
        {
            return _STR_AddDetailsRepository.Update(sTR_AddDetails);
        }
        public string Delete(int add_DetailsId)
        {
            return _STR_AddDetailsRepository.Delete(add_DetailsId);
        }
        public List<StrAddDetailsGetVM> GetAll()
        {
            return _STR_AddDetailsRepository.GetAll();
        }
        public StrAddDetailsGetVM GetById(int sTR_AddDetailsId)
        {
            return _STR_AddDetailsRepository.GetById(sTR_AddDetailsId);
        }
        public List<StrAddDetailsGetVM> Search(searchadd searchModel)
        {
            return _STR_AddDetailsRepository.Search(searchModel);
        }
        public List<StrAddDetailsGetVM> GetByHeader(int strAddId)
        {
            return _STR_AddDetailsRepository.GetByHeader(strAddId);
        }

        public PaginatedResult<StrAddDetailsGetVM> getAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _STR_AddDetailsRepository.GetAllByPagination(page, pageSize, HeaderId);
        }
        public decimal NewAvgPrice(int itemid, decimal newprice, int FiscalYearId)
        {
            return  _STR_AddDetailsRepository.NewAvgPrice(itemid, newprice, FiscalYearId);
        }
        public decimal GetAvgPrice(int FiscalYearid, int itemid)
        {
            return _STR_AddDetailsRepository.GetAvgPrice(FiscalYearid, itemid);
        }
        public decimal GetSumOfQty(int storeid, int itemid)
        {
            return _STR_AddDetailsRepository.GetSumOfQty(storeid, itemid);
        }
        public (decimal sumOfQty, decimal sumOfTotal) GetSumOfQtyaddtype(int storeid, int addtypeid, DateTime startdate, DateTime enddate)
        {
            return _STR_AddDetailsRepository.GetSumOfQtyaddtype(storeid, addtypeid, startdate, enddate);
        }
        public (decimal sumOfQty, decimal sumOfTotal) GetSumOfQtywithdrawtype(int storeid, int WithDrawTypeId, DateTime startdate, DateTime enddate)
        {
            return _STR_AddDetailsRepository.GetSumOfQtywithdrawtype(storeid, WithDrawTypeId, startdate, enddate);
        }
    }
}
