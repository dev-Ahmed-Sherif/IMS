using System;

namespace Entities.ViewModels
{
    public class HrEmployeeDisciplinaryGeneralVM
    {

        public DateTime Date { get; set; }
        public int No { get; set; }

        public int NoDays { get; set; }
        public string Description { get; set; }

        //Navigation foreign
        public int EmployeeId { get; set; }
        public int DisciplinaryId { get; set; }

        public int TransactionUserId { get; set; }
    }

    public class HrEmployeeDisciplinaryVM : HrEmployeeDisciplinaryGeneralVM
    {
        public int Id { get; set; }

    }

    public class HrEmployeeDisciplinaryGetVM : HrEmployeeDisciplinaryVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string EmployeeName { get; set; }
        public string DisciplinaryName { get; set; }
    }
}
