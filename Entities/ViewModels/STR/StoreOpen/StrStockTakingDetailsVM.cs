using System;
namespace Entities.ViewModels.STR.StoreOpen
{
    public class StrStockTakingDetailsGeneralVM
    {
        public decimal SystemQty { get; set; }
        public decimal Balance { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string Notes { get; set; }
        public int TransactionUserId { get; set; }
        public int STRStockTakingId { get; set; }
        public int ItemId { get; set; }
        //public int? ProductId { get; set; }

    }
    public class StrStockTakingDetailsVM : StrStockTakingDetailsGeneralVM
    {
        public int Id { get; set; }

    }
    public class StrStockTakingDetailsGetVM : StrStockTakingDetailsVM
    {
        public int HeaderNo { get; set; }
        public string HeaderDate { get; set; }
        public string ReportDate { get; set; }
        public decimal HeaderTotal { get; set; }
        public string HeaderCreateUserName { get; set; }
        public string HeaderFiscalYear { get; set; }
        public string HeaderStore { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string ItemName { get; set; }
        public string FullCode { get; set; }
        public string Unit { get; set; }
        public int STRStockTakingNo { get; set; }
        public string Section { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set;}
    }

    public class StrStockTakingDetailsSumByStore
    {
        public int WithdrawNo { get; set; }
        public string Date { get; set; }
        public string ReportHeaderName { get; set; }
        public int CommidIdGrade { get; set; }
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string Unit { get; set; }
        public string ItemName { get; set; }
        public int StoreId { get; set; }
        public string Store { get; set; }
        public string Section { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }
        public decimal Total { get; set; }
        public decimal SumTotal { get; set; }
        public string ReportDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CostCenter { get; set; }
        public int CostCenterId { get; set; }
        public int FiscalYearId { get; set; }
    }

}
