using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels.FI.Account
{
    public class FiAccountGVM
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? TransactionUserId { get; set; }
        public int FiAccountHierarchyId { get; set; }
    }
    public class FiAccountVM : FiAccountGVM
    {
        public int Id { get; set; }
    }
    public class FiAccountGetVM : FiAccountVM
    {
        public string FiAccountHierarchyName { get; set; }
        public string FiAccountlevel { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
    public class FiAccountGetParentVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }

    public class AccountItemVM : FiAccountVM
    {
        public decimal AccountNet { get; set; }
        public decimal AccountNetDebit { get; set; }
        public decimal AccountNetCredit { get; set; }
        public decimal AccountSubNet { get; set; }
        public decimal AccountSubNetDebit { get; set; }
        public decimal AccountSubNetCredit { get; set; }
        public decimal PrevAccountNet { get; set; }
        public decimal PrevAccountSubNet { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ReportDate { get; set; }
        public string Section { get; set; }
        public int CodeInt { get; set; }
        /*public string class_code { get; set; }
        public string class_name { get; set; }
        public decimal? class_credit { get; set; }
        public decimal? class_depit { get; set; }

        public string category_code { get; set; }
        public string category_name { get; set; }
        public decimal? category_credit { get; set; }
        public decimal? category_depit { get; set; }

        public string subcategory_code { get; set; }
        public string subcategory_name { get; set; }
        public decimal? subcategory_credit { get; set; }
        public decimal? subcategory_depit { get; set; }

        public string account_code { get; set; }
        public string account_name { get; set; }
        public decimal? account_credit { get; set; }
        public decimal? account_depit { get; set; }*/
    }
    public class AccountItemByCode : FiAccountVM
    {
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Date { get; set; }
        public DateTime date { get; set; }
        public int No { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Section { get; set; }
    }

    public class AccountItemWithParent : AccountItemByCode
    {
        public string ParentCode { get; set; }
        public string ParentName { get; set; }
        public decimal AccountNet { get; set; }
        public decimal AccountSubNet { get; set; }
    }
    public class ReportAccount
    {
        [Required]
        public string reportName { get; set; }
        [Required]
        public string reportType { get; set; }
        //[Required]
        //public string fiscalYearId { get; set; }
        
        //public string code { get; set; }

    }
    public class search
    {
        public int? ClassCode { get; set; }
        public int? CategoryCode { get; set; }
        public int? SubCategoryCode { get; set; }
    }
    public class withdrawToCostCenter
    {
        public string AccountName { get; set; }
        public string AccountCode { get; set; }
        public string CostCenterName { get; set; }
        public string CostCenterCode { get; set; }
        public decimal Total { get; set; }
        public string Date { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ReportDate { get; set; }
        public string Section { get; set; }
        public int? SectionId { get; set; }
    }
}
