namespace Entities.ViewModels.Pro
{
    public class ProContractorTypeGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class ProContractorTypeVM : ProContractorTypeGeneralVM
    {
        public int Id { get; set; }

    }
    public class ProContractorTypeGetVM : ProContractorTypeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
