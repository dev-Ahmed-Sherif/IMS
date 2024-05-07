namespace Entities.ViewModels.STR.WithDraw
{

    public class StrWithDrawDetailsGeneralVM
    {


        public decimal Qty { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }

        public string State { get; set; }

        public decimal? Percentage { get; set; }
        public string Notes { get; set; }
        //Navigation foreign
        public int STR_WithdrawId { get; set; }
        public int ItemId { get; set; }
        //public int? ProductId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class StrWithDrawDetailsVM : StrWithDrawDetailsGeneralVM
    {
        public int Id { get; set; }

    }
    public class StrWithDrawDetailsGetVM : StrWithDrawDetailsVM
    {
        public string ItemName { get; set; }
        public string FullCode { get; set; }
        public string Unit { get; set; }
        public int WithDrawNo { get; set; }
        public string CreateUserName { get; set; }
        //add header Data
        public string HeaderStoreName { get; set; }
        public string HeaderDestinationName { get; set; }
        //public string HeaderDesstoreName { get; set; }
        //public string HeaderCostCenterName { get; set; }
        public string HeaderEmployeeName { get; set; }
        public string HeaderDesstoreUserName { get; set; }
        public string HeaderCreateUserName { get; set; }
        public string HeaderFiscalYear { get; set; }
        public string HeaderDate { get; set; }
        public string ReportDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int HeaderNo { get; set; }
        public int HeaderTotal { get; set; }
        public string Section { get; set; }
    }

}
