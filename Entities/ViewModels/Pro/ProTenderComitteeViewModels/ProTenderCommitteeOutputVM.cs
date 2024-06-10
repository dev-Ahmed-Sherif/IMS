using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderComitteeViewModels
{
    public class ProTenderCommitteeOutputVM:BaseViewModel
    {
  
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Close { get; set; }
    
        public string Notes { get; set; }
   
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public int TenderId { get; set; }
        public string TenderName { get; set; }
    }
}
