using System;

namespace Entities.ViewModels.TR.Excuted
{
    public class TrExcutedGeneralVM
    {
        public int? Days { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? NoTrainee { get; set; }
        public int? NoTraineeCorporate { get; set; }
        public int? NoTraineeTotal { get; set; }
        public string Status { get; set; }
        public decimal? Costplaned { get; set; }
        public decimal? Cost { get; set; }
        public int? DelegateId { get; set; }
        public int? TrainingCenterId { get; set; }
        public int? ClassRoomId { get; set; }
        public int? FiscalYearId { get; set; }
        public int? CourseId { get; set; }
        public int? PurposeId { get; set; }
        public int? MaterialPurposeId { get; set; }
        public string? MaterialPurposeName { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrExcutedVM : TrExcutedGeneralVM
    {
        public int Id { get; set; }
    }
    public class TrExcutedGetVM : TrExcutedVM
    {
        public string FiscalYearName { get; set; }
        public string CourseName { get; set; }
        public string PurposeName { get; set; }
        public string ClassRoomName { get; set; }
        public string TrainingCenterName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string DelegateName { get; set; }
    }
}
