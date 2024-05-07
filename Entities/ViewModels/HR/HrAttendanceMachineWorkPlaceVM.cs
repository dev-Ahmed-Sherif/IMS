using System;

namespace Entities.ViewModels.HR
{
    public class HrAttendanceMachineWorkPlaceGeneralVM
    {

        public string name { get; set; }
        public DateTime Date { get; set; }


        //Navigation foreign
        public int TransactionUserId { get; set; }

        public int AttendanceMachineId { get; set; }

        public int WorkPlaceId { get; set; }

    }

    public class HrAttendanceMachineWorkPlaceVM : HrAttendanceMachineWorkPlaceGeneralVM
    {
        public int Id { get; set; }

    }


    public class HrAttendanceMachineWorkPlaceGetVM : HrAttendanceMachineWorkPlaceVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string AttendanceMachineName { get; set; }
        public string WorkPlaceName { get; set; }
    }
}
