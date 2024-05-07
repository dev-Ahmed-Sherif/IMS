using Entities.Models.FI.Entry;
using Entities.Models.PR;
using System.Collections.Generic;

namespace Entities.Models.FI
{
    public class FiEntrySourceType : EntityBase
    {
        public string Name { get; set; }
        public int EntrySourceId { get; set; }
        public virtual FiEntrySource EntrySource { get; set; }
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public virtual ICollection<FiEntry> FiEntry { get; set; }
    }
}
