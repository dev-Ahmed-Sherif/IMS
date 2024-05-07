using System;

namespace Entities.ViewModels.Fa
{
    public class FaFixedAssetGeneralVM
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Place { get; set; }
        public int CategoryFirstId { get; set; }
        public int CategorySecondId { get; set; }
        public int CategoryThirdId { get; set; }

        public string No { get; set; }
        public string Code { get; set; }
        public int? CostCenterId { get; set; }
        public int? EntryId { get; set; }

        public string State { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime? WorkDate { get; set; }
        public decimal InitialValue { get; set; }
        public decimal? BookValue { get; set; }
        public decimal DepreciationRate { get; set; }
        public DateTime? SpeculateDate { get; set; }

        public decimal? SpeculateValue { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class FaFixedAssetVM : FaFixedAssetGeneralVM
    {
        public int Id { get; set; }
    }
    public class FaFixedAssetGetVM : FaFixedAssetVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string CategoryFirstName { get; set; }
        public int CategoryFirstCode { get; set; }
        public string CategorySecondName { get; set; }
        public string CategorySecondCode { get; set; }
        public string CategoryThirdName { get; set; }
        public string CategoryThirdCode { get; set; }
        public string? CostCenterName { get; set; }
        public string? CostCenterCode { get; set; }
        public int FiEntryNo { get; set; }

        public string FiEntryDescription { get; set; }
        public DateTime FiEntryDate { get; set; }
        public decimal FiEntryCreditTotal { get; set; }
        public decimal FiEntryDebitTotal { get; set; }
        public decimal FiEntryBalance { get; set; }

        public string FiEntryState { get; set; }
    }
    public class SearchGeneral
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public int? CategoryFirstId { get; set; }
        public int? CategorySecondId { get; set; }
        public int? CategoryThirdId { get; set; }
        public string Code { get; set; }
        public int? CostCenterId { get; set; }
        public int? EntryId { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? WorkDate { get; set; }
        public DateTime? SpeculateDate { get; set; }


    }

    public class reportsearch : SearchGeneral
    {
        public string reportName { get; set; }
        public string reportType { get; set; }

    }
}
