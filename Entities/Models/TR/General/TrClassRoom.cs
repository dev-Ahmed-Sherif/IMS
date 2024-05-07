using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.TR.Excuted;
using Entities.Models.TR.Plan;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.TR
{
    public class TrClassRoom : EntityBase
    {

        [StringLength(50)]
        public int Code { get; set; }

        public string Name { get; set; }

        public int TrainingCenterId { get; set; }

        public virtual TrTrainingCenter TrainingCenter { get; set; }
        public int CityStateId { get; set; }
        public virtual HrCityState CityState { get; set; }
        public string Address { get; set; }

        public string Type { get; set; }
        public int Capacity { get; set; }


        public bool IsActive { get; set; }


        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public virtual ICollection<TrExcuted> Ex_ClassRoom { get; set; }
        public virtual ICollection<TrPlan> TrPlanClassRoom { get; set; }
    }
}
