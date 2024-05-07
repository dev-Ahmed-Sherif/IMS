using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.STR.Add;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Pro
{
    public class ProSeller : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public int Code { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public int? CityId { get; set; }
        public virtual HrCity City { get; set; }
        public int? CityStateId { get; set; }
        public virtual HrCityState CityState { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(50)]
        public string CommericalRegister { get; set; }
        [StringLength(50)]
        public string TaxCard { get; set; }
        //Navigation Primary
        public virtual ICollection<StrAdd> STR_Add { get; set; }
        //--------------------------------------------------------------------------
        // Relation { PrUser => AccountParent } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        //navigation
        public virtual ICollection<ProSellerTypes> ProSellerTypes { get; set; }

    }
}
