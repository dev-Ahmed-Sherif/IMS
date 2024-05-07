using Entities.Models.PR;
using Entities.Models.STR.General;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.PY
{
    public class PyExchange : EntityBase
    {
        [StringLength(50)]


        public int No { get; set; }
        public string Name { get; set; }
        public int FiscalYearId { get; set; }
        public virtual StrFiscalYear FiscalYear { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        //-----------------------------------------------------------
        // Relation { PrUser  } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }



    }
}
