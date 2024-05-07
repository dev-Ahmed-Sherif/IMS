using System;

namespace Entities.ViewModels.TR.Excuted
{
    public class TrExcutedInstructorGeneralVM
    {
        public int ExcutedId { get; set; }
        public int InstructorId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrExcutedInstructorVM : TrExcutedInstructorGeneralVM
    {
        public int Id { get; set; }
    }
    public class TrExcutedInstructorGetVM : TrExcutedInstructorVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        //header data
        public int? HeaderHeaderDays { get; set; }
        public DateTime? HeaderStartDate { get; set; }
        public DateTime? HeaderEndDate { get; set; }
        public int? HeaderNoTrainee { get; set; }
        public int? HeaderNoTraineeCorporate { get; set; }
        public int? HeaderNoTraineeTotal { get; set; }
        public string HeaderStatus { get; set; }
        public decimal? HeaderCostplaned { get; set; }
        public decimal? HeaderCost { get; set; }
        public string? HeaderTrainingCenterName { get; set; }
        public string? HeaderClassRoomName { get; set; }
        public string? HeaderFiscalYearName { get; set; }
        public string? HeaderCourseName { get; set; }
        public string? HeaderPurposeName { get; set; }
        public string? HeaderMaterialPurposeName { get; set; }
        public string? HeaderDelegateName { get; set; }
        public string InstructorName { get; set; }
    }
}
