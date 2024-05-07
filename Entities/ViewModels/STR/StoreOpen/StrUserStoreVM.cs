namespace Entities.ViewModels.STR.StoreOpen
{
    public class StrUserStoreGeneralVM
    {
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class StrUserStoreVM : StrUserStoreGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrUserStoreGetVM : StrUserStoreVM
    {
        public string UserName { get; set; }
        public string StoreName { get; set; }
        public string CreateUserName { get; set; }


    }
}
