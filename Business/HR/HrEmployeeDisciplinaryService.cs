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
using Entities.ViewModels;

namespace Business.HR
{
    public class HrEmployeeDisciplinaryService
    {
        public HrEmployeeDisciplinaryRepository _HrEmployeeDisciplinaryRepository;
        public HrEmployeeDisciplinaryService(HrEmployeeDisciplinaryRepository HrEmployeeDisciplinaryRepository)
        {
            _HrEmployeeDisciplinaryRepository = HrEmployeeDisciplinaryRepository;
        }
        public string Add(HrEmployeeDisciplinaryVM EmployeeDisciplinary)
        {
            return _HrEmployeeDisciplinaryRepository.Add(EmployeeDisciplinary);
        }

        public string Update(HrEmployeeDisciplinaryVM EmployeeDisciplinary)
        {
            return _HrEmployeeDisciplinaryRepository.Update(EmployeeDisciplinary);
        }

        public string Delete(int EmployeeDisciplinaryId)
        {
            return _HrEmployeeDisciplinaryRepository.Delete(EmployeeDisciplinaryId);
        }
        public List<HrEmployeeDisciplinaryGetVM> GetAll()
        {
            return _HrEmployeeDisciplinaryRepository.GetAll();
        }
        public HrEmployeeDisciplinaryGetVM GetById(int EmployeeDisciplinaryId)
        {
            return _HrEmployeeDisciplinaryRepository.GetById(EmployeeDisciplinaryId);
        }

        public List<HrEmployeeDisciplinaryGetSearchVM> Search(HrEmployeeDisciplinarySearch searchModel)
        {
            return _HrEmployeeDisciplinaryRepository.Search(searchModel);
        }
        public byte[] GenerateReportAsync(string reportName, string reportType, HrEmployeeDisciplinarySearch searchModel)
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

            List<HrEmployeeDisciplinaryGetSearchVM> HrEmployeeDisciplinary;


            if (reportName == "EmployeeDisciplinaryReport")
            {

                HrEmployeeDisciplinary = Search(searchModel);

                report.DataSources.Add(new ReportDataSource() { Name = "HrEmployeeDisciplinary", Value = HrEmployeeDisciplinary });
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
