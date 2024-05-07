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
    public class HrEmployeeAttendanceScheduleService
    {
        public HrEmployeeAttendanceScheduleRepository _HrEmployeeAttendanceScheduleRepository;
        public HrEmployeeAttendanceScheduleService(HrEmployeeAttendanceScheduleRepository HrEmployeeAttendanceScheduleRepository)
        {
            _HrEmployeeAttendanceScheduleRepository = HrEmployeeAttendanceScheduleRepository;
        }
        public string Add(HrEmployeeAttendanceScheduleVM ID)
        {
            return _HrEmployeeAttendanceScheduleRepository.Add(ID);
        }

        public string Update(HrEmployeeAttendanceScheduleVM ID)
        {
            return _HrEmployeeAttendanceScheduleRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrEmployeeAttendanceScheduleRepository.Delete(ID);
        }
        public List<HrEmployeeAttendanceScheduleGetVM> GetAll()
        {
            return _HrEmployeeAttendanceScheduleRepository.GetAll();
        }
        public HrEmployeeAttendanceScheduleGetVM GetById(int ID)
        {
            return _HrEmployeeAttendanceScheduleRepository.GetById(ID);
        }
        public List<HrEmployeeAttendanceScheduleGetVM> Search(HrEmpAttendScheduleSearch searchModel)
        {
            return _HrEmployeeAttendanceScheduleRepository.Search(searchModel);
        }
        public byte[] GenerateReportAsync(string reportName, string reportType, HrEmpAttendScheduleSearch searchModel)
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

            List<HrEmployeeAttendanceScheduleGetVM> HrEmployeeAttendPermission;


            if (reportName == "EmpAttendScheduleReport")
            {
                HrEmployeeAttendPermission = Search(searchModel);

                report.DataSources.Add(new ReportDataSource() { Name = "HrEmpAttendSchedule", Value = HrEmployeeAttendPermission });
            }

            // Dictionary<string, string> parameters = new Dictionary<string, string>();

            // var result = report.Execute(Entities.Helpers.ReportHelper.GetRenderType(reportType), 1, parameters);
            byte[] renderedBytes = report.Render(reportType);

            return renderedBytes;
        }

    }
}
