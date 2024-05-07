using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.HR
{
    public class HrEmployeeQualification : EntityBase
    {

        [StringLength(50)]

        public DateTime Date { get; set; }
        public int QualificationId { get; set; }
        public virtual HrQualification Qualification { get; set; }
        public int QualificationLevelId { get; set; }
        public virtual HrQualificationLevel QualificationLevel { get; set; }
        public int SpecializationId { get; set; }
        public virtual HrSpecialization Specialization { get; set; }
        public int EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }
        public string Attachment { get; set; }
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


        // Navigation Primary




    }
}
