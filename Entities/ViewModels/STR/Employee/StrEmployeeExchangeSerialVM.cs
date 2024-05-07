using Entities.Models.STR.Employee;
using Entities.Models.STR.Product;

namespace Entities.ViewModels.STR.Employee
{
    public class StrEmployeeExchangeSerialGeneralVM
    {
        public int EmployeeExchangeDetailId { get; set; }
        public StrEmployeeExchangeDetails ExchangeDetails { get; set; }
        public int ProductSerialId { get; set; }
        public StrProductSerial ProductSerial { get; set; }
        public int? QTy { get; set; }
        public int? ProductId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class StrEmployeeExchangeSerialVM : StrEmployeeExchangeSerialGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrEmployeeExchangeSerialGetVM : StrEmployeeExchangeSerialVM
    {
        public string EmployeeExchangeName { get; set; }
        public string ProductName { get; set; }
        public string CreatorName { get; set; }
        public string EditorName { get; set; }
    }
}
