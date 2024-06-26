using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderComitteeMemberViewModels
{
    public class ProTenderCommitteeMemberOutputVM : BaseViewModel
    {

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Notes { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public int TenderCommitteeId { get; set; }

    }
}
