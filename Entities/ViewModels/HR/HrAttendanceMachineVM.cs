namespace Entities.ViewModels.HR
{

    public class HrAttendanceMachineGeneralVM
    {

        public string name { get; set; }
        public string Serial { get; set; }

        //Navigation foreign
        public int TransactionUserId { get; set; }



    }

    public class HrAttendanceMachineVM : HrAttendanceMachineGeneralVM
    {
        public int Id { get; set; }

    }


    public class HrAttendanceMachineGetVM : HrAttendanceMachineVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }


    }
}
