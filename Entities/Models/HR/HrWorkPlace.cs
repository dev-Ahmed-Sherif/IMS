using Entities.Models.PR;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.HR
{
    public class HrWorkPlace : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public int CityStateId { get; set; }
        public virtual HrCityState CityState { get; set; }
        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        // Navigation Primary




    }
}
