using System;

namespace Entities.ViewModels.TR.Plan
{
    public class TrPlanFinancierGeneralVM
    {
        public int? PlanId { get; set; }
        public int? FinancierId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrPlanFinancierVM : TrPlanFinancierGeneralVM
    {
        public int Id { get; set; }

    }
    public class TrPlanFinancierGetVM : TrPlanFinancierVM
    {
        public string CreateUserName { get; set; }
        public string PlanName { get; set; }
        public string FinancierName { get; set; }
        //add header Data
        public string HeaderTittle { get; set; }
        public int? HeaderDays { get; set; }
        public DateTime? HeaderStartDate { get; set; }
        public DateTime? HeaderEndDate { get; set; }
        public int? HeaderNoTrainee { get; set; }
        public string? HeaderTrainingCenterName { get; set; }
        public string? HeaderClassRoomName { get; set; }
        public string? HeaderFiscalYearName { get; set; }
        public string? HeaderCourseName { get; set; }
        public string? HeaderPurposeName { get; set; }
        public string? HeaderFinanacielDegreeName { get; set; }
    }
}
