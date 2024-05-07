using Entities.ViewModels.STR.General;
using System.Collections.Generic;

namespace Entities.ViewModels.STR.StoreOpen
{
    public class StrOpeningStockDetailsGeneralVM
    {
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string Notes { get; set; }
        public int TransactionUserId { get; set; }
        public int STR_Opening_StockId { get; set; }
        public int ItemId { get; set; }
        //public int? ProductId { get; set; }

    }
    public class StrOpeningStockDetailsVM : StrOpeningStockDetailsGeneralVM
    {
        public int Id { get; set; }

    }
    public class StrOpeningStockDetailsGetVM : StrOpeningStockDetailsVM
    {
        public string ItemName { get; set; }
        public string FullCode { get; set; }
        //public string ProductName { get; set; }
        public int STR_Opening_StockNo { get; set; }
        public string CreateUserName { get; set; }
        //add header Data
        public string HeaderStoreName { get; set; }
        public string HeaderCreateUserName { get; set; }
        public string HeaderFiscalYear { get; set; }
        public string HeaderDate { get; set; }
        public string ReportDate { get; set; }
        public int HeaderNo { get; set; }
        public decimal HeaderTotal { get; set; }
        public string Section { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Unit { get; set; }
    }
    public class STR_Opening_Stock_DetailsWithItemsVM : StrOpeningStockDetailsVM
    {
        public List<StrItemVM> Opening_Stock_Details_Item { get; set; }
    }
}
