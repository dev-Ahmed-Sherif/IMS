using System;

namespace Entities.ViewModels.Pro
{
    public class ProTenderGeneralVM
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int? CityStateId { get; set; }

        public int OperationTypeId { get; set; }

        public int TenderTypeId { get; set; }


        public decimal Value { get; set; }
        public int PlanTypeId { get; set; }


        public string? Period { get; set; }

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
        public int TransactionUserId { get; set; }


    }
    public class ProTenderVM : ProTenderGeneralVM
    {
        public int Id { get; set; }
    }
    public class ProTenderGetVM : ProTenderVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string CityStateName { get; set; }
        public string OperationTypeName { get; set; }
        public int OperationTypeCode { get; set; }
        public string TenderTypeName { get; set; }
        public int PlanTypeCode { get; set; }
        public string PlanTypeName { get; set; }
        public int TenderTypeCode { get; set; }
    }
    public class ProSearchGeneral
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        public string? Code { get; set; }
        public DateTime? Date { get; set; }
        public int? CityStateId { get; set; }

        public int? OperationTypeId { get; set; }

        public int? TenderTypeId { get; set; }


        public decimal? Value { get; set; }
        public int? PlanTypeId { get; set; }
        public string? Period { get; set; }

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
        public int? TransactionUserId { get; set; }




    }
}
