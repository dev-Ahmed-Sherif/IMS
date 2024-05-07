using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.STR.General;
using Entities.Models.TR.Course;
using Entities.Models.TR.General;
using System;
using System.Collections.Generic;

namespace Entities.Models.TR.Plan
{
    public class TrPlan : EntityBase
    {
        public string Tittle { get; set; }
        public int? Days { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? NoTrainee { get; set; }
        public int? TrainingCenterId { get; set; }
        public virtual TrTrainingCenter TrainingCenter { get; set; }
        public int? ClassRoomId { get; set; }
        public virtual TrClassRoom ClassRoom { get; set; }
        public int? FiscalYearId { get; set; }
        public virtual StrFiscalYear FiscalYear { get; set; }
        public int? CourseId { get; set; }
        public virtual TrCourse Course { get; set; }
        public int? PurposeId { get; set; }
        public virtual TrPurpose Purpose { get; set; }
        public int? FinanacielDegreeId { get; set; }
        public virtual HrFinancialDegree FinanacielDegree { get; set; }
        // Relation { PrUser => TrBudget } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public virtual ICollection<TrPlanPosition> TrPlanPosition { get; set; }
        public virtual ICollection<TrPlanInstructor> TrPlanInstructor { get; set; }
        public virtual ICollection<TrPlanFinancier> TrPlanFinancier { get; set; }
    }
}
