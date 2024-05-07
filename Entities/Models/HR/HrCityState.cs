using Entities.Models.PR;
using Entities.Models.Pro;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.HR
{
    public class HrCityState : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }

        public int CityId { get; set; }
        public virtual HrCity City { get; set; }

        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


        //--------------------------
        //Navigation
        //--------------------------------
        public virtual ICollection<ProTender> ProTender { get; set; }

        public virtual ICollection<ProSeller> ProSeller { get; set; }
        //navigation
        public virtual ICollection<ProContractorTypes> ProContractorTypes { get; set; }


    }
}
