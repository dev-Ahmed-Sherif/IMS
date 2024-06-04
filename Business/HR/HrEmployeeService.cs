using DAL;
using DAL.HR;
using Entities.ViewModels;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Business.HR
{
    public class HrEmployeeService
    {
        public HrEmployeeRepository _HrEmployeeRepository;
        public HrEmployeeService(HrEmployeeRepository HrEmployeeRepository)
        {
            _HrEmployeeRepository = HrEmployeeRepository;
        }
        public string Add(HrEmployeeVM employee)
        {
            return _HrEmployeeRepository.Add(employee);
        }

        public string Update(HrEmployeeVM employee)
        {
            return _HrEmployeeRepository.Update(employee);
        }

        public string Delete(int employeeId)
        {
            return _HrEmployeeRepository.Delete(employeeId);
        }
        public List<HrEmployeeGetVM> GetAll()
        {
            return _HrEmployeeRepository.GetAll();
        }
        //-----------------------------------------
        // Select pagnation FiEntry
        //------------------------------------------
        public PaginatedResult<HrEmployeeGetVM> GetPagination(int page, int pageSize)
        {
            return _HrEmployeeRepository.GetEmployeePagianation(page, pageSize);
        }
        public HrEmployeeGetVM GetById(int employeeId)
        {
            return _HrEmployeeRepository.GetById(employeeId);
        }
        public List<HrEmployeeGetVM> GetByName(string Name)
        {
            return _HrEmployeeRepository.GetByName(Name);
        }
        public List<HrEmployeeGetSearchVM> Search(HrSearch searchModel)
        {
            return _HrEmployeeRepository.Search(searchModel);
        }
        public byte[] GenerateReportAsync(string reportName, string reportType, HrSearch searchModel)
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

            List<HrEmployeeGetSearchVM> HrEmployee;


            if (reportName == "EmploymentStatus")
            {
                HrEmployee = Search(searchModel);

                report.DataSources.Add(new ReportDataSource() { Name = "HrEmployee", Value = HrEmployee });
            }
            else if (reportName == "FunctionalStructureReport")
            {
                HrEmployee = Search(searchModel);

                report.DataSources.Add(new ReportDataSource() { Name = "HrEmployee", Value = HrEmployee });
            }
            // Dictionary<string, string> parameters = new Dictionary<string, string>();

            // var result = report.Execute(Entities.Helpers.ReportHelper.GetRenderType(reportType), 1, parameters);

            byte[] renderedBytes = report.Render(reportType);


            return renderedBytes;
        }

    }
}
