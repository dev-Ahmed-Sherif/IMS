namespace Entities.ViewModels.FI.Account
{
    public class FiAccountItemGVM
    {
        public string Name { get; set; }
        public int? AccountId { get; set; }
        public int? AccountItemCategoryId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class FiAccountItemVM : FiAccountItemGVM
    {
        public int Id { get; set; }
    }
    public class FiAccountItemGetVM : FiAccountItemVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string AccounCode { get; set; }
        public string AccounName { get; set; }
        public string AccountItemCategoryName { get; set; }
    }
}
