using DAL;
using DAL.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Entities.ViewModels;
using Microsoft.Reporting.NETCore;
using System.Threading.Tasks;

namespace Business.STR.Employee
{
    public class StrEmployeeOpeningCustodyService
    {
        public StrEmployeeOpeningCustodyRepository _StrEmployeeOpeningCustodyService;
        public StrEmployeeOpeningCustodyDetailsRepository _StrEmployeeOpeningCustodyDetailsRepository;
        public StrEmployeeOpeningCustodyService
            (StrEmployeeOpeningCustodyRepository StrEmployeeOpeningCustodyRepository,
            StrEmployeeOpeningCustodyDetailsRepository StrEmployeeOpeningCustodyDetailsRepository)
        {
            _StrEmployeeOpeningCustodyService = StrEmployeeOpeningCustodyRepository;
            _StrEmployeeOpeningCustodyDetailsRepository = StrEmployeeOpeningCustodyDetailsRepository;
        }
        public int AutoNo()
        {
            return _StrEmployeeOpeningCustodyService.GetLastNo();
        }
        public async Task<string> Add(StrEmployeeOpeningCustodyVM STR_Employee_Opening_Custody)
        {
            return  await _StrEmployeeOpeningCustodyService.Add(STR_Employee_Opening_Custody);
        }
        public async Task<string> Update(StrEmployeeOpeningCustodyVM STR_Employee_Opening_Custody)
        {
            return await _StrEmployeeOpeningCustodyService.Update(STR_Employee_Opening_Custody);
        }
        public string Delete(int itemId)
        {
            return _StrEmployeeOpeningCustodyService.Delete(itemId);
        }
        public List<StrEmployeeOpeningCustodyGetVM> GetAll()
        {
            return _StrEmployeeOpeningCustodyService.GetAll();
        }
        public StrEmployeeOpeningCustodyGetVM GetById(int itemId)
        {
            return _StrEmployeeOpeningCustodyService.GetById(itemId);
        }
        public List<StrEmployeeOpeningCustodyGetVM> search(searchemployeeopeningcustody searchModel)
        {
            return _StrEmployeeOpeningCustodyService.search(searchModel);
        }
        public PaginatedResult<StrEmployeeOpeningCustodyGetVM> GetAllByPagination(int page, int pageSize, int fiscalYearId)
        {
            return _StrEmployeeOpeningCustodyService.GetAllByPagination(page, pageSize, fiscalYearId);
        }

        public byte[] GenerateReportAsync(string reportName, string reportType, reportemployeeopeningcustody searchModel)
        {
            // get report file

            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Business.dll", string.Empty);
            //Console.WriteLine(string.Format("{0}ReportsFiles\\OpeningStockReport.rdlc", fileDirPath, reportName));
            string rdclFilePath = string.Format("{0}ReportsFiles\\Store\\{1}.rdlc", fileDirPath, reportName);

            // file encoding

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            //LocalReport report = new LocalReport(rdclFilePath);
            LocalReport report = new LocalReport();
            report.ReportPath = rdclFilePath;

            // prepare data for report

            if (reportName == "EmployeeOpeningReport")
            {
                List<StrEmployeeOpeningCustodyGetVM> EmployeeOpening = search(searchModel);
                //report.AddDataSource("EmployeeOpening", strItems);
                report.DataSources.Add(new ReportDataSource() { Name = "EmployeeOpening", Value = EmployeeOpening });
            }
            else
            {
                List<StrEmployeeOpeningCustodyDetailsGetVM> details = _StrEmployeeOpeningCustodyDetailsRepository.search(searchModel);
                //report.AddDataSource("EmployeeOpeningCustodyDetails", details);
                report.DataSources.Add(new ReportDataSource() { Name = "EmployeeOpeningCustodyDetails", Value = details });
            }
            //Dictionary<string, string> parameters = new Dictionary<string, string>();

            //var result = report.Execute(Entities.Helpers.ReportHelper.GetRenderType(reportType));

            //return result.MainStream;

            byte[] renderedBytes = report.Render(reportType);
            return renderedBytes;
        }


    }
}
