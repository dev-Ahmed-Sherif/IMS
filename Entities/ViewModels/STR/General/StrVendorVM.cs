namespace Entities.ViewModels.STR.General
{
    public class StrVendorGeneralVM
    {

        public string Name { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class StrVendorVM : StrVendorGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrVendorGetVM : StrVendorVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }


}
