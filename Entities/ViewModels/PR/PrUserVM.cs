using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Entities.ViewModels.PR
{
    public class PrUserGeneralVM
    {

        public string Name { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public int? TransactionUserId { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class PrUserVM : PrUserGeneralVM
    {
        public int Id { get; set; }
        [AllowNull]
        public int? EmployeeId { get; set; }
        //public List<PrGroupRoleVM> Roles { get; set; }

    }
    public class PR_User_With_GroupVM : PrUserVM
    {
        //List of User_Groups model
        public List<PrUserGroupWithGroupVM> User_Group { get; set; }
    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }

    public class UserFilter
    {
        [AllowNull]
        public int? Id { get; set; }
        [AllowNull]
        public int? EmployeeId { get; set; }
        [AllowNull]
        public string Name { get; set; }
        [AllowNull]
        public bool? IsAdmin { get; set; }
        [AllowNull]
        public bool? IsActive { get; set; }
        [AllowNull]
        public int? UserGroup { get; set;}
        [AllowNull]
        public int? UserGroupCreated { get; set; }
    }
}
