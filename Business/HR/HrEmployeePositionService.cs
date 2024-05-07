using DAL;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Business.HR
{
    public class HrEmployeePositionService
    {
        public HrEmployeePositionRepository _HrEmployeePositionRepository;
        public HrEmployeePositionService(HrEmployeePositionRepository HrEmployeePositionRepository)
        {
            _HrEmployeePositionRepository = HrEmployeePositionRepository;
        }
        public string Add(HrEmployeePositionVM EmployeePosition)
        {
            return _HrEmployeePositionRepository.Add(EmployeePosition);
        }

        public string Update(HrEmployeePositionVM EmployeePosition)
        {
            return _HrEmployeePositionRepository.Update(EmployeePosition);
        }

        public string Delete(int EmployeePositionId)
        {
            return _HrEmployeePositionRepository.Delete(EmployeePositionId);
        }
        public List<HrEmployeePositionGetVM> GetAll()
        {
            return _HrEmployeePositionRepository.GetAll();
        }
        public HrEmployeePositionGetVM GetById(int EmployeePositionId)
        {
            return _HrEmployeePositionRepository.GetById(EmployeePositionId);
        }
        public List<HrEmployeePositionGetSearchVM> Search(HrEmployeePositionSearch searchModel)
        {
            return _HrEmployeePositionRepository.Search(searchModel);
        }
        public byte[] GenerateReportAsync(string reportName, string reportType, HrEmployeePositionSearch searchModel)
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

            List<HrEmployeePositionGetSearchVM> HrEmployeePosition;

            if (reportName == "EmpPositionReport")
            {
                HrEmployeePosition = Search(searchModel);
                report.DataSources.Add(new ReportDataSource() { Name = "HrEmpPosition", Value = HrEmployeePosition });
            }

            //Dictionary<string, string> parameters = new Dictionary<string, string>();

            //  var result = report.Execute(Entities.Helpers.ReportHelper.GetRenderType(reportType), 1, parameters);
            byte[] renderedBytes = report.Render(reportType);

            return renderedBytes;
        }

    }
}
