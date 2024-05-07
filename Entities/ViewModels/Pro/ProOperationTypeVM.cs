namespace Entities.ViewModels.Pro
{
    public class ProOperationTypeGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class ProOperationTypeVM : ProOperationTypeGeneralVM
    {
        public int Id { get; set; }
    }
    public class ProOperationTypeGetVM : ProOperationTypeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
