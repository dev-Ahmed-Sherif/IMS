using System;

namespace Entities.ViewModels
{
    public class HrIncentiveAllowanceGeneralVM
    {

        public int No { get; set; }

        public DateTime Date { get; set; }

        //Navigation foreign
        public int EmployeeId { get; set; }
        public int FiscalYearId { get; set; }
        public int TransactionUserId { get; set; }
    }

    public class HrIncentiveAllowanceVM : HrIncentiveAllowanceGeneralVM
    {
        public int Id { get; set; }

    }

    public class HrIncentiveAllowanceGetVM : HrIncentiveAllowanceVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string Employeename { get; set; }
        public string FiscalYearName { get; set; }

    }
}
