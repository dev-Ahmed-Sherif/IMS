using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.TR.Excuted;
using Entities.Models.TR.Instructor;
using Entities.Models.TR.Plan;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.TR
{
    public class TrTrainingCenter : EntityBase
    {
        [StringLength(50)]

        public string Name { get; set; }
        public string Code { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }


        public int CityId { get; set; }

        public virtual HrCity City { get; set; }

        public bool IsActive { get; set; }

        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


        public virtual ICollection<TrInstructor> TrInstructor { get; set; }
        public virtual ICollection<TrTrainingCenterCourse> TrTrainingCenterCourse { get; set; }
        public virtual ICollection<TrClassRoom> TrClassRoom { get; set; }
        public virtual ICollection<TrExcuted> Ex_TrainingCenter { get; set; }
        public virtual ICollection<TrPlan> PlanTrainingCenter { get; set; }
    }
}
