namespace Entities.ViewModels.HR
{
    public class HrHiringTypeGeneralVM
    {
        public string name { get; set; }
        public int TransactionUserId { get; set; }
    }

    public class HrHiringTypeVM : HrHiringTypeGeneralVM
    {
        public int Id { get; set; }
    }
    public class HrHiringTypeGetVM : HrHiringTypeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
