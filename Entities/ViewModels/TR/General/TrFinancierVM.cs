namespace Entities.ViewModels.TR.General
{
    public class TrFinancierGeneralVM
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrFinancierVM : TrFinancierGeneralVM
    {
        public int Id { get; set; }
    }
    public class TrFinancierGetVM : TrFinancierVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }

}
