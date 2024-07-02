using Entities.ViewModels.STR.General;
using System;
using System.Collections.Generic;

namespace Entities.ViewModels.STR.AddDetails
{
    public class StrAddDetailsGeneralVM
    {
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string State { get; set; }
        public decimal? Percentage { get; set; }
        public string Notes { get; set; }
        public int ItemId { get; set; }
        public int? ProductId { get; set; }
        public int AddId { get; set; }
        public int TransactionUserId { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal BalanceQty { get; set; }
        public class StrAddDetailsVM : StrAddDetailsGeneralVM
        {
            public int Id { get; set; }

        }
        public class StrAddDetailsGetVM : StrAddDetailsVM
        {
            public string ItemName { get; set; }
            public string ProductName { get; set; }
            public string FullCode { get; set; }
            public int AddNo { get; set; }
            public string CreateUserName { get; set; }
            //add header Data
            public string HeaderStoreName { get; set; }
            public string HeaderSourceName { get; set; }
            //public string HeaderVendorName { get; set; }
            //public string HeaderSourceStoreName { get; set; }
            public string HeaderEmployeeName { get; set; }
            public string HeaderCreateUserName { get; set; }
            public string HeaderFiscalYear { get; set; }
            public string HeaderType { get; set; }
            public string HeaderDate { get; set; }
            public int HeaderTotal { get; set; }
            public string ReportDate { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string Section { get; set; }
            public string Unit { get; set; }
        }


        public class STR_Add_DetailsWithItemsVM : StrAddDetailsVM
        {
            public List<StrItemVM> STR_Add_Details_item { get; set; }
        }
        public class StrAddWithavgprice : StrAddDetailsVM
        {
            public int FiscalYearId { get; set; }
            public DateTime date { get; set; }
            public int storeid { get; set; }
        }
        public class searchaddddetails
        {
            public int? ItemId { get; set; }

        }
        public class GetAddDetailsByAddIdVM
        {
            public List<StrAddDetailsGetVM> StrAddDetailsGetVM { get; set; }
            public StrAddGetVM StrAddGetVM { get; set; }
        }
    }
}
