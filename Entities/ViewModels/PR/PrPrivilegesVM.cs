namespace Entities.ViewModels.PR
{
    public class PrPrivilegesGeneralVM
    {
        public string Name { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class PrPrivilegesVM : PrPrivilegesGeneralVM
    {
        public int Id { get; set; }

    }
    public class PrPrivilegesGetVM : PrPrivilegesVM
    {
        public string CreateUserName { get; set; }

    }
}
