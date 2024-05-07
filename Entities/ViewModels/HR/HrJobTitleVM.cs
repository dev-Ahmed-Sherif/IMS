namespace Entities.ViewModels.HR
{
    public class HrJobTitleGeneralVM
    {

        public string name { get; set; }
        public int TransactionUserId { get; set; }
    }

    public class HrJobTitleVM : HrJobTitleGeneralVM
    {
        public int Id { get; set; }
    }

    public class HrJobTitleGetVM : HrJobTitleVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
