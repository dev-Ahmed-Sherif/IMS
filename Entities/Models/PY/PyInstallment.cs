using Entities.Models.HR;
using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.PY
{
    public class PyInstallment : EntityBase
    {

        [StringLength(50)]

        public int No { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Value { get; set; }
        public decimal InstallmentValue { get; set; }
        public int InstallmentNo { get; set; }
        public decimal PaiedSum { get; set; }
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
