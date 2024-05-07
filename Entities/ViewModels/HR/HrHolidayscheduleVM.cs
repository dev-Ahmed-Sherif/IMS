using System;

namespace Entities.ViewModels.HR
{

    public class HrHolidayScheduleGeneralVM
    {

        public string name { get; set; }
        public int year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        //Navigation foreign
        public int TransactionUserId { get; set; }

        public int HolidayId { get; set; }

    }

    public class HrHolidayScheduleVM : HrHolidayScheduleGeneralVM
    {
        public int Id { get; set; }

    }


    public class HrHolidayScheduleGetVM : HrHolidayScheduleVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string HolidayName { get; set; }

    }
}
