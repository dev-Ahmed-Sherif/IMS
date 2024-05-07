using System;


namespace Entities.ViewModels.HR
{
    public class HrEmployeeVacationGeneralVM
    {


        public string name { get; set; }
        public int NodDays { get; set; }
        public int SubstituteEmpolyeeId { get; set; }

        //Navigation foreign
        public int EmplpoyeeId { get; set; }
        public int VacationId { get; set; }
        public int TransactionUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class HrEmployeeVacationVM : HrEmployeeVacationGeneralVM
    {
        public int Id { get; set; }
    }

    public class HrEmployeeVacationGetVM : HrEmployeeVacationVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string EmplpoyeeName { get; set; }
        public string SubstituteEmpolyeeName { get; set; }
        public string VacationName { get; set; }
    }
    public class HrEmployeeVacationGetSearch : HrEmployeeVacationGetVM
    {

        public string ShortStartDate { get; set; }
        public string ShortEndDate { get; set; }


    }


    public class HrEmployeeVacationSearch
    {
        public string name { get; set; }
        public string SubstituteEmpolyeeId { get; set; }
        public string VacationId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EmployeeName { get; set; }
        public string SubstituteEmpolyeeName { get; set; }
        public string VacationName { get; set; }


    }
    public class HrEmploeeVactionReport : HrEmployeeVacationSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }


    }
}
