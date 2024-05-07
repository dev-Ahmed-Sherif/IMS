using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels.STR.StoreOpen
{
    public class StrStockTakingGeneralVM
    {
        public int No { get; set; }
        public DateTime Date { get; set; }
        public string? ShortDate { get; set; }
        public decimal Total { get; set; }
        public string Notes { get; set; }
        public string Attachment { get; set; }
        public IFormFile File { get; set; }
        public int TransactionUserId { get; set; }
        public int FiscalYearId { get; set; }
        public int StoreId { get; set; }


    }

    public class StrStockTakingVM : StrStockTakingGeneralVM
    {
        public int Id { get; set; }

    }
    public class StrStockTakingGetVM : StrStockTakingVM
    {

        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

        public string fiscalyear { get; set; }
        public string StoreName { get; set; }
        public string ReportDate { get; set; }
        public string Section { get; set; }
        public string StartDate {  get; set; }
        public string EndDate { get; set; }


    }
    public class StrStoreTaking : StrStockTakingGetVM
    {
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public int ItemId { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal ItemQty { get; set; }
        public string Unit { get; set; }
        public string StoreKeeper { get; set; }
    }
    public class Search
    {
        public int? Id { get; set; }
        public int? StoreId { get; set; }
        public int? SectionId { get; set; }
        public int? No { get; set; }
        public int? ItemId { get; set; }
        public int? FiscalYearId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CommodityId { get; set; }
        public int? GradeId { get; set; }
    }
    public class ReportStockTaking
    {

        public int? Id { get; set; }
        [Required]
        public string ReportName { get; set; }
        [Required]
        public string ReportType { get; set; }
        public int StoreId { get; set; }
        public int? SectionId { get; set; }
        [Required]
        public int FiscalYearId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public static implicit operator Search(ReportStockTaking model)
        {
            return new Search
            {
                Id = model.Id,
                StoreId = model.StoreId,
                SectionId = model.SectionId,
                FiscalYearId = model.FiscalYearId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
            };
        }
    }
}
