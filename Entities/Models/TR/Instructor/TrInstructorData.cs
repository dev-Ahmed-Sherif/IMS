using Entities.Models.HR;
using Entities.Models.PR;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.TR.Instructor
{
    public class TrInstructorData : EntityBase
    {
        [StringLength(100)]
        public string Name { get; set; }

        public int Code { get; set; }

        [StringLength(100)]
        public string phone { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Position { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(100)]
        public string Gender { get; set; }
        public int? CityId { get; set; }
        public virtual HrCity City { get; set; }
        //--------------------------------------------------------------------------------//
        // Relation { PrUser => TrInstructorData } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
