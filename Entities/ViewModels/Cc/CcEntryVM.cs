using System;

namespace Entities.ViewModels.Cc
{
    public class CcEntryGeneralVM
    {
        public int No { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal? CreditTotal { get; set; }
        public decimal? DebitTotal { get; set; }
        public decimal? Balance { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class CcEntryVM : CcEntryGeneralVM
    {
        public int Id { get; set; }
    }
    public class CcEntryGetVM : CcEntryVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
