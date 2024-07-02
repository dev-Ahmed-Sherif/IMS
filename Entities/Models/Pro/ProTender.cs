using Entities.Models.HR;
using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Pro
{
    public class ProTender : EntityBase
    {
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(350)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int? CityStateId { get; set; }
        public virtual HrCityState CityState { get; set; }
        public int OperationTypeId { get; set; }
        public virtual ProOperationType OperationType { get; set; }
        public int BiddingMethodId { get; set; }
        [ForeignKey(nameof(BiddingMethodId))]
        public virtual ProTenderBiddingMethod BiddingMethod { get; set; }

        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public virtual ProType Type { get; set; }

        public decimal Value { get; set; }
        public int PlanTypeId { get; set; }
        public virtual ProPlanType PlanType { get; set; }
        [StringLength(50)]
        public string Period { get; set; }

        public decimal? TORValue { get; set; }
        public decimal? TenderBondValue { get; set; }
        public DateTime? TechnicalOpeningDate { get; set; }
        public DateTime? TechnicalSelectionDate { get; set; }
        public DateTime? FinancialOpeningDate { get; set; }
        public DateTime? FinancialSelectionDate { get; set; }

        public decimal? EstimatingValue { get; set; }
        public decimal? AwardValue { get; set; }
        public DateTime? AwardLetterDate { get; set; }
        public DateTime? WorkOrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }

        //-----------------------------------------------------------------------//
        // Relation { PrUser => AddReceipt } +++ {View Model => TransactionUserId} 
        //-----------------------------------------------------------------------//
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }


    }
}
