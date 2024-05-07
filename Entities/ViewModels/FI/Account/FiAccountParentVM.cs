namespace Entities.ViewModels.FI.Account
{
    public class FiAccountParentGVM
    {
        public int AccountId { get; set; }
        public int ParentId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class FiAccountParentVM : FiAccountParentGVM
    {
        public int Id { get; set; }
    }
    public class FiAccountParentGetVM : FiAccountParentVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string AccountName { get; set; }
        public string ParentName { get; set; }
    }
}
