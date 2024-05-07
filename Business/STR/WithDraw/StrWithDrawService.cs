using DAL;
using DAL.STR.WithDraw;
using Entities.ViewModels;
using Entities.ViewModels.STR.StoreOpen;
using Entities.ViewModels.STR.WithDraw;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.NETCore;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.STR.WithDraw
{
    public class StrWithDrawService
    {
        public StrWithDrawRepository _StrWithDrawRepository;
        public StrWithDrawDetailsRepository _StrWithDrawDetailsRepository;
        public StrWithDrawService
            (StrWithDrawRepository StrWithDrawRepository,
            StrWithDrawDetailsRepository StrWithDrawDetailsRepository)
        {
            _StrWithDrawRepository = StrWithDrawRepository;
            _StrWithDrawDetailsRepository = StrWithDrawDetailsRepository;
        }
        public int AutoNo(int StoreId, int FiscalYearId)
        {
            return _StrWithDrawRepository.GetLastNo(StoreId, FiscalYearId);
        }
        public async Task<string> Add(StrWithdrawVM Type)
        {
            return await _StrWithDrawRepository.Add(Type);
        }
        public async Task<string> Update(StrWithdrawVM item)
        {
            return await _StrWithDrawRepository.Update(item);
        }
        public string Delete(int itemId)
        {
            return _StrWithDrawRepository.Delete(itemId);
        }
        public List<StrWithdrawGetVM> GetAll()
        {
            return _StrWithDrawRepository.GetAll(); ;
        }
        public StrWithdrawGetVM GetById(int itemId)
        {
            return _StrWithDrawRepository.GetById(itemId);
        }
        public List<StrWithdrawGetVM> Search(searchwithdraw searchModel)
        {
            return _StrWithDrawRepository.Search(searchModel);
        }
        public List<GetWithDrawDetailsByWithDrawDetailsId> GetByDestStore(int DestStoreId, int fiscalYearId)
        {
            return _StrWithDrawRepository.GetByDestStore(DestStoreId, fiscalYearId);
        }
        public PaginatedResult<StrWithdrawGetVM> GetByUserStores(int employeeId, int page, int pageSize, int fiscalYearId)
        {
            return _StrWithDrawRepository.GetByEmployeeStores(employeeId, page, pageSize, fiscalYearId);
        }
        // Generate report

        public byte[] GenerateReportAsync(string reportName, string reportType, searchwithdraw searchModel)
        {
            // get report file
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Business.dll", string.Empty);
            string rdclFilePath = string.Format("{0}ReportsFiles\\Store\\{1}.rdlc", fileDirPath, reportName);

            // file encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            //LocalReport report = new LocalReport(rdclFilePath);
            LocalReport report = new LocalReport
            {
                ReportPath = rdclFilePath
            };
            // prepare data for report
            List<StrWithdrawGetVM> StrWithdraw;
            List<StrWithDrawDetailsGetVM> StrWithDrawDetailsdraw;
            List<StrStockTakingDetailsSumByStore> WithdrawToCostCenter;
            if (reportName == "WithdrawReport")
            {
                StrWithdraw = Search(searchModel);
                //report.DataSources.Add(new ReportDataSource() { Name = "StrWithdraw", Value =  StrWithdraw});
                report.DataSources.Add(new ReportDataSource() { Name = "StrWithdraw", Value = StrWithdraw });
            }
            else if (reportName == "WithdrawDetailsReport")
            {
                StrWithDrawDetailsdraw = _StrWithDrawDetailsRepository.Search(searchModel);
                //report.DataSources.Add(new ReportDataSource() { Name = "WithdrawDetails", Value =  StrWithDrawDetailsdraw});
                report.DataSources.Add(new ReportDataSource() { Name = "WithdrawDetails", Value = StrWithDrawDetailsdraw });
            }
            else if (reportName == "WithdrawToCostCenterComMaterialReport")
            {
                if (searchModel.CommodityId == 1)
                {
                    WithdrawToCostCenter = _StrWithDrawDetailsRepository.WithdrawCommodityStock(searchModel);
                    report.DataSources.Add(new ReportDataSource() { Name = "WithdrawToCostCenter", Value =  WithdrawToCostCenter});
                }
            }
            else if (reportName == "WithdrawToCostCenterComAllReport")
            {
                WithdrawToCostCenter = _StrWithDrawDetailsRepository.WithdrawCommodityStock(searchModel);
                report.DataSources.Add(new ReportDataSource() { Name = "WithdrawToCostCenter", Value =  WithdrawToCostCenter});
            }
            else if (reportName == "WithdrawToCostCenterInvestReport")
            {
                WithdrawToCostCenter = _StrWithDrawDetailsRepository.WithdrawInvestComponent(searchModel);
                report.DataSources.Add(new ReportDataSource() { Name = "WithdrawToCostCenter", Value =  WithdrawToCostCenter});
            }

            byte[] renderedBytes = report.Render(reportType);
            return renderedBytes;
        }



    }
}
