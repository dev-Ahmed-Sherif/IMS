using Entities.Models.PR;
using System.Collections.Generic;

namespace Entities.Models.TR.Course
{
    public class TrTrack : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        // Relation { PrUser => track } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        public virtual ICollection<TrTrackDetails> Tr_TrackDetails { get; set; }

    }
}
