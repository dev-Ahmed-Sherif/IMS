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
    public class HrEmployeeAttendancePermissionService
    {
        public HrEmployeeAttendancePermissionRepository _HrEmployeeAttendancePermissionRepository;
        public HrEmployeeAttendancePermissionService(HrEmployeeAttendancePermissionRepository HrEmployeeAttendancePermissionRepository)
        {
            _HrEmployeeAttendancePermissionRepository = HrEmployeeAttendancePermissionRepository;
        }
        public string Add(HrEmployeeAttendancePermissionVM ID)
        {
            return _HrEmployeeAttendancePermissionRepository.Add(ID);
        }

        public string Update(HrEmployeeAttendancePermissionVM ID)
        {
            return _HrEmployeeAttendancePermissionRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrEmployeeAttendancePermissionRepository.Delete(ID);
        }
        public List<HrEmployeeAttendancePermissionGetVM> GetAll()
        {
            return _HrEmployeeAttendancePermissionRepository.GetAll();
        }
        public HrEmployeeAttendancePermissionGetVM GetById(int ID)
        {
            return _HrEmployeeAttendancePermissionRepository.GetById(ID);
        }
        public List<HrEmployeeAttendancePermissionGetSearch> Search(HrEmployeeAttendancePermissionSearch searchModel)
        {
            return _HrEmployeeAttendancePermissionRepository.Search(searchModel);
        }
        public byte[] GenerateReportAsync(string reportName, string reportType, HrEmployeeAttendancePermissionSearch searchModel)
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

            List<HrEmployeeAttendancePermissionGetSearch> HrEmployeeAttendPermission;


            if (reportName == "EmpAttendPermissionReport")
            {
                HrEmployeeAttendPermission = Search(searchModel);

                report.DataSources.Add(new ReportDataSource() { Name = "HrEmpAttendPermission", Value = HrEmployeeAttendPermission });
            }

            // Dictionary<string, string> parameters = new Dictionary<string, string>();

            // var result = report.Execute(Entities.Helpers.ReportHelper.GetRenderType(reportType), 1, parameters);
            byte[] renderedBytes = report.Render(reportType);

            return renderedBytes;
        }

    }
}
