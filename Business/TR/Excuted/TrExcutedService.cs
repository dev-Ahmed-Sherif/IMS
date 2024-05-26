using DAL;
using DAL.TR.Excuted;
using Entities.ViewModels.TR.Course;
using Entities.ViewModels.TR.Excuted;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static DAL.TR.Excuted.TrExcutedRepository;

namespace Business.TR.Excuted
{
    public class TrExcutedService
    {
        public TrExcutedRepository _TrExcutedRepository;
        public TrExcutedService(TrExcutedRepository TrExcutedRepository)
        {
            _TrExcutedRepository = TrExcutedRepository;
        }
        public string Add(TrExcutedGeneralVM ID)
        {
            return _TrExcutedRepository.Add(ID);
        }

        public string Update(TrExcutedVM ID)
        {
            return _TrExcutedRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _TrExcutedRepository.Delete(ID);
        }
        public List<TrExcutedGetVM> GetAll()
        {
            return _TrExcutedRepository.GetAll();
        }
        public TrExcutedGetVM GetById(int ID)
        {
            return _TrExcutedRepository.GetById(ID);
        }
        public PaginatedResult<TrExcutedGetVM> GetAllByPagination(int page, int pageSize)
        {
            return _TrExcutedRepository.GetAllByPagination(page, pageSize);
        }

        public List<TrExcutedGetSearchVM> Search(TrExcutedSearch searchModel)
        {
            return _TrExcutedRepository.Search(searchModel);

        }

        public byte[] GenerateReportAsync(string reportName, string reportType, TrExcutedSearch searchModel)
        {
            // get report file

            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Business.dll", string.Empty);
            Console.WriteLine(string.Format("{0}ReportsFiles\\{1}.rdlc", fileDirPath, reportName));
            string rdclFilePath = string.Format("{0}ReportsFiles\\TR\\{1}.rdlc", fileDirPath, reportName);

            // file encoding

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            //LocalReport report = new LocalReport(rdclFilePath);
            LocalReport report = new()
            {
                ReportPath = rdclFilePath
            };
            // prepare data for report

            List<TrExcutedGetSearchVM> TrExcuted;


            if (reportName == "TrCourseExcuted")
            {

                TrExcuted = Search(searchModel);

                //report.AddDataSource("TrCourse", TrCourse);
                report.DataSources.Add(new ReportDataSource() { Name = "TrCourseExcuted", Value = TrExcuted });
            }
            //else if (reportName == "EmployeeStatistics")
            //{
            //    HrEmployee = Search(searchModel);
            //    report.AddDataSource("HrEmployeeStatistics", HrEmployee);
            //}

            // Dictionary<string, string> parameters = new Dictionary<string, string>();

            // var result = report.Execute(GetRenderType(reportType), 1, parameters);

            //var result = report.Execute(GetRenderType(reportType));

            //return result.MainStream;
            byte[] renderedBytes = report.Render(reportType);


            return renderedBytes;
        }


    }
}
