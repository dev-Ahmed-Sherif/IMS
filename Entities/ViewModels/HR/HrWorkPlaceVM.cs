namespace Entities.ViewModels.HR
{
    public class HrWorkPlaceGeneralVM
    {

        public string Name { get; set; }

        //Navigation foreign
        public int CityStateId { get; set; }

        public int TransactionUserId { get; set; }

    }
    public class HrWorkPlaceVM : HrWorkPlaceGeneralVM
    {
        public int Id { get; set; }

    }
    public class HrWorkPlaceGetVM : HrWorkPlaceVM
    {

        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

        public string CityStateName { get; set; }

    }


}
