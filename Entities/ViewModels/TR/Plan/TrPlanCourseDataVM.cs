namespace Entities.ViewModels.TR.Plan
{
    public class TrPlanCourseDataGeneralVM
    {
        public string Version { get; set; }
        public string Code { get; set; }
        public bool IsMinimum { get; set; }
        public int? CourseId { get; set; }
        public int? PositionId { get; set; }
        public int? FinancialDegreeId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrPlanCourseDataVM : TrPlanCourseDataGeneralVM
    {
        public int Id { get; set; }

    }
    public class TrPlanCourseDataGetVM : TrPlanCourseDataVM
    {
        public string CreateUserName { get; set; }
        public string CourseName { get; set; }
        public string PositionName { get; set; }
        public string FinancialDegreeName { get; set; }
    }

}
