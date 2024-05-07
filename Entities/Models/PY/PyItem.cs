using Entities.Models.PR;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.PY
{
    public class PyItem : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public string Manner { get; set; }
        public string Type { get; set; }
        public string CalcType { get; set; }
        public string Status { get; set; }
        public string Party { get; set; }
        public string ResetType { get; set; }
        public string Equation { get; set; }

        public int Code { get; set; }
        public int Round { get; set; }

        public decimal Value { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public decimal ResetValue { get; set; }

        public bool Visibility { get; set; }

        //------------------------------------------------------
        // Relation { PyItemCategory  } +++ { FK => CategoryId } 
        //------------------------------------------------------
        public int CategoryId { get; set; }
        public virtual PyItemCategory Category { get; set; }

        //-----------------------------------------------------------
        // Relation { PrUser  } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }





    }
}
