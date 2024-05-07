
using Entities.Models.PR;
using Entities.Models.TR.Course;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.TR
{
    public class TrTrainingCenterCourse : EntityBase
    {


        public int CourseId { get; set; }

        public virtual TrCourse Course { get; set; }

        public int TrainingCenterId { get; set; }

        public virtual TrTrainingCenter TrainingCenter { get; set; }

        [StringLength(50)]
        public string Rating { get; set; }

        public decimal Price { get; set; }

        [StringLength(250)]
        public string Notes { get; set; }


        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
