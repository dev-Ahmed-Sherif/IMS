using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.VL.VlStaff
{
    public class VlStaffInputVM:BaseViewModel
    {
        public int PositionId { get; set; }
        public int StatusId { get; set; }
        public int EmployeeId { get; set; }

    }
}
