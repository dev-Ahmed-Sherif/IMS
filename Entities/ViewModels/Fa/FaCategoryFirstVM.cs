namespace Entities.ViewModels.Fa
{
    public class FaCategoryFirstGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class FaCategoryFirstVM : FaCategoryFirstGeneralVM
    {
        public int Id { get; set; }
    }
    public class FaCategoryFirstGetVM : FaCategoryFirstVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
