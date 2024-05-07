namespace Entities.ViewModels.Cc
{
    public class CcActivityGeneralVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class CcActivityVM : CcActivityGeneralVM
    {
        public int Id { get; set; }
    }
    public class CcActivityGetVM : CcActivityVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
