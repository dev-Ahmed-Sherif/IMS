using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.STR.General;
using Entities.Models.TR.Course;
using Entities.Models.TR.General;
using System;
using System.Collections.Generic;

namespace Entities.Models.TR.Excuted
{
    public class TrExcuted : EntityBase
    {
        public int? Days { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? NoTrainee { get; set; }
        public int? NoTraineeCorporate { get; set; }
        public int? NoTraineeTotal { get; set; }
        public string Status { get; set; }
        public decimal? Costplaned { get; set; }
        public decimal? Cost { get; set; }

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

        public int? MaterialPurposeId { get; set; }
        public virtual TrPurpose MaterialPurpose { get; set; }
        public int? DelegateId { get; set; }
        public virtual HrEmployee Delegate { get; set; }

        // Relation { PrUser => TrBudget } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public virtual ICollection<TrExcutedTrainee> TrExcutedTrainee { get; set; }
        public virtual ICollection<TrExcutedPosition> TrExcutedPosition { get; set; }
        public virtual ICollection<TrExcutedInstructor> TrExcutedInstructor { get; set; }
        public virtual ICollection<TrExcutedFinancier> TrExcutedFinancier { get; set; }
    }
}
