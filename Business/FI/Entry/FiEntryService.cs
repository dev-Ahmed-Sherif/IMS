using DAL;
using DAL.FI.Entry;
using Entities.ViewModels;
using Entities.ViewModels.FI.Entry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.NETCore;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.FI.Entry
{
    public class FiEntryService
    {
        public FiEntryRepository _FiRepository;
        public FiEntryDetailsRepository _Details;
        public FiEntryService(FiEntryRepository FiEntryRepository, FiEntryDetailsRepository FiEntryDetailsRepository)
        {
            _FiRepository = FiEntryRepository;
            _Details = FiEntryDetailsRepository;
        }
        //-------------------
        // ADD new (FI)_Entry
        //-------------------
        public int GetLastNo()
        {
            return _FiRepository.GetLastNo();
        }
        public string Add(FiEntryGeneralVM entry)
        {
            return _FiRepository.Add(entry);
        }

        //-------------------------------------------
        // Update (FI)_Entry { where id == Entry.id }
        //-------------------------------------------
        public string Update(FiEntryVM item)
        {
            return _FiRepository.Update(item);
        }

        //-------------------------------------------
        // Dellete (FI)_Entry { where id == EntryID }
        //-------------------------------------------
        public string Delete(int itemId)
        {
            return _FiRepository.Delete(itemId);
        }

        //-------------------
        //Select * (FI)_Entry 
        //-------------------
        public List<FiEntryGetVM> GetAll(int YearID)
        {
            return _FiRepository.GetAll(YearID);
        }

        //-----------------------------------------
        // Select * (FI)_Entry where {id = EntryID} 
        //-----------------------------------------
        public async Task<FiEntryGetVM> GetById(int itemId)
        {
            return await _FiRepository.GetByIdAsync(itemId);
        }
        //-----------------------------------------
        // Search (FI)_Entry 
        //------------------------------------------
        public List<FiEntryGetVM> Search(searchFiEntry searchModel)
        {
            return _FiRepository.Search(searchModel);
        }
        public List<FiEntryGetVM> GetLastIndex(int? indexSize)
        {
            return _FiRepository.GetLastIndex(indexSize);
        }
        //-----------------------------------------
        // Select pagnation FiEntry
        //------------------------------------------
        public PaginatedResult<FiEntryGetVM> GetPagination(int page, int pageSize, int YearID)
        {
            return _FiRepository.GetPagination(page, pageSize, YearID);
        }
        public PaginatedResult<FiEntryGetVM> SearchPagination(searchFiEntry searchModel ,int page, int pageSize)
        {
            return _FiRepository.SearchPagination(searchModel ,page, pageSize);
        }
        //-------------------------------------------
        // Report

        public async Task<byte[]> GenerateReportAsync(string reportName, string reportType, searchFiEntry searchModel, int HeaderId)
        {
            // get report file
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Business.dll", string.Empty);
            string rdclFilePath = string.Format("{0}ReportsFiles\\FinancialStatment\\{1}.rdlc", fileDirPath, reportName);

            // file encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            LocalReport report = new()
            {
                ReportPath = rdclFilePath
            };

            // prepare data for report
            List<FiEntryGetVM> FiEntry;
            List<FiEntryDetailsGetVM> FiEntryDetails;
            List<FiEntryGetVM> FiEntryFilter = new List<FiEntryGetVM>();

            if (reportName == "EntryReport")
            {
                FiEntry = Search(searchModel);
                //for (int i = 0; i < FiEntry.Count; i++)
                //{
                //    if (FiEntry[i].DebitTotal != 0 && FiEntry[i].CreditTotal != 0 && FiEntry[i].Balance != 0)
                //    {
                //        FiEntryFilter.Add(FiEntry[i]);
                //    }
                //}
                //report.DataSources.Add(new ReportDataSource() { Name = "FiEntry", Value = FiEntryFilter });
                report.DataSources.Add(new ReportDataSource() { Name = "FiEntry", Value = FiEntry });
            }
            else if (reportName == "EntryDetailsReport")
            {
                FiEntryDetails = _Details.Search(searchModel);
                report.DataSources.Add(new ReportDataSource() { Name = "FIEntryDetails", Value = FiEntryDetails });
            }
            else if (reportName == "EntryStatisticalItemReport")
            {
                FiEntryDetails = _Details.EntryStatisticalItem(searchModel);
                report.DataSources.Add(new ReportDataSource() { Name = "FIEntryDetails", Value = FiEntryDetails });
            }
            else if (reportName == "EntryCostCenterReport")
            {
                FiEntryDetails = _Details.EntryCostCenter(searchModel);
                report.DataSources.Add(new ReportDataSource() { Name = "FIEntryDetails", Value = FiEntryDetails });
            }

            byte[] renderedBytes = report.Render(reportType);

            return renderedBytes;
        }

    }
}
