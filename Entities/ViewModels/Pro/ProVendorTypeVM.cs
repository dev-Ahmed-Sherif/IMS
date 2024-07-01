namespace Entities.ViewModels.Pro
{
    public class ProVendorTypeGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int TypeId { get; set; }
        public int OperationTypeId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class ProVendorTypeVM : ProVendorTypeGeneralVM
    {
        public int Id { get; set; }

    }
    public class ProVendorTypeGetVM : ProVendorTypeVM
    {
        public string TypeName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string OperationTypeName { get; set; }
    }
}
