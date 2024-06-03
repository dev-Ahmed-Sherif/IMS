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
using System.Threading.Tasks;

namespace Business.HR
{
    public class HrEmployeeQualificationService
    {
        public HrEmployeeQualificationRepository _HrEmployeeQualificationRepository;
        public HrEmployeeQualificationService(HrEmployeeQualificationRepository HrEmployeeQualificationRepository)
        {
            _HrEmployeeQualificationRepository = HrEmployeeQualificationRepository;
        }
        public async Task<string> Add(HrEmployeeQualificationVM EmployeeQualification)
        {
            return await _HrEmployeeQualificationRepository.Add(EmployeeQualification);
        }

        public async Task<string> Update(HrEmployeeQualificationVM EmployeeQualification)
        {
            return await _HrEmployeeQualificationRepository.Update(EmployeeQualification);
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


            if (reportName == "EmployeeQualificationReport")
            {

                HrEmployeeQualification = Search(searchModel);

                report.DataSources.Add(new ReportDataSource() { Name = "EmployeeQualification", Value = HrEmployeeQualification });
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
