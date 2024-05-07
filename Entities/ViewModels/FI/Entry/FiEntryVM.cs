using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels.FI.Entry
{
    public class FiEntryGeneralVM
    {
        public int JournalId { get; set; }
        public int? FiEntrySourceTypeId { get; set; }
        public int No { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string? ShortDate { get; set; }
        public decimal CreditTotal { get; set; }
        public decimal DebitTotal { get; set; }
        public decimal Balance { get; set; }
        public string State { get; set; }
        public int TransactionUserId { get; set; }
        public int? FiscalYearId { get; set; }
    }
    public class FiEntryVM : FiEntryGeneralVM
    {
        public int Id { get; set; }
    }

    public class FiEntryGetVM : FiEntryVM
    {
        public int JournalNo { get; set; }
        public string Journal_Description { get; set; }
        public DateTime? Journal_StartDate { get; set; }
        public DateTime? Journal_EndDate { get; set; }
        public string FiscalYear { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string EntrySourceTypeName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Section { get; set; }
    }
    public class searchFiEntry
    {


        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? No { get; set; }
        public int? Id { get; set; }
        public int? JournalId { get; set; }
        public int? FiEntrySourceTypeId { get; set; }
        public int? AccountId { get; set; }
        public int? FiscalYearId { get; set; }
        public string Description { get; set; }
        public int? SectionId { get; set;}
        public int? FiAccountItemId { get; set; }
        public int? CostCenterId { get; set; }

    }
    public class ReportFiEntry : searchFiEntry
    {
        public string reportName { get; set; }
        public string reportType { get; set; }

    }
    public class SectionEntry
    {
        public int? SectionId { get; set; }
    }
}
