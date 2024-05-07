namespace Entities.ViewModels.FI.Entry
{
    public class FiEntrySourceTypeGeneralVM
    {
        public string Name { get; set; }
        public int EntrySourceId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class FiEntrySourceTypeVM : FiEntrySourceTypeGeneralVM
    {
        public int Id { get; set; }
    }
    public class FiEntrySourceTypeGetVM : FiEntrySourceTypeVM
    {
        public string FiEntrySourceName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
