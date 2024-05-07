namespace Entities.ViewModels.STR.WithDraw
{
    public class StrWithDrawSerialGeneralVM
    {
        public int TransactionUserId { get; set; }

        //public int ProductId { get; set; }
        public int ProductserialId { get; set; }
        public int strwithdrawdetailsId { get; set; }
        public int? QTy { get; set; }
        public int? ProductId { get; set; }
    }
    public class StrWithDrawSerialVM : StrWithDrawSerialGeneralVM

    {
        public int Id { get; set; }


    }
    public class StrWithDrawSerialGetVM : StrWithDrawSerialVM

    {
        public string ProductName { get; set; }
        public string CreateUserName { get; set; }

    }
}
