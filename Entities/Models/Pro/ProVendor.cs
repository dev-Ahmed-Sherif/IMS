using Entities.Models.HR;
using Entities.Models.PR;
using Entities.Models.STR.Add;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Pro
{
    [Table("ProVendors")]
    public class ProSeller : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public int Code { get; set; }
        [StringLength(50)]
        public string TheLevel { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string TaxCard { get; set; }
        public int? CityId { get; set; }
        public virtual HrCity City { get; set; }
        public int? CityStateId { get; set; }
        public virtual HrCityState CityState { get; set; }
        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string IndusterialRegister { get; set; }

        [StringLength(50)]
        public string CommericalRegister { get; set; }

        public string UnionCardUrl { get; set; }
        public string AddedValueTaxUrl { get; set; }
        //--------------------------------------------------------------------------
        // Relation { PrUser => AccountParent } +++ {View Model => TransactionUserId} 
        //--------------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        //navigation
        //Navigation Primary
        public virtual ICollection<ProVendorsTypes> ProVendorTypes { get; set; }
        public virtual ICollection<StrAdd> STR_Add { get; set; }
        public virtual ICollection<ProVendorAttachment> Attachments { get; set; }
    }
}
