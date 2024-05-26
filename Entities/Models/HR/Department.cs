using Entities.Models.HR;
using Entities.Models.PR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Department : EntityBase
    {
        [StringLength(100)]
        public string Name { get; set; }
        public int Code { get; set; }
        public int GeneralDepartmentId { get; set; }
        public virtual GeneralDepartment generaldepartment { get; set; }
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public virtual ICollection<HrEmployee> HREmployees { get; set; }
    }
}
