namespace Entities.ViewModels.STR.AddDetails
{
    public class StrWithDrawTypeGeneralVM
    {

        public string Name { get; set; }
        public string Destination { get; set; }
        public int? AccountId { get; set; }
        public int TransactionUserId { get; set; }

    }

    public class StrWithDrawTypeVM : StrWithDrawTypeGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrWithDrawTypeGetVM : StrWithDrawTypeVM
    {
        public string AccountName { get; set; }
        public string CreateUserName { get; set; }
    }

}

