using Entities.Models.STR.Employee;
using Entities.ViewModels.STR.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ExtensionMethods.STR.Employee
{
    public static class StrEmployeeExchangeExtensions
    {
        public static StrEmployeeExchangeGetVM ToStrEmployeeExchangeGetVM(this StrEmployeeExchange n)
        {
            return new StrEmployeeExchangeGetVM
            {
                Id = n.Id,
                No = n.No,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                DestEmployeeId = n.DestEmployeeId,
                DestEmployeeName = n.DestEmployee.Name,
                CostCenterId = n.CostCenterId,
                CostCenterName = n.CostCenter.Name,
                FiscalYearId = n.FiscalYearId,
                fiscalyear = n.Fiscalyear.fiscalyear,
                Date = n.Date,
                Notes = n.Notes,
                Total = n.Total,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                ShortDate = n.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
            };
        }
    }
}
