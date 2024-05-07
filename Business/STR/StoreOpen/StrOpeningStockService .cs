using DAL;
using DAL.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Reporting.NETCore;
using Entities.ViewModels;
using System.Threading.Tasks;

namespace Business.STR.StoreOpen
{
    public class StrOpeningStockService
    {
        public StrOpeningStockRepository _Repository;
        public StrOpeningStockDetailsRepository _StrOpeningStockDetailsRepository;
        public StrOpeningStockService
            (StrOpeningStockRepository StrOpeningStockRepository,
            StrOpeningStockDetailsRepository StrOpeningStockDetailsRepository)
        {
            _Repository = StrOpeningStockRepository;
            _StrOpeningStockDetailsRepository = StrOpeningStockDetailsRepository;
        }
        public int GetLastNo(int StoreId, int FiscalYearId)
        {
            return _Repository.GetLastNo(StoreId, FiscalYearId);
        }
        public async Task<string> Add(StrOpeningStockVM opening_Stock)
        {
            return await _Repository.Add(opening_Stock);
        }

        public async Task<string> Update(StrOpeningStockVM opening_Stock)
        {
            return await _Repository.Update(opening_Stock);
        }

        public string Delete(int opening_StockId)
        {
            return _Repository.Delete(opening_StockId);
        }

