using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.TR.Excuted;
using Entities.Models.TR.Plan;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.TR.Instructor
{
    public class TrInstructor : EntityBase
    {
        [StringLength(50)]

        public string Type { get; set; }
        public int? EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }
        public int? InstructorDataId { get; set; }
        public virtual TrInstructorData InstructorData { get; set; }
        public int? TrainingCenterId { get; set; }
        public virtual TrTrainingCenter Trainingcenter { get; set; }
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public virtual ICollection<TrInstructorCourse> Tr_InstructorCourse { get; set; }
        public virtual ICollection<TrExcutedInstructor> TrExcutedInstructor { get; set; }
        public virtual ICollection<TrPlanInstructor> TrPlanInstructor { get; set; }
    }
}
