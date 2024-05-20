using DAL;
using DAL.STR.General;
using Entities.ReportViewModel;
using Entities.ViewModels.STR.General;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static DAL.STR.General.StrItemRepository;
using Microsoft.Reporting.NETCore;

namespace Business.STR.General
{
    public class StrItemService
    {
        public StrItemRepository _StrItemRepository;
        public StrItemService(StrItemRepository StrItemRepository)
        {
            _StrItemRepository = StrItemRepository;
        }
        public string GetLastNo(int GroupId)
        {
            return _StrItemRepository.GetLastNo(GroupId);
        }
        public string Add(StrItemVM item)
        {
            return _StrItemRepository.Add(item);
        }
        public string Update(StrItemVM item)
        {
            return _StrItemRepository.Update(item);
        }

        public string Delete(int itemId)
        {
            return _StrItemRepository.Delete(itemId);
        }

        public List<StrItemGetVM> GetAll()
        {
            return _StrItemRepository.GetAll();
        }
        public PaginatedResult <StrItemGetVM> GetAllByPagination(int page, int pageSize)
        {
            return _StrItemRepository.GetAllByPagination(page, pageSize);
        }
        public StrItemGetVM GetById(int itemId)
        {
            return _StrItemRepository.GetById(itemId);
        }

        public List<StrItemGetVM> GetByName(string itemName)
        {
            return _StrItemRepository.GetByName(itemName);
        }
        public List<StrItemGetVM> Search(searchgeneral searchModel)
        {
            return _StrItemRepository.Search(searchModel);
        }
        public PaginatedResult<StrItemGetVM> SearchPagination(searchgeneral searchModel, int page, int pageSize)
        {
            return _StrItemRepository.SearchPagination(searchModel,page,pageSize);
        }
        public List<dynamic> GetTransactions(int soreId, int itemId, DateTime startdate, DateTime enddate, int FiscalYearId)
        {
            return _StrItemRepository.GetTransactions(soreId, itemId, startdate, enddate, FiscalYearId);
        }

        public List<object> GetSumOfQtyBetweenTwoDate(int storeId, DateTime startdate, DateTime enddate)
        {
            return _StrItemRepository.GetSumOfQtyBetweenTwoDate(storeId, startdate, enddate);
        }
        public List<object> GetItemsWithPositiveTotalQty(int storeId, int fiscalyearId)
        {
            return _StrItemRepository.GetItemsWithPositiveTotalQty(storeId, fiscalyearId);
        }
        public List<dynamic> GetItemInStores(int itemId, DateTime startdate, DateTime enddate, int FiscalYearId)
        {
            return _StrItemRepository.GetItemInStores(itemId, startdate, enddate, FiscalYearId);
        }

        public async Task<List<BalanceStoreViewModel>> GetBalanceStoreAsync
            (int storeId, DateTime startDate, DateTime endDate, int fiscalYearId)
        {
            return await _StrItemRepository.GetBalanceStoreAsync(storeId, startDate, endDate, fiscalYearId);
        }

        public async Task<byte[]> GenerateReportAsync(string reportName, string reportType, reportsearch searchModel, int storeId, int itemId, DateTime startdate, DateTime enddate, int FiscalYearId)
        {
            // get report file

            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Business.dll", string.Empty);
            string rdclFilePath = string.Format("{0}ReportsFiles\\Store\\{1}.rdlc", fileDirPath, reportName);

            // file encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            //LocalReport report = new LocalReport(rdclFilePath);
            LocalReport report = new LocalReport();
            report.ReportPath = rdclFilePath;

            // prepare data for report
            

            // all item
            if (reportName == "ItemsReport")
            {
                List<StrItemGetVM> strItems = Search(searchModel);
                //report.AddDataSource("StrItemsReport", strItems);
                report.DataSources.Add(new ReportDataSource() { Name = "StrItemsReport", Value = strItems });
            }
            // item moving with storeid-itemid
            else if (reportName == "ItemsTransactionReport")
            {
                List<dynamic> strItemsTrans = GetTransactions(storeId, itemId, startdate, enddate, FiscalYearId);
                //report.AddDataSource("StrItemsTrans", strItemsTrans);
                report.DataSources.Add(new ReportDataSource() { Name = "StrItemsTrans", Value = strItemsTrans });
            }
            // report by store
            else if (reportName == "ItemsTakingReport")
            {
                List<BalanceStoreViewModel> strItemsTaking = await GetBalanceStoreAsync(storeId, startdate, enddate, FiscalYearId);
                //report.AddDataSource("STRItemsTaking", strItemsTaking);
                report.DataSources.Add(new ReportDataSource() { Name = "STRItemsTaking", Value = strItemsTaking });
            }
            else if (reportName == "ItemQtyInStoresReport")
            {
                List<dynamic> ItemQtyInStores = GetItemInStores(itemId, startdate, enddate, FiscalYearId);
                //report.AddDataSource("ItemQtyInStores", ItemQtyInStores);
                report.DataSources.Add(new ReportDataSource() { Name = "ItemQtyInStores", Value = ItemQtyInStores });
            }

            //var result = report.Execute(Entities.Helpers.ReportHelper.GetRenderType(reportType));

            //return result.MainStream;

            byte[] renderedBytes = report.Render(reportType);
            return renderedBytes;
        }

    }
}
