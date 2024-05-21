using System;

namespace Entities.ViewModels.HR
{
    public class HrEmployeeFinancialDegreeGeneralVM
    {


        public int FinancialDegreeId { get; set; }
        public int TransactionUserId { get; set; }
        public DateTime FinancialDegreeDate { get; set; }
    }

    public class HrEmployeeFinancialDegreeVM : HrEmployeeFinancialDegreeGeneralVM
    {

        public int Id { get; set; }
    }


    public class HrEmployeeFinancialDegreeGetVM : HrEmployeeFinancialDegreeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string FinancialDegreeName { get; set; }
    }
    public class HrEmployeeFinancialDegreeGetSearchVM : HrEmployeeFinancialDegreeGetVM
    {
        public string FinancialDegreeShortDate { get; set; }
        public string ReportDate { get; set; }


    }

    public class HrEmployeeFinancialDegreeSearch
    {
        public string FinancialDegreeId { get; set; }
        public int TransactionUserId { get; set; }
        public DateTime? FinancialDegreeDate { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string FinancialDegreeName { get; set; }
    }

    public class HrEmployeeFinancialDegreeReport : HrEmployeeFinancialDegreeSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }
    }
}
