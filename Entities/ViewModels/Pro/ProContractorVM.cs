namespace Entities.ViewModels.Pro
{
    public class ProContractorGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string? TheLevel { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? CityId { get; set; }
        public int? CityStateId { get; set; }
        public string? Address { get; set; }
        public string IndusterialRegister { get; set; }
        public string TaxCard { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class ProContractorVM : ProContractorGeneralVM
    {
        public int Id { get; set; }
    }
    public class ProContractorGetVM : ProContractorVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string CityName { get; set; }
        public string CityStateName { get; set; }
    }
    public class ContractorSearchGeneral
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Code { get; set; }
        public string? TheLevel { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? CityId { get; set; }
        public int? CityStateId { get; set; }

        public string? IndusterialRegister { get; set; }
    }
}
