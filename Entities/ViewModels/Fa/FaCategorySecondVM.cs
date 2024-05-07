namespace Entities.ViewModels.Fa
{
    public class FaCategorySecondGeneralVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class FaCategorySecondVM : FaCategorySecondGeneralVM
    {
        public int Id { get; set; }
    }
    public class FaCategorySecondGetVM : FaCategorySecondVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
