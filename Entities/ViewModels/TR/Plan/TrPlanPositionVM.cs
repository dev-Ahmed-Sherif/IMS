using System;

namespace Entities.ViewModels.TR.Plan
{
    public class TrPlanPositionGeneralVM
    {
        public int PlanId { get; set; }
        public int PositionId { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class TrPlanPositionVM : TrPlanPositionGeneralVM
    {
        public int Id { get; set; }


    }
    public class TrPlanPositionGetVM : TrPlanPositionVM
    {
        public string PositionName { get; set; }
        public string PlanTittle { get; set; }

        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
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
