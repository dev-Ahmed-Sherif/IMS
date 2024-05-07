using DAL;
using DAL.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.NETCore;
//using Microsoft.Reporting.WebForms;
//using Microsoft.Reporting.NETCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Entities.ViewModels;
using System.Threading.Tasks;

namespace Business.STR.StoreOpen
{
    public class StrStockTakingService
    {
        public StrStockTakingRepository _StrStockTakingRepository;
        public StrStockTakingDetailsRepository _StrStockTakingDetailsRepository;
        public StrOpeningStockDetailsRepository _StrOpeningStockDetailsRepository;
        public StrStockTakingService
            (StrStockTakingRepository StrStockTakingRepository,
            StrStockTakingDetailsRepository StrStockTakingDetailsRepository,
            StrOpeningStockDetailsRepository StrOpeningStockDetailsRepository)
        {
            _StrStockTakingRepository = StrStockTakingRepository;
            _StrStockTakingDetailsRepository = StrStockTakingDetailsRepository;
            _StrOpeningStockDetailsRepository = StrOpeningStockDetailsRepository;
        }
        public async Task<string> Add(StrStockTakingVM StockTaking)
        {
            return await _StrStockTakingRepository.Add(StockTaking);
        }

        public async Task<string> Update(StrStockTakingVM StockTaking)
        {
            return await _StrStockTakingRepository.Update(StockTaking);
        }

        public string Delete(int StockTakingId)
        {
            return _StrStockTakingRepository.Delete(StockTakingId);
        }

        public List<StrStockTakingGetVM> GetAll()
        {
            return _StrStockTakingRepository.GetAll();
        }
        public PaginatedResult<StrStockTakingGetVM> GetPaginated(int fiscalYearId, int pageIndex, int pageSize)
        {
            return _StrStockTakingRepository.GetPaginated(fiscalYearId, pageIndex, pageSize);
        }
        public StrStockTakingGetVM GetById(int StockTakingId)
        {
            return _StrStockTakingRepository.GetById(StockTakingId);
        }

        public List<StrStockTakingGetVM> Search(Search searchModel)
        {
            return _StrStockTakingRepository.Search(searchModel);
        }

        public List<StrStoreTaking> StoreTakingCommodityStock(Search searchModel)
        {
            List<StrStoreTaking> BeforeFilterStoreTaking;
            List<StrStoreTaking> StoreTaking = new List<StrStoreTaking>();
            BeforeFilterStoreTaking = _StrStockTakingRepository.StoreTakingCommodityStock(searchModel);
            for (int i = 0; i < BeforeFilterStoreTaking.Count; i++)
            {
                // Calc System Qty , Total For Taking Store
                BeforeFilterStoreTaking[i].ItemQty = BeforeFilterStoreTaking[i].ItemQty + _StrOpeningStockDetailsRepository.GetItemQtyAddAndWithdraw((int)searchModel.StoreId.Value, BeforeFilterStoreTaking[i].FiscalYearId, null, null, BeforeFilterStoreTaking[i].ItemId);
                BeforeFilterStoreTaking[i].Total = BeforeFilterStoreTaking[i].Total + _StrOpeningStockDetailsRepository.GetItemTotalAddAndWithdraw((int)searchModel.StoreId.Value, BeforeFilterStoreTaking[i].FiscalYearId, null, null, BeforeFilterStoreTaking[i].ItemId);
                StoreTaking.Add(BeforeFilterStoreTaking[i]);
            }
            return StoreTaking;
        }

