namespace Entities.ViewModels.HR
{
    public class HrMillitryStateGeneralVM
    {

        public string name { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class HrMillitryStateVM : HrMillitryStateGeneralVM
    {
        public int Id { get; set; }

    }

    public class HrMillitryStateGetVM : HrMillitryStateVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }

}
