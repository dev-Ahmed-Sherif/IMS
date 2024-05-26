using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Entities.ViewModels.STR.AddDetails.StrAddDetailsGeneralVM;

namespace Entities.ViewModels.STR.AddDetails
{
    public class StrAddGeneralVM
    {

        public int No { get; set; }
        public DateTime Date { get; set; }
        public string? ShortDate { get; set; }
        public int Total { get; set; }
        public int? EntryNo { get; set; }
        public string Notes { get; set; }
        public string Attachment { get; set; }
        public string Type { get; set; }
        public int? withdrawId { get; set; }
        public int? ApprovalStatusId { get; set; }
        public int StoreId { get; set; }

        public int? SourceStoreId { get; set; }
        public int? SellerId { get; set; }
        public int? EmployeeId { get; set; }
        public int TransactionUserId { get; set; }
        public int FiscalYearId { get; set; }
        public int CommodityId { get; set; }
        public int? AddTypeId { get; set; }


    }
    public class StrAddVM : StrAddGeneralVM
    {
        public int Id { get; set; }
        public IFormFile File { get; set; } = null;

    }
    public class StrAddGetVM : StrAddVM
    {
        public string StoreName { get; set; }

        public string SellerName { get; set; }
        public string EmployeeName { get; set; }
        public string SourceStoreName { get; set; }
        public string CreateUserName { get; set; }
        public string fiscalyear { get; set; }
        public string ApprovalStatusName { get; set; }
        public int? WithDrawNo { get; set; }
        public string CommodityName { get; set; }
        public string AddTypeName { get; set; }
        public string ReportDate { get; set; }
        public string Section { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<StrAddDetailsGetVM> StrAddDetailsGetVM { get; set; }
    }

    public class searchadd
    {
        public int? StoreId { get; set; }
        public int? id { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime? Date { get; set; }
        public int? No { get; set; }
        public int? EntryNo { get; set; }
        public int? SourceStoreId { get; set; }
        public int? SellerId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ItemId { get; set; }
        public int? FiscalYearId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int? SectionId { get; set; }
    }
    public class reportAddsearch : searchadd
    {
        public string reportName { get; set; }
        public string reportType { get; set; }



        //public List<StrItemGeneralVM> reportData { get; set; }

    }
    public class itemcard
    {
        public int? StoreId { get; set; }
        public int? ItemId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
    public class TransactionDetail
    {

        public string ItemName { get; set; }
        public string ItemCommodity { get; set; }
        public string ItemGrade { get; set; }
        public string ItemPlatoon { get; set; }
        public string ItemGroup { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int? Billid { get; set; }
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public decimal TransactionQty { get; set; }
        public decimal Qty { get; set; }
        public decimal TotalQty { get; set; }
        public string Section { get; set; }
        public int SectionId { get; set; }
        //public decimal outcomeQty { get; set; }
        public decimal Price { get; set; }
        public decimal AvgPrice { get; set; }
        public int BillNo { get; set; }
        public string TransactionName { get; set; }
        public int TransactionID { get; set; }
        public string CreatUsername { get; set; }
        public decimal? Total { get; set; }
        public string? TheDate { get; set; }
        public string ReportDate { get; set; }
        public DateTime Date { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Unit {  get; set; }
    }
    public class AddFromStoreVM
    {
        public int UserId { get; set; }
        public int WithDrawId { get; set; }
        public int State { get; set; }
    }
    public class SectionAdd
    {
        public int? SectionId { get; set; }
    }
}