        public List<StrStoreTaking> StoreTakingInvestComp(Search searchModel)
        {
            List<StrStoreTaking> BeforeFilterStoreTaking;
            List<StrStoreTaking> StoreTaking = new List<StrStoreTaking>();
            BeforeFilterStoreTaking = _StrStockTakingRepository.StoreTakingInvestComp(searchModel);
            for (int i = 0; i < BeforeFilterStoreTaking.Count; i++)
            {
                // Calc System Qty , Total For Taking Store
                BeforeFilterStoreTaking[i].ItemQty = BeforeFilterStoreTaking[i].ItemQty + _StrOpeningStockDetailsRepository.GetItemQtyAddAndWithdraw((int)searchModel.StoreId.Value, BeforeFilterStoreTaking[i].FiscalYearId, null, null, BeforeFilterStoreTaking[i].ItemId);
                BeforeFilterStoreTaking[i].Total = BeforeFilterStoreTaking[i].Total + _StrOpeningStockDetailsRepository.GetItemTotalAddAndWithdraw((int)searchModel.StoreId.Value, BeforeFilterStoreTaking[i].FiscalYearId, null, null, BeforeFilterStoreTaking[i].ItemId);
                StoreTaking.Add(BeforeFilterStoreTaking[i]);
            }
            return StoreTaking;
        }
        public List<StrStoreTaking> StoreBeforeTaking(Search searchModel)
        {
            List<StrStoreTaking> BeforeFilterStoreTakingCom;
            List<StrStoreTaking> StoreTakingCom = new List<StrStoreTaking>();
            BeforeFilterStoreTakingCom = _StrStockTakingRepository.StoreTakingCommodityStock(searchModel);
            for (int i = 0; i < BeforeFilterStoreTakingCom.Count; i++)
            {
                // Calc System Qty , Total For Taking Store
                BeforeFilterStoreTakingCom[i].ItemQty = BeforeFilterStoreTakingCom[i].ItemQty + _StrOpeningStockDetailsRepository.GetItemQtyAddAndWithdraw((int)searchModel.StoreId.Value, BeforeFilterStoreTakingCom[i].FiscalYearId, null, null, BeforeFilterStoreTakingCom[i].ItemId);
                BeforeFilterStoreTakingCom[i].Total = BeforeFilterStoreTakingCom[i].Total + _StrOpeningStockDetailsRepository.GetItemTotalAddAndWithdraw((int)searchModel.StoreId.Value, BeforeFilterStoreTakingCom[i].FiscalYearId, null, null, BeforeFilterStoreTakingCom[i].ItemId);
                StoreTakingCom.Add(BeforeFilterStoreTakingCom[i]);
            }

            List<StrStoreTaking> BeforeFilterStoreTakingInvest;
            List<StrStoreTaking> StoreTakingInvest = new List<StrStoreTaking>();
            BeforeFilterStoreTakingInvest = _StrStockTakingRepository.StoreTakingInvestComp(searchModel);
            for (int i = 0; i < BeforeFilterStoreTakingInvest.Count; i++)
            {
                // Calc System Qty , Total For Taking Store
                BeforeFilterStoreTakingInvest[i].ItemQty = BeforeFilterStoreTakingCom[i].ItemQty + _StrOpeningStockDetailsRepository.GetItemQtyAddAndWithdraw((int)searchModel.StoreId.Value, BeforeFilterStoreTakingCom[i].FiscalYearId, null, null, BeforeFilterStoreTakingInvest[i].ItemId);
                BeforeFilterStoreTakingInvest[i].Total = BeforeFilterStoreTakingCom[i].Total + _StrOpeningStockDetailsRepository.GetItemTotalAddAndWithdraw((int)searchModel.StoreId.Value, BeforeFilterStoreTakingCom[i].FiscalYearId, null, null, BeforeFilterStoreTakingInvest[i].ItemId);
                StoreTakingInvest.Add(BeforeFilterStoreTakingInvest[i]);
            }

            var result = StoreTakingCom.Union(StoreTakingInvest);
            return result.ToList();
        }
        // Generate report
        public byte[] GenerateReportAsync(string reportName, string reportType, Search searchModel)
        {
            // get report file

            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Business.dll", string.Empty);

            string rdclFilePath = string.Format("{0}ReportsFiles\\Stock\\{1}.rdlc", fileDirPath, reportName);

            // file encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");
            LocalReport report = new LocalReport();
            report.ReportPath = rdclFilePath;
            //ServerReport serverReport = new ServerReport();
            using var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream(rdclFilePath);
            //report.LoadReportDefinition(rs);
            List<StrStockTakingGetVM> StockTaking;
            List<StrStockTakingDetailsGetVM> stockTakingDetails;
            List<StrStoreTaking> StoreTaking;
            //string[] parameters = { };
            switch (reportName)
            {
                case "StockTakingReport":
                    StockTaking = Search(searchModel);
                    report.DataSources.Add(new ReportDataSource() { Name = "StockTaking", Value = StockTaking });
                    //report.DataSources.Add(Repor);
                    //report.AddDataSource("StockTaking", StockTaking);
                    //parameters = new string[] { rdclFilePath, JsonConvert.SerializeObject(StockTaking), "StockTaking", reportType };
                    break;
                case "StockTakingDetailsReport":
                    stockTakingDetails = _StrStockTakingDetailsRepository.Search(searchModel);
                    //report.DataSources.Add("StockTakingDetails", stockTakingDetails);
                    report.DataSources.Add(new ReportDataSource() { Name = "StockTakingDetails", Value = stockTakingDetails });
                    //report.AddDataSource("StockTakingDetails", stockTakingDetails);
                    break;
                case "StoreTakingComStockReport":
                    StoreTaking = StoreTakingCommodityStock(searchModel);
                    //parameters = new string[] { rdclFilePath, JsonConvert.SerializeObject(StoreTaking), "StrStoreTaking", reportType };
                    report.DataSources.Add(new ReportDataSource() { Name = "StrStoreTaking", Value = StoreTaking });
                    //report.AddDataSource("StrStoreTaking", StoreTaking);
                    break;
                case "StoreTakingInvestComReport":
                    StoreTaking = StoreTakingInvestComp(searchModel);
                    //parameters = new string[] { rdclFilePath, JsonConvert.SerializeObject(StoreTaking), "StrStoreTaking", reportType };
                    report.DataSources.Add(new ReportDataSource() { Name = "StrStoreTaking", Value = StoreTaking });
                    //report.AddDataSource("StrStoreTaking", StoreTaking);
                    break;
                case "StoreBeforeTakingReport":
                    StoreTaking = StoreBeforeTaking(searchModel);
                    //parameters = new string[] { rdclFilePath, JsonConvert.SerializeObject(StoreTaking), "StrStoreTaking", reportType };
                    report.DataSources.Add(new ReportDataSource() { Name = "StrStoreTaking", Value = StoreTaking });
                    //report.AddDataSource("StrStoreTaking", StoreTaking);
                    break;
                case "StoreAfterTakingReport":
                    stockTakingDetails = _StrStockTakingDetailsRepository.GetByHeader((int)searchModel.Id);
                    //parameters = new string[] { rdclFilePath, JsonConvert.SerializeObject(stockTakingDetails), "StockTakingDetails", reportType };
                    report.DataSources.Add(new ReportDataSource() { Name = "StockTakingDetails", Value = stockTakingDetails });
                    //report.AddDataSource("StockTakingDetails", stockTakingDetails);
                    break;
            }
            // prepare data for report

            //Dictionary<string, string> parameters = new Dictionary<string, string>();

            //var result = report.Render(Entities.Helpers.ReportHelper.GetRenderType(reportType).ToString());
            //var result = Report.Program.ReadBytes(JsonConvert.SerializeObject(report), reportType);
            //var baseDirectory = Directory.GetCurrentDirectory();
            //var processName = Path.Combine(baseDirectory, "wwwroot", "ReportHandler", "Report.exe");
            //StringBuilder strBuilder = new();

            //ProcessStartInfo startInfo = new()
            //{
            //    FileName = processName,
            //    //Arguments = JsonConvert.SerializeObject(parameters),
            //    Arguments = JsonConvert.SerializeObject(parameters),
            //    UseShellExecute = false,
            //    RedirectStandardOutput = true,
            //    CreateNoWindow = false // Set to true to hide the console window
            //};

            //using Process process = Process.Start(startInfo);
            //if (process != null)
            //{
            //    // You can optionally read the output of the console app
            //    strBuilder.Append(process.StandardOutput.ReadToEnd());
            //    Console.WriteLine(strBuilder);
            //    // Wait for the process to exit
            //    process.WaitForExit();
            //    //process.Kill();
            //}
            //else
            //{
            //    Console.WriteLine("Failed to start the process.");
            //}

            //var result = report.Execute(Entities.Helpers.ReportHelper.GetRenderType(reportType));
            //var result = report.Render(Entities.Helpers.ReportHelper.GetRenderType(reportType).ToString());
            //return result.MainStream;;
            byte[] renderedBytes = report.Render(reportType);
            return renderedBytes;

        }
    }
}
