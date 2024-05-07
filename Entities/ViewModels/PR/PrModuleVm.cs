namespace Entities.ViewModels.PR
{
    public class PrModuleGeneralVM
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class PrModuleVM : PrModuleGeneralVM
    {
        public int Id { get; set; }
    }
    public class PrModuleGetVM : PrModuleVM
    {
        public string CreateUserName { get; set; }
    }
}
