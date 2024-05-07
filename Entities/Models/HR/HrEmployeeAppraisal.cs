using Entities.Models.HR;
using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class HrEmployeeAppraisal : EntityBase
    {



        public DateTime Date { get; set; }

        public int EmployeeId { get; set; }

        public virtual HrEmployee Employee { get; set; }
        public int Appraisal { get; set; }
        [StringLength(200)]
        public string Attachment { get; set; }


        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


        // Navigation Primary


    }
}
