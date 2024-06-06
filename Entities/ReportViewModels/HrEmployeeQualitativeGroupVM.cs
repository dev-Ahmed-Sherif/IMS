using Entities.ViewModels.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ReportViewModels
{
    public class HrEmployeeQualitativeGroupVM
    {
        public int QualitativeGroupId { get; set; }
        public string QualitativeGroupName { get; set; }
        public HashSet<EmployeesFinancialDegreesReportVM> EmployeesFinancialDegrees { get; set; } = new();
        public class EmployeesFinancialDegreesReportVM
        {
            public int EmployeeCount { get; set; }
            public string FinancialDegreeName { get; set; }
            public int FinancialDegreeId { get; set; }
        }
        public string ReportDate { get; set; }
    }
}
