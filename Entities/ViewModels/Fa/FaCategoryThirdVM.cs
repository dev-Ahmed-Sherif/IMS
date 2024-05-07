namespace Entities.ViewModels.Fa
{
    public class FaCategoryThirdGeneralVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class FaCategoryThirdVM : FaCategoryThirdGeneralVM
    {
        public int Id { get; set; }
    }
    public class FaCategoryThirdGetVM : FaCategoryThirdVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
