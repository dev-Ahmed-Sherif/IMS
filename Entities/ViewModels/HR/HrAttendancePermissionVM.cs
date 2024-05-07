namespace Entities.ViewModels.HR
{
    public class HrAttendancePermissionGeneralVM
    {

        public string name { get; set; }



        //Navigation foreign
        public int TransactionUserId { get; set; }


    }

    public class HrAttendancePermissionVM : HrAttendancePermissionGeneralVM
    {
        public int Id { get; set; }

    }


    public class HrAttendancePermissionGetVM : HrAttendancePermissionVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }
}
