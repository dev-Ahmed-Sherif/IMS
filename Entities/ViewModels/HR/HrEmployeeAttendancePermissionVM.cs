using System;

namespace Entities.ViewModels.HR
{
    public class HrEmployeeAttendancePermissionGeneralVM
    {

        public string name { get; set; }
        public DateTime Date { get; set; }


        //Navigation foreign
        public int TransactionUserId { get; set; }
        public int EmployeeId { get; set; }
        public int AttendancePermissionId { get; set; }


    }

    public class HrEmployeeAttendancePermissionVM : HrEmployeeAttendancePermissionGeneralVM
    {
        public int Id { get; set; }

    }


    public class HrEmployeeAttendancePermissionGetVM : HrEmployeeAttendancePermissionVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

        public string EmployeeName { get; set; }
        public string AttendancePermissionName { get; set; }


    }
    public class HrEmployeeAttendancePermissionGetSearch : HrEmployeeAttendancePermissionGetVM
    {

        public string ShortDate { get; set; }

    }

    public class HrEmployeeAttendancePermissionSearch
    {
        public string name { get; set; }
        public DateTime? Date { get; set; }

        public string EmployeeName { get; set; }
        public string AttendancePermissionName { get; set; }
    }

    public class HrEmpAttendancePermissionReport : HrEmployeeAttendancePermissionSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }


    }
}
