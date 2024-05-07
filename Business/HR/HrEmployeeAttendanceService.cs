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
    public class HrEmployeeAttendanceService
    {
        public HrEmployeeAttendanceRepository _HrEmployeeAttendanceRepository;
        public HrEmployeeAttendanceService(HrEmployeeAttendanceRepository HrEmployeeAttendanceRepository)
        {
            _HrEmployeeAttendanceRepository = HrEmployeeAttendanceRepository;
        }
        public string Add(HrEmployeeAttendanceVM ID)
        {
            return _HrEmployeeAttendanceRepository.Add(ID);
        }

        public string Update(HrEmployeeAttendanceVM ID)
        {
            return _HrEmployeeAttendanceRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrEmployeeAttendanceRepository.Delete(ID);
        }
        public List<HrEmployeeAttendanceGetVM> GetAll()
        {
            return _HrEmployeeAttendanceRepository.GetAll();
        }
        public HrEmployeeAttendanceGetVM GetById(int ID)
        {
            return _HrEmployeeAttendanceRepository.GetById(ID);
        }
        public List<HrEmployeeAttendanceGetSearchVM> Search(HrEmployeeAttendanceSearch searchModel)
        {
            return _HrEmployeeAttendanceRepository.Search(searchModel);
        }
        public byte[] GenerateReportAsync(string reportName, string reportType, HrEmployeeAttendanceSearch searchModel)
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

            List<HrEmployeeAttendanceGetSearchVM> HrEmployeeAttend;


            if (reportName == "EmployeeAttendanceReport")
            {
                HrEmployeeAttend = Search(searchModel);

                report.DataSources.Add(new ReportDataSource() { Name = "HrEmployeeAttendance", Value = HrEmployeeAttend });
            }

            // Dictionary<string, string> parameters = new Dictionary<string, string>();

            // var result = report.Execute(Entities.Helpers.ReportHelper.GetRenderType(reportType), 1, parameters);
            byte[] renderedBytes = report.Render(reportType);

            return renderedBytes;
        }

    }
}
