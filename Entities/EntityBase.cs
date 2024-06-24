using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public virtual int? CreatedByID { get; set; }
        public virtual int? UpdateByID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; }

    }
    public class EntityBaseNotes : EntityBase
    {
        [StringLength(250)]
        public string Notes { get; set; }
    }
}
