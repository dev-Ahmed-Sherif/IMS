using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels.STR.WithDraw
{
    public class StrWithdrawGeneralVM

    {
        public int No { get; set; }

        public DateTime Date { get; set; }
        public string? ShortDate { get; set; }

        public int Total { get; set; }

        public string Notes { get; set; }
        public int? ApprovalStatusId { get; set; }

        public string Type { get; set; }
        public bool? DestStoreConfirm { get; set; }
        public string Attachment { get; set; }
        public int StoreId { get; set; }
        public int? EmployeeId { get; set; }
        public int? CostCenterId { get; set; }
        public int DestStoreUserId { get; set; }
        public int TransactionUserId { get; set; }
        public int? DestStoreId { get; set; }
        public int FiscalYearId { get; set; }
        public int? CommodityId { get; set; }
        public int? WithDrawTypeId { get; set; }
        public IFormFile File { get; set; } = null;
    }

    public class StrWithdrawVM : StrWithdrawGeneralVM

    {
        public int Id { get; set; }


    }
    public class StrWithdrawGetVM : StrWithdrawVM
    {
        public string storeName { get; set; }
        public string DesstoreName { get; set; }
        public string EmployeeName { get; set; }
        public string CostCenterName { get; set; }
        public string DesstoreUserName { get; set; }
        public string CreateUserName { get; set; }
        public string fiscalyear { get; set; }
        public string CommodityName { get; set; }
        public string WithDrawTypeName { get; set; }
        public string ReportDate { get; set; }
        public string Section { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<StrWithDrawDetailsGetVM> StrWithDrawDetailsGetVM { get; set; }
    }
    public class searchwithdraw
    {

        public int? StoreId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int? No { get; set; }
        public int? id { get; set; }
        public int? EmployeeId { get; set; }
        public int? CostCenterId { get; set; }
        public int? DestStoreUserId { get; set; }
        public int? DestStoreId { get; set; }
        public int? ItemId { get; set; }
        public int? FiscalYearId { get; set; }
        public int WithdrawType { get; set; }
        public int? SectionId { get; set; }
        public int? CommodityId { get; set; }
        public int? GradeId { get; set; }
    }
    public class SectionWithdraw
    {
        public int? SectionId { get; set; }
    }

    public class reportwithdrawsearch : searchwithdraw
    {
        public string reportName { get; set; }
        public string reportType { get; set; }



        //public List<StrItemGeneralVM> reportData { get; set; }

    }

    public class GetWithDrawDetailsByWithDrawDetailsId
    {
        public StrWithdrawGetVM StrWithdrawGetVM { get; set; }
        public List<StrWithDrawDetailsGetVM> StrWithDrawDetailsGetVM { get; set; }
    }
}
