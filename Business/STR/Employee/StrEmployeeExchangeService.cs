using DAL;
using DAL.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Entities.ViewModels;
using Microsoft.Reporting.NETCore;
using System.Threading.Tasks;

namespace Business.STR.Employee
{
    public class StrEmployeeExchangeService
    {
        public StrEmployeeExchangeRepository _StrEmployeeExchangeRepository;
        public StrEmployeeExchangeDetailsRepository _StrEmployeeExchangeDetailsRepository;
        public StrEmployeeExchangeService
            (StrEmployeeExchangeRepository StrEmployeeExchangeRepository,
            StrEmployeeExchangeDetailsRepository StrEmployeeExchangeDetailsRepository)
        {
            _StrEmployeeExchangeRepository = StrEmployeeExchangeRepository;
            _StrEmployeeExchangeDetailsRepository = StrEmployeeExchangeDetailsRepository;
        }
        public int AutoNo()
        {
            return _StrEmployeeExchangeRepository.GetLastNo();
        }
        public async Task<string> Add(StrEmployeeExchangeGeneralVM exch)
        {
            return await _StrEmployeeExchangeRepository.Add(exch);
        }
        public async Task<string> Update(StrEmployeeExchangeVM exch)
        {
            return await _StrEmployeeExchangeRepository.Update(exch);
        }
        public string Delete(int Id)
        {
            return _StrEmployeeExchangeRepository.Delete(Id);
        }
        public List<StrEmployeeExchangeGetVM> GetAll()
        {
            return _StrEmployeeExchangeRepository.GetAll();
        }
        public PaginatedResult<StrEmployeeExchangeGetVM> GetAllByPagination(int page, int pageSize, int fiscalYearId)
        {
            return _StrEmployeeExchangeRepository.GetAllByPagination(page, pageSize, fiscalYearId);
        }
        public StrEmployeeExchangeVM GetById(int exchId)
        {
            return _StrEmployeeExchangeRepository.GetById(exchId);
        }
        public List<StrEmployeeExchangeGetVM> search(searchemployeeexchange searchModel)
        {
            return _StrEmployeeExchangeRepository.search(searchModel);
        }
        // Generate report

        public byte[] GenerateReportAsync(string reportName, string reportType, searchemployeeexchange searchModel)
        {
            // get report file

            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Business.dll", string.Empty);
            Console.WriteLine(string.Format("{0}ReportsFiles\\{1}.rdlc", fileDirPath, reportName));
            string rdclFilePath = string.Format("{0}ReportsFiles\\Store\\{1}.rdlc", fileDirPath, reportName);

            // file encoding

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            //LocalReport report = new LocalReport(rdclFilePath);

            LocalReport report = new LocalReport();
            report.ReportPath = rdclFilePath;

            // prepare data for report

            if (reportName == "EmployeeExchangeReport")
            {
                List<StrEmployeeExchangeGetVM> StrEmployeeExchange = search(searchModel);
                //report.AddDataSource("EmployeeExchange", StrEmployeeExchange);
                report.DataSources.Add(new ReportDataSource() { Name = "EmployeeExchange", Value = StrEmployeeExchange });
            }
            else
            {
                List<StrEmployeeExchangeDetailsGetVM> StrEmployeeExchangeDetails = _StrEmployeeExchangeDetailsRepository.search(searchModel);
                //report.AddDataSource("EmployeeExchangeDetails", StrEmployeeExchangeDetails);
                report.DataSources.Add(new ReportDataSource() { Name = "EmployeeExchangeDetails", Value = StrEmployeeExchangeDetails });
            }
            //Dictionary<string, string> parameters = new Dictionary<string, string>();

            //var result = report.Execute(Entities.Helpers.ReportHelper.GetRenderType(reportType));

            //return result.MainStream;

            byte[] renderedBytes = report.Render(reportType);
            return renderedBytes;
        }


    }
}
