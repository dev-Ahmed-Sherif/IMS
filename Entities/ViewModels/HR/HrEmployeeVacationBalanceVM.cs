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
    }



}
