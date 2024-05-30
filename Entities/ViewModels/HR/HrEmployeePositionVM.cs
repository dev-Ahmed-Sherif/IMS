using System;

namespace Entities.ViewModels
{
    public class HrEmployeePositionGeneralVM
    {

        public DateTime Date { get; set; }

        //Navigation foreign
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public int WorkPlaceId { get; set; }
        public int TransactionUserId { get; set; }
    }

    public class HrEmployeePositionVM : HrEmployeePositionGeneralVM
    {
        public int Id { get; set; }

    }

    public class HrEmployeePositionGetVM : HrEmployeePositionVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string EmployeeName { get; set; }
        public string PositionName { get; set; }
        public string WorkPlaceName { get; set; }

    }
    public class HrEmployeePositionGetSearchVM : HrEmployeePositionGetVM
    {
        public string ShortDate { get; set; }

        public string ReportDate { get; set; }
        public string Section {  get; set; }
    }



    public class HrEmployeePositionSearch
    {
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? PositionId { get; set; }
    }

    public class HrEmployeePositionReport : HrEmployeePositionSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }
    }
}
