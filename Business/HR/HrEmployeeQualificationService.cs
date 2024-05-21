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
    public class HrEmployeeQualificationService
    {
        public HrEmployeeQualificationRepository _HrEmployeeQualificationRepository;
        public HrEmployeeQualificationService(HrEmployeeQualificationRepository HrEmployeeQualificationRepository)
        {
            _HrEmployeeQualificationRepository = HrEmployeeQualificationRepository;
        }
        public string Add(HrEmployeeQualificationVM EmployeeQualification)
        {
            return _HrEmployeeQualificationRepository.Add(EmployeeQualification);
        }

        public string Update(HrEmployeeQualificationVM EmployeeQualification)
        {
            return _HrEmployeeQualificationRepository.Update(EmployeeQualification);
        }

        public string Delete(int EmployeeQualificationId)
        {
            return _HrEmployeeQualificationRepository.Delete(EmployeeQualificationId);
        }
        public List<HrEmployeeQualificationGetVM> GetAll()
        {
            return _HrEmployeeQualificationRepository.GetAll();
        }
        public HrEmployeeQualificationGetVM GetById(int EmployeeQualificationId)
        {
            return _HrEmployeeQualificationRepository.GetById(EmployeeQualificationId);
        }

        public List<HrEmployeeQualificationGetSearch> Search(HrEmployeeQualificationSearch searchModel)
        {
            return _HrEmployeeQualificationRepository.Search(searchModel);
        }



        public byte[] GenerateReportAsync(string reportName, string reportType, HrEmployeeQualificationSearch searchModel)
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

            List<HrEmployeeQualificationGetSearch> HrEmployeeQualification;


            if (reportName == "EmployeeFinancialDegreeReport")
            {

                HrEmployeeQualification = Search(searchModel);

                report.DataSources.Add(new ReportDataSource() { Name = "HrEmployeeQualification", Value = HrEmployeeQualification });
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
