namespace Entities.ViewModels.FI.Entry
{
    public class FiEntrySourceGeneralVM
    {
        public string Name { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class FiEntrySourceVM : FiEntrySourceGeneralVM
    {
        public int Id { get; set; }
    }
    public class FiEntrySourceGetVM : FiEntrySourceVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
