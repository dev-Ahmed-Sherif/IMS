namespace Entities.ViewModels.PR
{
    public class PrRoleGeneralVM
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int ModuleId { get; set; }


        public int TransactionUserId { get; set; }

    }
    public class PrRoleVM : PrRoleGeneralVM
    {
        public int Id { get; set; }

    }
    public class PrRoleGetVM : PrRoleVM
    {
        public string CreateUserName { get; set; }
        public string ModuleName { get; set; }
    }
}
