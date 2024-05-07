using Entities.Models.HR;
using Entities.Models.PR;
using Entities.ViewModels.TR.General;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.TR
{
    public class TrTrainee : EntityBase
    {


        [StringLength(50)]

        public string Name { get; set; }
        public string Code { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string NationalId { get; set; }

        public int? CityId { get; set; }

        public virtual HrCity City { get; set; }
        public int? CityStateId { get; set; }

        public virtual HrCityState CityState { get; set; }
        public int? CorporationCLientId { get; set; }
        public virtual TrCorporateCLient CorporationCLient { get; set; }





        //----------------------------------------------------------------------
        // Relation { PrUser => TrTrainee } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }

        //public List<TrTraineeData> TrTraineeData { get; set; }



    }
}
