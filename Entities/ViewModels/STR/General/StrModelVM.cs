namespace Entities.ViewModels.STR.General
{
    public class StrModelGeneralVM
    {

        public string Name { get; set; }

        public int VendorId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class StrModelVM : StrModelGeneralVM
    {
        public int Id { get; set; }

    }
    public class StrModelGetVM : StrModelVM
    {
        public string VendorName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }

}
