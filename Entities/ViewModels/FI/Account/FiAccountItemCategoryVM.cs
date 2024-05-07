namespace Entities.ViewModels.FI.Account
{
    public class FiAccountItemCategoryGVM
    {
        public string Name { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class FiAccountItemCategoryVM : FiAccountItemCategoryGVM
    {
        public int Id { get; set; }
    }
    public class FiAccountItemCategoryGetVM : FiAccountItemCategoryVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
