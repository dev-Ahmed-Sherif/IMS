using System;

namespace Entities.ViewModels.HR
{
    public class HrEmployeeAttendanceScheduleGeneralVM
    {

        public string name { get; set; }





        //Navigation foreign
        public int TransactionUserId { get; set; }
        public int EmployeeId { get; set; }
        public int AttendanceScheduleId { get; set; }
        public int AttendancePermissionId { get; set; }

    }

    public class HrEmployeeAttendanceScheduleVM : HrEmployeeAttendanceScheduleGeneralVM
    {
        public int Id { get; set; }

    }


    public class HrEmployeeAttendanceScheduleGetVM : HrEmployeeAttendanceScheduleVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string EmployeeName { get; set; }
        public string AttendanceScheduleName { get; set; }
        public string AttendancePermissionName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReportDate { get; set; }

        public string Section { get; set; }

    }
    public class HrEmpAttendScheduleSearch
    {
        public string name { get; set; }
        public string EmployeeName { get; set; }
        public string AttendanceScheduleName { get; set; }
        public string AttendancePermissionName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }


    public class HrEmpAttendScheduleReport : HrEmpAttendScheduleSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }
    }
}
