namespace Entities.ViewModels.STR.StoreOpen
{
    public class StrStoreGeneralVM
    {
        public string Name { get; set; }
        public int TransactionUserId { get; set; }
        public int Code { get; set; }
        public int? StorekeeperId { get; set; }
        public int? SectionId { get; set; }

    }
    public class StrStoreVM : StrStoreGeneralVM
    {
        public int Id { get; set; }


    }
    public class StrStoreGetVM : StrStoreVM
    {
        public string CreateUserName { get; set; }
        public string StorekeeperName { get; set; }
        public string Section { get; set; }

    }
    public class StoreSearch
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? Code { get; set; }
        public int? StorekeeperId { get; set; }
        public int? SectionId { get; set; }

    }
}
