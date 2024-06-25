namespace Entities.ViewModels.Pro
{
    public class ProSupplierTypeGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class ProSupplierTypeVM : ProSupplierTypeGeneralVM
    {
        public int Id { get; set; }

    }
    public class ProSupplierTypeGetVM : ProSupplierTypeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
