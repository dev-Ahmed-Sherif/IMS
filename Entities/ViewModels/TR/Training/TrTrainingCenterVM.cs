namespace Entities.ViewModels.TR
{
    public class TrTrainingCenterGeneralVM
    {

        public string Name { get; set; }
        public string Code { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public bool IsActive { get; set; }

        //Navigation foreign

        public int CityId { get; set; }

        public int TransactionUserId { get; set; }
    }

    public class TrTrainingCenterVM : TrTrainingCenterGeneralVM
    {
        public int Id { get; set; }

    }

    public class TrTrainingCenterGetVM : TrTrainingCenterVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

        public string CityName { get; set; }

    }
}
