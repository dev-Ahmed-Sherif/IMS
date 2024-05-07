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
        public string? HeaderName { get; set; }
        public string? employeeName { get; set; }
        public string? HeaderCode { get; set; }
        public string? HeaderPhone { get; set; }
        public string? HeaderEmail { get; set; }
        public string? HeaderPosition { get; set; }
        public string? HeaderAddress { get; set; }
        public string? HeaderGender { get; set; }
        public string? HeaderCityName { get; set; }
        public int? HeaderCityID { get; set; }

    }
}
