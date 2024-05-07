using Entities.Models.PR;
using System.Collections.Generic;

namespace Entities.Models.FI
{
    public class FiEntrySource : EntityBase
    {
        public string Name { get; set; }
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public virtual ICollection<FiEntrySourceType> Fi_Entry_Source_Type { get; set; }
    }
}
