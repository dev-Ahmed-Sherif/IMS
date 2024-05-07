namespace Entities.ViewModels.Pro
{
    public class ProContractorTypesGeneralVM
    {
        public int ContractorId { get; set; }
        public int ContractorTypeId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class ProContractorTypesVM : ProContractorTypesGeneralVM
    {
        public int Id { get; set; }
    }
    public class ProContractorTypesGetVM : ProContractorTypesVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string ContractorName { get; set; }
        public int ContractorCode { get; set; }
        public string ContractorTypeName { get; set; }
        public int ContractorTypeCode { get; set; }
    }
}
