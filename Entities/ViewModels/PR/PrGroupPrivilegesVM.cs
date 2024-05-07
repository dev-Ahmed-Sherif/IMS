namespace Entities.ViewModels.PR
{
    public class PrGroupPrivilegesGeneralVM
    {
        public int GroupId { get; set; }

        public int PrivilegesId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class PrGroupPrivilegesVM : PrGroupPrivilegesGeneralVM
    {
        public int Id { get; set; }

    }
    public class PrGroupPrivilegesGetVM : PrGroupPrivilegesVM
    {

        public string GroupName { get; set; }
        public string PrivilegesName { get; set; }
        public string CreateUserName { get; set; }

    }
}
