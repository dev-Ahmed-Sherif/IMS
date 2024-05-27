using DAL;
using DAL.TR.Course;
using Entities.Models.HR;
using Entities.ViewModels.TR.Course;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static DAL.TR.Course.TrCourseRepository;

namespace Business.TR.Course
{
    public class TrCourseService
    {
        public TrCourseRepository _Repository;
        public TrCourseService(TrCourseRepository TrCourseRepository)
        {
            _Repository = TrCourseRepository;
        }
        public string Add(TrCourseGeneralVM TR_Course)
        {
            return _Repository.Add(TR_Course);
        }
        public string Update(TrCourseVM TR_Course)
        {
            return _Repository.Update(TR_Course);
        }
        public string Delete(int TR_Course_Id)
        {
            return _Repository.Delete(TR_Course_Id);
        }
        public List<TrCourseGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        public TrCourseGetVM GetById(int TRCourseId)
        {
            return _Repository.GetById(TRCourseId);
        }
        public PaginatedResult<TrCourseGetVM> getAllByPagination(int page, int pageSize)
        {
            return _Repository.GetAllByPagination(page, pageSize);
        }

        public List<TrCourseGetSearchVM> Search(TrCourseSearch searchModel)
        {
            return _Repository.Search(searchModel);

        }

        public byte[] GenerateReportAsync(string reportName, string reportType, TrCourseSearch searchModel)
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

            List<TrCourseGetSearchVM> TrCourse;


            if (reportName == "Course")
            {

                TrCourse = Search(searchModel);

                //report.AddDataSource("TrCourse", TrCourse);
                report.DataSources.Add(new ReportDataSource() { Name = "TrCourse", Value = TrCourse });
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
