using Entities.Models.STR.Product;
using Entities.Models.STR.StoreOpen;

namespace Entities.ViewModels.STR.StoreOpen
{
    public class StrOpeningStockDetailsSerialGereralVM
    {
        public int OpeningStockDetailId { get; set; }
        public int ProductSerialId { get; set; }
        public int? QTy { get; set; }
        public int? ProductId { get; set; }
        public StrOpeningStockDetails OpeningStockDetails { get; set; }
        public StrProductSerial ProductSerial { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class StrOpeningStockDetailsSerialVM : StrOpeningStockDetailsSerialGereralVM
    {
        public int Id { get; set; }
    }
    public class StrOpeningStockDetailsSerialGetVM : StrOpeningStockDetailsSerialVM
    {
        public string OpeningStockDetailName { get; set; }
        public string ProductName { get; set; }
        public string CreatorName { get; set; }
        public string EditorName { get; set; }
    }
}
