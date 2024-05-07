namespace Entities.ViewModels.FI.Entry
{
    public class FiEntryDetailsGeneralVM
    {
        public int EntryId { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public int? FiAccountItemId { get; set; }
        public int? CostCenterId { get; set; }
        public int? CheckNo { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class FiEntryDetailsVM : FiEntryDetailsGeneralVM
    {
        public int Id { get; set; }
    }
    public class FiEntryDetailsGetVM : FiEntryDetailsVM
    {
        public string CreateUserName { get; set; }
        public string AccountName { get; set; }
        public string AccountItemName { get; set; }
        public string UpdateUserName { get; set; }
        //header data
        public int? HeaderJournalNo { get; set; }
        public string? HeaderFiscalYear { get; set; }
        public string? HeaderEntrySourceTypeName { get; set; }
        public int? HeaderNo { get; set; }
        public string? HeaderDescription { get; set; }
        public string? HeaderDate { get; set; }
        public decimal? HeaderCreditTotal { get; set; }
        public decimal? HeaderDebitTotal { get; set; }
        public decimal? HeaderBalance { get; set; }
        public string? Headerstate { get; set; }
        public string? CostCenterName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Section { get; set; }
    }
}
