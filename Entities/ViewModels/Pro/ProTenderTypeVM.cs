namespace Entities.ViewModels.Pro
{
    public class ProTenderTypeGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class ProTenderTypeVM : ProTenderTypeGeneralVM
    {
        public int Id { get; set; }

    }
    public class ProTenderTypeGetVM : ProTenderTypeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
