using Microsoft.AspNetCore.Http;

namespace Entities.ViewModels.Pro
{
    public class ProVendorGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string? TheLevel { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? CityId { get; set; }
        public int? CityStateId { get; set; }
        public string? Address { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class ProVendorVM : ProVendorGeneralVM
    {
        public int Id { get; set; }
    }
    public class ProVendorGetVM : ProVendorVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string CityName { get; set; }
        public string CityStateName { get; set; }
    }
    public class VendorSearchGeneral
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Code { get; set; }
        public string? TheLevel { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? CityId { get; set; }
        public int? CityStateId { get; set; }
        public string? Address { get; set; }
    }
}
