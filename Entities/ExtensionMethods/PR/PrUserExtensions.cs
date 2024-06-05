using Entities.Models.PR;
using Entities.ViewModels.PR;

namespace Entities.ExtensionMethods.PR
{
    public static class PrUserExtensions
    {
        public static PrUserVM ToPrUserVM(this PrUser n)
        {
            return new PrUserVM
            {
                Id = n.Id,
                Name = n.Name,
                Password = n.Password,
                IsActive = n.IsActive,
                TransactionUserId = n.CreatedByID,
                EmployeeId = n.EmployeeId,
               EmployeeName=n.Employee.Name,
            };
        }
    }
}
