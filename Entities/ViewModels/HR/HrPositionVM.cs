namespace Entities.ViewModels.HR
{
    public class HrPositionGeneralVM
    {

        public string name { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class HrPositionVM : HrPositionGeneralVM
    {
        public int Id { get; set; }
    }
    public class HrPositionGetVM : HrPositionVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }


}
