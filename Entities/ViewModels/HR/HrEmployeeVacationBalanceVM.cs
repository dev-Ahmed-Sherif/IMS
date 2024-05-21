namespace Entities.ViewModels.HR
{
    public class HrEmployeeVacationBalanceGeneralVM
    {

        public string name { get; set; }
        public int Year { get; set; }
        public int Balance { get; set; }
        public int EmployeeId { get; set; }
        public int VactionId { get; set; }
        public int TransactionUserId { get; set; }

    }

    public class HrEmployeeVacationBalanceVM : HrEmployeeVacationBalanceGeneralVM
    {
        public int Id { get; set; }
    }

    public class HrEmployeeVacationBalanceGetVM : HrEmployeeVacationBalanceVM
    {

        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string EmployeeName { get; set; }
        public string VactionName { get; set; }
        public string ReportDate { get; set; }
        public string Section { get; set; }

    }
    //public class HrEmployeeVacationBalanceGetSearchVM : HrEmployeeVacationBalanceGetVM
    //{
    //    public string ShortDate { get; set; }
    //}



    public class HrEmployeeVacationBalanceSearch
    {
        public string name { get; set; }
        public string Year { get; set; }
        public string Balance { get; set; }
        public string EmployeeId { get; set; }
        public string VactionId { get; set; }
        public string TransactionUserId { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string EmployeeName { get; set; }
        public string VactionName { get; set; }
    }

    public class HrEmployeeVacationBalanceReport : HrEmployeeVacationBalanceSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }
    }


}
