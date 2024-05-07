namespace Entities.ViewModels.FI.Account
{
    public class FiAccountHierarchyGVM
    {
        public string Name { get; set; }
        public string level { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class FiAccountHierarchyVM : FiAccountHierarchyGVM
    {
        public int Id { get; set; }
    }
    public class FiAccountHierarchyGetVM : FiAccountHierarchyVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }

}
