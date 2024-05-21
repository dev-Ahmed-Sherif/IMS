namespace Entities.ViewModels.TR.Instructor
{
    public class TrInstructorGeneralVM
    {
        public string Type { get; set; }
        public int? EmployeeId { get; set; }
        public int? InstructorDataId { get; set; }
        public int? TrainingCenterId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrInstructorVM : TrInstructorGeneralVM
    {
        public int Id { get; set; }

    }
    public class TrInstructorGetVM : TrInstructorVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string TrainingCenterName { get; set; }
        //public string InstructorName { get; set; } // Added property
        //header data
        public string? InstructorName { get; set; }
        public string? employeeName { get; set; }
        public string? InstructorCode { get; set; }
        public string? InstructorPhone { get; set; }
        public string? InstructorEmail { get; set; }
        public string? InstructorPosition { get; set; }
        public string? InstructorAddress { get; set; }
        public string? InstructorGender { get; set; }
        public string? InstructorCityName { get; set; }
        public int? InstructorCityID { get; set; }

    }
}
