using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.VL.VlStaff
{
    public class VlStaffOutputVM:BaseViewModel
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
