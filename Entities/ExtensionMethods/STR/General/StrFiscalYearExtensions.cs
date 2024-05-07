using Entities.Models.STR.General;
using Entities.ViewModels.STR.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ExtensionMethods.STR.General
{
    public static class StrFiscalYearExtensions
    {
        public static FiscalYearData ToFiscalYearData(this StrFiscalYear data)
        {
            return new FiscalYearData
            {
                Id = data.Id,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                FiscalYear = data.fiscalyear,
            };
        }
    }
}
