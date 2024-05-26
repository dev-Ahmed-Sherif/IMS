using System;

namespace Entities.ViewModels.FI.General
{
    public class FiJournalGeneralVM
    {
        public int No { get; set; }
        public string? Description { get; set; }
        public int TransactionUserId { get; set; }
        public int TypeId { get; set; }
        public int? FiscalYearId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public class FiJournalVM : FiJournalGeneralVM
    {
        public int Id { get; set; }
    }
    public class FiJournalGetVM : FiJournalVM
    {
        public string? FiscalYear { get; set; }
        public string? Type { get; set; }
        public string? CreateUserName { get; set; }
        public string? UpdateUserName { get; set; }

    }
    public class SectionJournal
    {
        public int? SectionId { get; set; }
    }
    public class Searchjournal
    {
        public int? Id { get; set; }
        public int? No { get; set; }
        public string  Description { get; set; }
  
        public int? FiscalYearId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
