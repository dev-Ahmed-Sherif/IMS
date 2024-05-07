using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels.STR.StoreOpen
{
    public class StrOpeningStockGeneralVM
    {
        public int No { get; set; }
        public int StoreId { get; set; }
        public DateTime Date { get; set; }
        public string? ShortDate { get; set; }
        public decimal Total { get; set; }
        public string Notes { get; set; }
        public string Attachment { get; set; }
        public IFormFile File { get; set; }
        public int TransactionUserId { get; set; }
        public int FiscalYearId { get; set; }
        //public string CreateUserName { get; set; }
        //public string DateOnly => Date.ToString("yyyy-MM-dd");

    }
    public class StrOpeningStockVM : StrOpeningStockGeneralVM
    {
        //when we need to send header data only
        public int Id { get; set; }
        //public string CreateUserName { get; set; }
    }
    public class StrOpeningStockGetVM : StrOpeningStockVM
    {
        public string storeName { get; set; }
        public string CreateUserName { get; set; }
        public string fiscalyear { get; set; }

        public string ReportDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Section { get; set; }
        public List<StrOpeningStockDetailsGetVM> StrOpeningStockDetailsGetVM { get; set; }
    }
    public class Opening_StockWithDetailsVM : StrOpeningStockVM
    {
        public List<StrOpeningStockDetailsVM> Opening_Stock_Details { get; set; }

    }
    public class searchopeningstock
    {

        public int? StoreId { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime? Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int? No { get; set; }
        public int? Id { get; set; }
        public int? FiscalYearId { get; set; }
        public int? ItemId { get; set; }
        public int? GradeId { get; set; }
        public int? CommodityId { get; set; }
        public int? SectionId { get; set; }
        //public string CreateUserName { get; set; }
        //public string DateOnly => Date?.ToString("yyyy-MM-dd");
    }
    public class StropeningStockGeTDetailsByOpeningStockIdVM : StrOpeningStockGetVM
    {
        public StrOpeningStockDetailsGetVM StrOpeningStockDetailsGetVM { get; set; }
    }

    public class reportOpeningStock : searchopeningstock
    {
        public string reportName { get; set; }
        public string reportType { get; set; }
    }
}
