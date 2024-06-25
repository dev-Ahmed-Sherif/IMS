namespace Entities.ViewModels.Pro
{
    public class ProVendorTypeGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class ProVendorTypeVM : ProVendorTypeGeneralVM
    {
        public int Id { get; set; }

    }
    public class ProVendorTypeGetVM : ProVendorTypeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
