namespace Entities.ViewModels.HR
{
    public class HrCityStateGeneralVM
    {

        public string name { get; set; }

        //Navigation foreign
        public int CityId { get; set; }
        public int TransactionUserId { get; set; }
    }

    public class HrCityStateVM : HrCityStateGeneralVM
    {
        public int Id { get; set; }

    }

    public class HrCityStateGetVM : HrCityStateVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string CityName { get; set; }

    }
}
