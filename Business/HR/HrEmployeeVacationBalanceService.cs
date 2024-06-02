using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


namespace Business.HR
{
    public class HrEmployeeVacationBalanceService
    {
        public HrEmployeeVacationBalanceRepository _HrEmployeeVacationBalanceRepository;
        public HrEmployeeVacationBalanceService(HrEmployeeVacationBalanceRepository HrEmployeeVacationBalanceRepository)
        {
            _HrEmployeeVacationBalanceRepository = HrEmployeeVacationBalanceRepository;
        }
        public string Add(HrEmployeeVacationBalanceVM EmployeeVacationBalance)
        {
            return _HrEmployeeVacationBalanceRepository.Add(EmployeeVacationBalance);
        }

        public string Update(HrEmployeeVacationBalanceVM EmployeeVacationBalance)
        {
            return _HrEmployeeVacationBalanceRepository.Update(EmployeeVacationBalance);
        }

        public string Delete(int EmployeeVacationBalanceId)
        {
            return _HrEmployeeVacationBalanceRepository.Delete(EmployeeVacationBalanceId);
        }
        public List<HrEmployeeVacationBalanceGetVM> GetAll()
        {
            return _HrEmployeeVacationBalanceRepository.GetAll();
        }
        public HrEmployeeVacationBalanceGetVM GetById(int EmployeeVacationBalanceId)
        {
            return _HrEmployeeVacationBalanceRepository.GetById(EmployeeVacationBalanceId);
        }
        public List<HrEmployeeVacationBalanceGetVM> Search(HrEmployeeVacationBalanceSearch searchModel)
        {
            return _HrEmployeeVacationBalanceRepository.Search(searchModel);
        }



        public byte[] GenerateReportAsync(string reportName, string reportType, HrEmployeeVacationBalanceSearch searchModel)
        {
            // get report file

            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Business.dll", string.Empty);
            Console.WriteLine(string.Format("{0}ReportsFiles\\{1}.rdlc", fileDirPath, reportName));
            string rdclFilePath = string.Format("{0}ReportsFiles\\HR\\{1}.rdlc", fileDirPath, reportName);

            // file encoding

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            LocalReport report = new()
            {
                ReportPath = rdclFilePath
            };
            // prepare data for report

            List<HrEmployeeVacationBalanceGetVM> HrEmployeeVacationBalance;


            if (reportName == "EmployeeVacationBalanceReport")
            {

                HrEmployeeVacationBalance = Search(searchModel);

                report.DataSources.Add(new ReportDataSource() { Name = "EmployeeVacationBalance", Value = HrEmployeeVacationBalance });
            }
            //else if (reportName == "FIEntryDetailsReport")
            //{

            //    //FiEntryDetails = _Details.Search(searchModel);
            //    //report.AddDataSource("FIEntryDetails", FiEntryDetails);
            //}

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            byte[] renderedBytes = report.Render(reportType);

            return renderedBytes;
        }
    }
}
