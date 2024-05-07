namespace Entities.ViewModels.HR
{

    public class HrHolidayGeneralVM
    {

        public string name { get; set; }
        public int TransactionUserId { get; set; }

    }

    public class HrHolidayVM : HrHolidayGeneralVM
    {
        public int Id { get; set; }

    }


    public class HrHolidayGetVM : HrHolidayVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }
}
