using DAL;
using DAL.STR.Add;
using Entities.ViewModels;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Entities.ViewModels.STR.AddDetails.StrAddDetailsGeneralVM;
using searchadd = Entities.ViewModels.STR.AddDetails.searchadd;
using Microsoft.Reporting.NETCore;

namespace Business.STR.Add
{
    public class StrAddService
    {
        public StrAddRepository _STR_AddRepository;
        public StrAddDetailsRepository _StrAddDetailsRepository;

        public StrAddService
            (StrAddRepository StrAddRepository,
            StrAddDetailsRepository StrAddDetailsRepository
            )
        {
            _STR_AddRepository = StrAddRepository;
            _StrAddDetailsRepository = StrAddDetailsRepository;
        }

        public async Task<string> Add(StrAddVM sTR_Add)
        {
            return await _STR_AddRepository.Add(sTR_Add);
        }
        public string AddFromStore(AddFromStoreVM id)
        {
            return _STR_AddRepository.AddFromStore(id);
        }
        public async Task<string> Update(StrAddVM sTR_Add)
        {
            return await _STR_AddRepository.Update(sTR_Add);
        }
        public string Delete(int sTR_Add_Id)
        {
            return _STR_AddRepository.Delete(sTR_Add_Id);
        }
        public List<StrAddGetVM> GetAll()
        {
            return _STR_AddRepository.GetAll();
        }
        public StrAddGetVM GetById(int sTR_AddId)
        {
            return _STR_AddRepository.GetById(sTR_AddId);
        }
        public List<StrAddGetVM> Search(searchadd searchModel)
        {
            return _STR_AddRepository.Search(searchModel);
        }
        public PaginatedResult<StrAddGetVM> GetByEmployeeStores(int employeeId, int page, int pageSize, int fiscalYearId)
        {
            return _STR_AddRepository.GetByEmployeeStores(employeeId, page, pageSize, fiscalYearId);
        }
        public int GetLastNo(int StoreId, int FiscalYearId)
        {
            return _STR_AddRepository.GetLastNo(StoreId, FiscalYearId);
        }

        // Generate report

        public byte[] GenerateReportAsync(string reportName, string reportType, searchadd searchModel)
        {
            // get report file
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Business.dll", string.Empty);
            string rdclFilePath = string.Format("{0}ReportsFiles\\Store\\{1}.rdlc", fileDirPath, reportName);

            // file encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");
            //LocalReport report = new LocalReport(rdclFilePath);
            LocalReport report = new LocalReport();
            report.ReportPath = rdclFilePath;
            // prepare data for report
            
            
            if (reportName == "AddReport")
            {
                List<StrAddGetVM> StrAdd = Search(searchModel);
                //report.AddDataSource("StrAdd", StrAdd);
                report.DataSources.Add(new ReportDataSource() { Name = "StrAdd", Value = StrAdd });
            }
            else if (reportName == "AddDetailsReport")
            {
                List<StrAddDetailsGetVM> StrAddDetails = _StrAddDetailsRepository.Search(searchModel);
                //report.AddDataSource("STRAddDetails", StrAddDetails);
                report.DataSources.Add(new ReportDataSource() { Name = "STRAddDetails", Value = StrAddDetails });
            }

            //var result = report.Execute(Entities.Helpers.ReportHelper.GetRenderType(reportType));

            //return result.MainStream;

            byte[] renderedBytes = report.Render(reportType);
            return renderedBytes;
        }

    }
}
