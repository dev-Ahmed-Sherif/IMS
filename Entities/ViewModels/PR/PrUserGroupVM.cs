namespace Entities.ViewModels.PR
{
    public class PrUserGroupGeneralVM
    {

        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int? TransactionUserId { get; set; }
    }
    public class PrUserGroupVM : PrUserGroupGeneralVM
    {
        public int Id { get; set; }
    }
    public class PrUserGroupWithGroupVM : PrUserGroupVM
    {

        //List of Role name and Role_Description
        public string Group_Name { get; set; }
        public string Group_Description { get; set; }
        public string UserName { get; set; }
        //public string ModuleName { get; set; }
    }

}
