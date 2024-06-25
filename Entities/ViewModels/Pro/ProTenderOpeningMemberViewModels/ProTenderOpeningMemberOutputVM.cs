using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderOpeningMemberViewModels
{
    public class ProTenderOpeningMemberOutputVM : BaseViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Notes { get; set; }
        public int TenderOpeningId { get; set; }
        public string TenderOpeningName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
