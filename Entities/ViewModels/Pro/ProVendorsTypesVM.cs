namespace Entities.ViewModels.Pro
{
    public class ProVendorsTypesBulkInputVM
    {
        public int VendorId { get; set; }
        public int[] VendorTypes { get; set; }
    }
    public class ProVendorsTypesGeneralVM
    {
        public int VendorId { get; set; }
        public int VendorTypeId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class ProVendorsTypesVM : ProVendorsTypesGeneralVM
    {
        public int Id { get; set; }
    }
    public class ProVendorsTypesGetVM : ProVendorsTypesVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string VendorName { get; set; }
        public int VendorCode { get; set; }
        public string VendorTypeName { get; set; }
        public int VendorTypeCode { get; set; }
    }
}
