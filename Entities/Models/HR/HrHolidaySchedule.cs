using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;
namespace Entities.Models.HR
{
    public class HrHolidaySchedule : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------

        public int Year { get; set; }
        public int HolidayId { get; set; }
        public virtual HrHoliday Holiday { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }





    }
}
