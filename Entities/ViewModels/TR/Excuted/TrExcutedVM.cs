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

    public class TrExcutedGetSearchVM : TrExcutedGetVM
    {

        public string? ShortStartDate { get; set; }
        public string? ShortEndDate { get; set; }
        public string ReportDate { get; set; }
        public string Section { get; set; }

    }
    public class TrExcutedSearch
    {
        public string? Days { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? NoTrainee { get; set; }
        public string? NoTraineeCorporate { get; set; }
        public string? NoTraineeTotal { get; set; }
        public string? Status { get; set; }
        public string? Costplaned { get; set; }
        public string? Cost { get; set; }
        public string? DelegateId { get; set; }
        public string? TrainingCenterId { get; set; }
        public string? ClassRoomId { get; set; }
        public string? FiscalYearId { get; set; }
        public string? CourseId { get; set; }
        public string? PurposeId { get; set; }
        public string? MaterialPurposeId { get; set; }
        public string? MaterialPurposeName { get; set; }
        public string TransactionUserId { get; set; }

    }
    public class TrExcutedReport : TrExcutedSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }
    }

}
