namespace Entities.ViewModels.Pro
{
    public class ProSellerTypesGeneralVM
    {
        public int SellerId { get; set; }
        public int SellerTypeId { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class ProSellerTypesVM : ProSellerTypesGeneralVM
    {
        public int Id { get; set; }
    }
    public class ProSellerTypesGetVM : ProSellerTypesVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string SellerName { get; set; }
        public int SellerCode { get; set; }
        public string SellerTypeName { get; set; }
        public int SellerTypeCode { get; set; }
    }
}
