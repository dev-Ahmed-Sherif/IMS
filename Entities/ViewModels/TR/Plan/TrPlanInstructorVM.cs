namespace Entities.ViewModels.TR.Plan
{
    public class TrPlanInstructorGeneralVM
    {
        public int PlanId { get; set; }

        public int InstructorId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrPlanInstructorVM : TrPlanInstructorGeneralVM
    {
        public int Id { get; set; }
    }
    public class TrPlanInstructorGetVM : TrPlanInstructorVM
    {
        public string PlanName { get; set; }
        public string InstructorName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }

    public class TrInstrctorDataVM
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsEmployee { get; set; }
        public string CreateUserName { get; set; }
        public string TrainingCenterName { get; set; }
        //header data
        public int? HeaderId { get; set; }
        public string? HeaderName { get; set; }
        public string? HeaderCode { get; set; }
        public string? HeaderPhone { get; set; }
        public string? HeaderEmail { get; set; }
        public string? HeaderPosition { get; set; }
        public string? HeaderAddress { get; set; }
        public string? HeaderGender { get; set; }
        public string? HeaderCityName { get; set; }
        public int PlanId { get; set; }
    }

}
