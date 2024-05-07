using System;

namespace Entities.ViewModels.HR
{
    public class HrAttendanceScheduleGeneralVM
    {

        public string name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WrkHours { get; set; }
        public DateTime AttendanceTime { get; set; }
        public int AttendanceAllowance { get; set; }
        public int DepartureAllowance { get; set; }

        //Navigation foreign

        public int TransactionUserId { get; set; }


    }

    public class HrAttendanceScheduleVM : HrAttendanceScheduleGeneralVM
    {
        public int Id { get; set; }

    }


    public class HrAttendanceScheduleGetVM : HrAttendanceScheduleVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }



    }
}
