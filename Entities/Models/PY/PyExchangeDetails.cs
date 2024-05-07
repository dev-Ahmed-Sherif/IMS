using Entities.Models.HR;
using Entities.Models.PR;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.PY
{
    public class PyExchangeDetails : EntityBase
    {

        [StringLength(50)]

        public decimal Value { get; set; }
        //-------------------------------------------------
        // Relation { PyExchange } +++ { FK => ExChangeId } 
        //-------------------------------------------------
        public int ExChangeId { get; set; }
        public virtual PyExchange ExChange { get; set; }
        //--------------------------------------------------
        // Relation { HrEmployee  } +++ { FK => EmployeeId } 
        //--------------------------------------------------
        public int EmployeeId { get; set; }
        public virtual HrEmployee Employee { get; set; }
        //---------------------------------------------
        // Relation { PyItem  } +++ { FK => PyItemId } 
        //---------------------------------------------
        public int PyItemId { get; set; }
        public virtual PyItem PyItem { get; set; }

        //-----------------------------------------------------------
        // Relation { PrUser  } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


    }
}
