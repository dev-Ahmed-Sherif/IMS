namespace Entities.ReportViewModel
{
    public class BalanceStoreViewModel
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal OpenQty { get; set; }
        public decimal OpenTotalQty { get; set; }
        public decimal AddQty { get; set; }
        public decimal AddTotalQty { get; set; }
        public decimal AddTransQty { get; set; }
        public decimal AddTotalTrans { get; set; }
        public decimal WithdrawQty { get; set; }
        public decimal WithdrawTotalQty { get; set; }
        public decimal WithdrawTransQty { get; set; }
        public decimal WithdrawTotalTrans { get; set; }
        public decimal FinalTotal { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ReportDate { get; set; }

    }
}
