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
    public class HrEmployeeVacationService
    {
        public HrEmployeeVacationRepository _HrEmployeeVacationRepository;
        public HrEmployeeVacationService(HrEmployeeVacationRepository HrEmployeeVacationRepository)
        {
            _HrEmployeeVacationRepository = HrEmployeeVacationRepository;
        }
        public string Add(HrEmployeeVacationVM ID)
        {
            return _HrEmployeeVacationRepository.Add(ID);
        }

        public string Update(HrEmployeeVacationVM ID)
        {
            return _HrEmployeeVacationRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrEmployeeVacationRepository.Delete(ID);
        }
        public List<HrEmployeeVacationGetVM> GetAll()
        {
            return _HrEmployeeVacationRepository.GetAll();
        }
        public HrEmployeeVacationGetVM GetById(int ID)
        {
            return _HrEmployeeVacationRepository.GetById(ID);
        }
        public List<HrEmployeeVacationGetSearch> Search(HrEmployeeVacationSearch searchModel)
        {
            return _HrEmployeeVacationRepository.Search(searchModel);
        }

        public byte[] GenerateReportAsync(string reportName, string reportType, HrEmployeeVacationSearch searchModel)
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

            List<HrEmployeeVacationGetSearch> HrEmployeeVacation;


            if (reportName == "EmpVacationReport")
            {

                HrEmployeeVacation = Search(searchModel);

                report.DataSources.Add(new ReportDataSource() { Name = "EmployeeVacation", Value = HrEmployeeVacation });
            }

            byte[] renderedBytes = report.Render(reportType);

            //     Dictionary<string, string> parameters = new Dictionary<string, string>();

            //   var result = report.Execute(Entities.Helpers.ReportHelper.GetRenderType(reportType), 1, parameters);

            return renderedBytes;
        }

    }
}
