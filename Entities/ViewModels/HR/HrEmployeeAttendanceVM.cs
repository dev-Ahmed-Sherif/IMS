using System;

namespace Entities.ViewModels.HR
{
    public class HrEmployeeAttendanceGeneralVM
    {

        public DateTime Date { get; set; }
        public DateTime Attendance { get; set; }
        public DateTime Departure { get; set; }



        //Navigation foreign
        public int TransactionUserId { get; set; }

        public int AttendanceMachineId { get; set; }

        public int EmployeeId { get; set; }

    }

    public class HrEmployeeAttendanceVM : HrEmployeeAttendanceGeneralVM
    {
        public int Id { get; set; }

    }


    public class HrEmployeeAttendanceGetVM : HrEmployeeAttendanceVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string AttendanceMachineName { get; set; }
        public string EmployeeName { get; set; }
    }
    public class HrEmployeeAttendanceGetSearchVM : HrEmployeeAttendanceGetVM
    {
        public string ShortDate { get; set; }
        public string ShortAttendance { get; set; }
        public string ShortDeparture { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ReportDate { get; set; }
        public string Section { get; set; }
    }



    public class HrEmployeeAttendanceSearch
    {
        public int? id { get; set; }
        public string AttendanceMachineName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Attendance { get; set; }
        public DateTime? Departure { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public class HrEmployeeAttendanceReport : HrEmployeeAttendanceSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }
    }
}