        public List<StrOpeningStockGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        public StrOpeningStockGetVM GetById(int opening_StockId)
        {
            return _Repository.GetById(opening_StockId);
        }
        public List<StrOpeningStockGetVM> Search(searchopeningstock searchModel)
        {
            return _Repository.Search(searchModel);
        }
        public PaginatedResult<StrOpeningStockGetVM> GetAllByPagination(int page, int pageSize, int fiscalYearId)
        {
            return _Repository.GetAllByPagination(page, pageSize, fiscalYearId);
        }
        public byte[] GenerateReportAsync(string reportName, string reportType, reportOpeningStock searchModel)
        {
            // get report file
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Business.dll", string.Empty);
            string rdclFilePath = string.Format("{0}ReportsFiles\\Stock\\{1}.rdlc", fileDirPath, reportName);

            // file encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");
            //LocalReport report = new LocalReport(rdclFilePath);

            LocalReport report = new LocalReport();
            report.ReportPath = rdclFilePath;

            // prepare data for report

            if (reportName == "OpeningStockReport")
            {
                List<StrOpeningStockGetVM> OpenStock = Search(searchModel);
                //report.AddDataSource("OpeningStockReport", strItems);
                report.DataSources.Add(new ReportDataSource() { Name = "OpeningStock", Value = OpenStock });
            }
            else if (reportName == "OpeningStockDetailsReport")
            {
                List<StrOpeningStockDetailsGetVM> details = _StrOpeningStockDetailsRepository.Search(searchModel);
                //report.AddDataSource("OpeningStockDetails", details);
                report.DataSources.Add(new ReportDataSource() { Name = "OpeningStockDetails", Value = details });
            }
            else if (reportName == "OpeningStockCommodityStockReport")
            {
                List<StrStockTakingDetailsSumByStore> openStockItemsGeneral = _StrOpeningStockDetailsRepository.OpenStockCommodityStock(searchModel);
                //report.AddDataSource("StockQtyTotal", openStockItemsGeneral);
                report.DataSources.Add(new ReportDataSource() { Name = "StockQtyTotal", Value = openStockItemsGeneral });
            }
            else if (reportName == "OpeningStockInvestComponentReport")
            {
                List<StrStockTakingDetailsSumByStore> openStockItemsGeneral = _StrOpeningStockDetailsRepository.OpenStockInvestComponent(searchModel);
                //report.AddDataSource("StockQtyTotal", openStockItemsGeneral);
                report.DataSources.Add(new ReportDataSource() { Name = "StockQtyTotal", Value = openStockItemsGeneral });
            }
            else if (reportName == "StockTakingCommodityStockReport")
            {
                List<StrStockTakingDetailsSumByStore> openStockItemsGeneral = new List<StrStockTakingDetailsSumByStore>();
                List<StrStockTakingDetailsSumByStore> beforeFilterOpenStockItemsGeneral = _StrOpeningStockDetailsRepository.OpenStockCommodityStock(searchModel);
                decimal SumTotal = 0, addAndWithdrawQty, ItemTotal, addAndWithdrawTotal;
                for (int i = 0; i < beforeFilterOpenStockItemsGeneral.Count; i++)
                {
                    beforeFilterOpenStockItemsGeneral[i].SumTotal = 0;
                    beforeFilterOpenStockItemsGeneral[i].StartDate = ((DateTime)searchModel.StartDate.Value).ToString("dd/MM/yyyy");
                    beforeFilterOpenStockItemsGeneral[i].EndDate = ((DateTime)searchModel.EndDate.Value).ToString("dd/MM/yyyy");
                    addAndWithdrawQty = _StrOpeningStockDetailsRepository.GetItemQtyAddAndWithdraw(beforeFilterOpenStockItemsGeneral[i].StoreId, beforeFilterOpenStockItemsGeneral[i].FiscalYearId, (DateTime)searchModel.StartDate.Value, (DateTime)searchModel.EndDate.Value, beforeFilterOpenStockItemsGeneral[i].ItemId);
                    beforeFilterOpenStockItemsGeneral[i].Qty = beforeFilterOpenStockItemsGeneral[i].Qty + addAndWithdrawQty;
                    addAndWithdrawTotal = _StrOpeningStockDetailsRepository.GetItemTotalAddAndWithdraw(beforeFilterOpenStockItemsGeneral[i].StoreId, beforeFilterOpenStockItemsGeneral[i].FiscalYearId, (DateTime)searchModel.StartDate.Value, (DateTime)searchModel.EndDate.Value, beforeFilterOpenStockItemsGeneral[i].ItemId);
                    ItemTotal = beforeFilterOpenStockItemsGeneral[i].Total + addAndWithdrawTotal;
                    beforeFilterOpenStockItemsGeneral[i].Total = ItemTotal;
                    SumTotal += ItemTotal;
                    openStockItemsGeneral.Add(beforeFilterOpenStockItemsGeneral[i]);
                }
                for (int i = 0; i < openStockItemsGeneral.Count; i++)
                {
                    openStockItemsGeneral[i].SumTotal = SumTotal;
                }
                //report.AddDataSource("StockQtyTotal", openStockItemsGeneral);
                report.DataSources.Add(new ReportDataSource() { Name = "StockQtyTotal", Value = openStockItemsGeneral });
            }
            else if (reportName == "StockTakingInvestComponentReport")
            {
                List<StrStockTakingDetailsSumByStore> openStockItemsGeneral = new List<StrStockTakingDetailsSumByStore>();
                List<StrStockTakingDetailsSumByStore> beforeFilterOpenStockItemsGeneral = _StrOpeningStockDetailsRepository.OpenStockInvestComponent(searchModel);
                decimal SumTotal = 0, addAndWithdrawQty, ItemTotal, addAndWithdrawTotal;
                for (int i = 0; i < beforeFilterOpenStockItemsGeneral.Count; i++)
                {
                    beforeFilterOpenStockItemsGeneral[i].SumTotal = 0;
                    beforeFilterOpenStockItemsGeneral[i].StartDate = ((DateTime)searchModel.StartDate).ToString("dd/MM/yyyy");
                    beforeFilterOpenStockItemsGeneral[i].EndDate = ((DateTime)searchModel.EndDate).ToString("dd/MM/yyyy");
                    addAndWithdrawQty = _StrOpeningStockDetailsRepository.GetItemQtyAddAndWithdraw(beforeFilterOpenStockItemsGeneral[i].StoreId, beforeFilterOpenStockItemsGeneral[i].FiscalYearId, (DateTime)searchModel.StartDate.Value, (DateTime)searchModel.EndDate.Value, beforeFilterOpenStockItemsGeneral[i].ItemId);
                    beforeFilterOpenStockItemsGeneral[i].Qty = beforeFilterOpenStockItemsGeneral[i].Qty + addAndWithdrawQty;
                    addAndWithdrawTotal = _StrOpeningStockDetailsRepository.GetItemTotalAddAndWithdraw(beforeFilterOpenStockItemsGeneral[i].StoreId, beforeFilterOpenStockItemsGeneral[i].FiscalYearId, (DateTime)searchModel.StartDate.Value, (DateTime)searchModel.EndDate.Value, beforeFilterOpenStockItemsGeneral[i].ItemId);
                    ItemTotal = beforeFilterOpenStockItemsGeneral[i].Total + addAndWithdrawTotal;
                    beforeFilterOpenStockItemsGeneral[i].Total = ItemTotal;
                    SumTotal += ItemTotal;
                    openStockItemsGeneral.Add(beforeFilterOpenStockItemsGeneral[i]);
                }
                for (int i = 0; i < openStockItemsGeneral.Count; i++)
                {
                    openStockItemsGeneral[i].SumTotal = SumTotal;
                }
                //report.AddDataSource("StockQtyTotal", openStockItemsGeneral);
                report.DataSources.Add(new ReportDataSource() { Name = "StockQtyTotal", Value = openStockItemsGeneral });
            }

            //var result = report.Execute(Entities.Helpers.ReportHelper.GetRenderType(reportType));

            //return result.MainStream;

            byte[] renderedBytes = report.Render(reportType);
            return renderedBytes;
        }


    }
}
