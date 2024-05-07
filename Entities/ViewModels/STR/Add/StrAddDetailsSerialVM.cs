using Entities.Models.STR.Add;
using Entities.Models.STR.Product;

namespace Entities.ViewModels.STR.AddDetails
{
    public class StrAddDetailsSerialGeneralVM
    {
        public int AddDetailsId { get; set; }
        public int ProductSerialId { get; set; }
        public StrAddDetails AddDetails { get; set; }
        public int? QTy { get; set; }
        public int? ProductId { get; set; }
        public StrProductSerial ProductSerial { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class StrAddDetailsSerialVM : StrAddDetailsSerialGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrAddDetailsSerialGetVM : StrAddDetailsSerialVM
    {
        public string ItemName { get; set; }
        public string ProductName { get; set; }
        public string CreatorName { get; set; }
        public string EditorName { get; set; }
    }
}
