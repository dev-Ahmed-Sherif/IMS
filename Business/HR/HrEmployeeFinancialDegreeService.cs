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
    public class HrEmployeeFinancialDegreeService
    {
        public HrEmployeeFinancialDegreeRepository _EmployeeFinancialDegreeRepository;
        public HrEmployeeFinancialDegreeService(HrEmployeeFinancialDegreeRepository HrEmployeeFinancialDegreeRepository)
        {
            _EmployeeFinancialDegreeRepository = HrEmployeeFinancialDegreeRepository;
        }
        public string Add(HrEmployeeFinancialDegreeVM ID)
        {
            return _EmployeeFinancialDegreeRepository.Add(ID);
        }

        public string Update(HrEmployeeFinancialDegreeVM ID)
        {
            return _EmployeeFinancialDegreeRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _EmployeeFinancialDegreeRepository.Delete(ID);
        }
        //public List<HrEmployeeFinancialDegreeGetVM> GetAll()
        //{
        //    return _EmployeeFinancialDegreeRepository.GetAll();
        //}
        public HrEmployeeFinancialDegreeGetVM GetById(int ID)
        {
            return _EmployeeFinancialDegreeRepository.GetById(ID);
        }

        public List<HrEmployeeFinancialDegreeGetSearchVM> Search(HrEmployeeFinancialDegreeSearch searchModel)
        {
            return _EmployeeFinancialDegreeRepository.Search(searchModel);
        }



        public byte[] GenerateReportAsync(string reportName, string reportType, HrEmployeeFinancialDegreeSearch searchModel)
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

            List<HrEmployeeFinancialDegreeGetSearchVM> HrEmployeeFinancialDegree;


            if (reportName == "EmployeeFinancialDegreeReport")
            {

                HrEmployeeFinancialDegree = Search(searchModel);

                report.DataSources.Add(new ReportDataSource() { Name = "EmployeeFinancialDegree", Value = HrEmployeeFinancialDegree });
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
