using System;

namespace Entities.ViewModels.TR.Plan
{
    public class TrPlanGeneralVM
    {
        public string Tittle { get; set; }
        public int? Days { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? NoTrainee { get; set; }
        public int? TrainingCenterId { get; set; }
        public int? ClassRoomId { get; set; }
        public int? FiscalYearId { get; set; }
        public int? CourseId { get; set; }
        public int? PurposeId { get; set; }
        public int? FinanacielDegreeId { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class TrPlanVM : TrPlanGeneralVM
    {
        public int Id { get; set; }
    }

    public class TrPlanGetVM : TrPlanVM
    {
        public string FiscalYearName { get; set; }
        public string CourseName { get; set; }
        public string PurposeName { get; set; }
        public string ClassRoomName { get; set; }
        public string TrainingCenterName { get; set; }
        public string FinanacielDegreeName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }

}
