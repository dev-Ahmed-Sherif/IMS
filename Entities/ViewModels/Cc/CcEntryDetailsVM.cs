using System;

namespace Entities.ViewModels.Cc
{
    public class CcEntryDetailsGeneralVM
    {
        public int EntryId { get; set; }
        public int AccountId { get; set; }
        public int ActivityId { get; set; }
        public int CostCenterId { get; set; }
        public int? EquipmentId { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Qty { get; set; }
        public string? Description { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class CcEntryDetailsVM : CcEntryDetailsGeneralVM
    {
        public int Id { get; set; }
    }
    public class CcEntryDetailsGetVM : CcEntryDetailsVM
    {
        public int EntryNo { get; set; }
        public string EntryDescription { get; set; }
        public string AccountName { get; set; }
        public string ActivityCode { get; set; }
        public string ActivityName { get; set; }
        public string CostCenterCode { get; set; }
        public string CostCenterName { get; set; }
        public string? EquipmentCode { get; set; }
        public string? EquipmentName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string AccountCode { get; set; }
        //public string Name { get; set; }
        //header
        public int HeaderNo { get; set; }
        public string HeaderDescription { get; set; }
        public DateTime HeaderDate { get; set; }
        public decimal? HeaderCreditTotal { get; set; }
        public decimal? HeaderDebitTotal { get; set; }
        public decimal? HeaderBalance { get; set; }


    }
}
