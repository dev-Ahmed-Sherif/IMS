namespace Entities.ViewModels.PR
{
    public class PrGroupRoleGeneralVM
    {

        public int GroupId { get; set; }
        public int RoleId { get; set; }
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanInsert { get; set; }
        public bool CanPrint { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class PrGroupRoleVM : PrGroupRoleGeneralVM
    {
        public int Id { get; set; }

    }
    public class PrGroupRoleGetVM : PrGroupRoleVM
    {
        public string GroupName { get; set; }
        public string RoleName { get; set; }
        public string CreateUserName { get; set; }

    }
    public class PrGroupRoleWithRoleVM : PrGroupRoleVM
    {

        //List of Role name and Role_Description
        public string Role_Name { get; set; }
        public string Role_Description { get; set; }
    }
}
