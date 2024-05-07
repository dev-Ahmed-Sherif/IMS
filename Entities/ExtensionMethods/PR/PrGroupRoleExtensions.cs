using Entities.Models.PR;
using Entities.ViewModels.PR;

namespace Entities.ExtensionMethods.PR
{
    public static class PrGroupRoleExtensions
    {
        public static PrGroupRoleGetVM ToPrGroupRoleGetVM(this PrGroupRole n)
        {
            return new PrGroupRoleGetVM
            {
                Id = n.Id,
                GroupId = n.GroupId,
                RoleId = n.RoleId,
                CanInsert = n.CanInsert,
                CanEdit = n.CanEdit,
                CanDelete = n.CanDelete,
                CanPrint = n.CanPrint,
                CanView = n.CanView,
                GroupName = n.PR_Group?.Name,
                RoleName = n.PR_Role?.Name,
                CreateUserName = n.CreatedBy?.Name,
                TransactionUserId = n.CreatedBy?.Id ?? 1,
            };

        }
    }
}
