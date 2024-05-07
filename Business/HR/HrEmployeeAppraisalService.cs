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
    public class HrEmployeeAppraisalService
    {
        public HrEmployeeAppraisalRepository _HrEmployeeAppraisalRepository;
        public HrEmployeeAppraisalService(HrEmployeeAppraisalRepository HrEmployeeAppraisalRepository)
        {
            _HrEmployeeAppraisalRepository = HrEmployeeAppraisalRepository;
        }
        public string Add(HrEmployeeAppraisalVM EmployeeAppraisal)
        {
            return _HrEmployeeAppraisalRepository.Add(EmployeeAppraisal);
        }

        public string Update(HrEmployeeAppraisalVM EmployeeAppraisal)
        {
            return _HrEmployeeAppraisalRepository.Update(EmployeeAppraisal);
        }

        public string Delete(int EmployeeAppraisalId)
        {
            return _HrEmployeeAppraisalRepository.Delete(EmployeeAppraisalId);
        }
        public List<HrEmployeeAppraisalGetVM> GetAll()
        {
            return _HrEmployeeAppraisalRepository.GetAll();
        }
        public HrEmployeeAppraisalGetVM GetById(int EmployeeAppraisalId)
        {
            return _HrEmployeeAppraisalRepository.GetById(EmployeeAppraisalId);
        }
        public List<HrEmployeeAppraisalGetSearchVM> Search(searchEmpAppr searchModel)
        {
            return _HrEmployeeAppraisalRepository.Search(searchModel);
        }
        public byte[] GenerateReportAsync(string reportName, string reportType, searchEmpAppr searchModel)
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

            List<HrEmployeeAppraisalGetSearchVM> HrEmployeeAppraisal;


            if (reportName == "EmployeeAppraisalReport")
            {

                HrEmployeeAppraisal = Search(searchModel);

                report.DataSources.Add(new ReportDataSource() { Name = "HrEmployeeAppraisal", Value = HrEmployeeAppraisal });
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
