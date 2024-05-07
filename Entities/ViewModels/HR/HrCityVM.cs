namespace Entities.ViewModels.HR
{
    public class HrCityGeneralVM
    {

        public string name { get; set; }
        public int TransactionUserId { get; set; }

    }

    public class HrCityVM : HrCityGeneralVM
    {
        public int Id { get; set; }

    }


    public class HrCityGetVM : HrCityVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }
}
