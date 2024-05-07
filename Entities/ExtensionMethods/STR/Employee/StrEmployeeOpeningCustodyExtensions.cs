using Entities.Models.STR.Employee;
using Entities.ViewModels.STR.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ExtensionMethods.STR.Employee
{
    public static class StrEmployeeOpeningCustodyExtensions
    {
        public static StrEmployeeOpeningCustodyGetVM ToStrEmployeeOpeningCustodyGetVM(this StrEmployeeOpeningCustody n)
        {
            return new StrEmployeeOpeningCustodyGetVM
            {
                Id = n.Id,
                No = n.No,
                Date = n.Date,
                Total = n.Total,
                Notes = n.Notes,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.HR_Employee?.Name,
                CostCenterName = n.CostCenter?.Name,
                CostCenterId = n.CostCenterId,
                CreateUserName = n.CreatedBy?.Name,
                FiscalYearId = n.FiscalYearId,
                fiscalyear = n.Fiscalyear?.fiscalyear,
                TransactionUserId = n.CreatedBy.Id,
            };
        }
    }
}
