namespace Entities.ViewModels.Pro
{
    public class ProSellerTypeGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int? TransactionUserId { get; set; }

    }
    public class ProSellerTypeVM : ProSellerTypeGeneralVM
    {
        public int Id { get; set; }
    }
    public class ProSellerTypeGetVM : ProSellerTypeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
