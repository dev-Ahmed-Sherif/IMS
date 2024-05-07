using Entities.Models.HR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.PR
{
    public class PrUser : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(256)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<PrUserGroup> PR_User_Group { get; set; }
        public virtual ICollection<PrUserGroup> PrUserGroupCreated { get; set; }
        public int? EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }
        // public List<StrUserStore> StrUser_Store { get; set; }

    }
}
