using System.Collections.Generic;

namespace Entities.Models.FI.Journal
{
    public class FiJournalType
    {
        public int Id { get; set; }
        public string JournalType { get; set; }
        public virtual ICollection<FiJournal> FiJournals { get; set; }
    }
}
