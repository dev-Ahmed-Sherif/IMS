using Entities.Models.PR;
using Entities.Models.TR.Course;

namespace Entities.Models.TR.General
{
    public class TrBudget : EntityBase
    {
        public int? NoTrainee { get; set; }
        public int? NoHour { get; set; }
        public decimal? InstructorHourFee { get; set; }
        public decimal? InstructorTotalFee { get; set; }
        public decimal? SuperVisingFee { get; set; }
        public decimal? OtherFee { get; set; }
        public decimal? SalaryTotal { get; set; }
        public decimal? SuppliesCost { get; set; }
        public decimal? TransportCost { get; set; }
        public decimal? ServiceTotal { get; set; }
        public decimal? CourseTotal { get; set; }

        //---------------------------------------------------------------------------//
        // Relation Foregin Key { course}
        //---------------------------------------------------------------------------//
        public int? CourseId { get; set; }
        public virtual TrCourse Course { get; set; }
        //-----------------------------------------------------------------------//
        // Relation { PrUser => TrBudget } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

    }
}
