using Entities.Models.STR.Employee;
using Entities.Models.STR.Product;

namespace Entities.ViewModels.STR.Employee
{
    public class StrEmployeeOpeningCustodySerialGeneralVM
    {
        public int EmployeeOpeningCustodyDetailId { get; set; }
        public int ProductSerialId { get; set; }
        public int? QTy { get; set; }
        public int? ProductId { get; set; }
        public StrEmployeeOpeningCustodyDetails OpeningCustodyDetails { get; set; }
        public StrProductSerial ProductSerial { get; set; }
        public int TransactionUserId { get; set; }
    }

    public class StrEmployeeOpeningCustodySerialVM : StrEmployeeOpeningCustodySerialGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrEmployeeOpeningCustodySerialGetVM : StrEmployeeOpeningCustodySerialVM
    {
        public string EmployeeOpeningCustodyName { get; set; }
        public string ProductName { get; set; }
        public string CreatorName { get; set; }
        public string EditorName { get; set; }
    }
}
