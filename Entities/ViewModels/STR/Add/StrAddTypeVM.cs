namespace Entities.ViewModels.STR.AddDetails
{
    public class StrAddTypeGeneralVM
    {

        public string Name { get; set; }
        public string Source { get; set; }
        public int? AccountId { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class StrAddTypeVM : StrAddTypeGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrAddTypeGetVM : StrAddTypeVM
    {
        public string AccountName { get; set; }
        public string CreateUserName { get; set; }
    }
}
