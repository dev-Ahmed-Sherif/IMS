namespace Entities.ViewModels.TR.Course
{
    public class TrCourseGeneralVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int TransactionUserId { get; set; }
        public int? CategoryId { get; set; }
        public int? CourseTypeId { get; set; }
    }
    public class TrCourseVM : TrCourseGeneralVM
    {
        public int Id { get; set; }

    }
    public class TrCourseGetVM : TrCourseVM
    {
        public string CreateUserName { get; set; }
        public string CourseTypeName { get; set; }
        public string CourseCategoryName { get; set; }
    }

    public class TrCourseGetSearchVM : TrCourseGetVM
    {
        public string ReportDate { get; set; }
        public string Section { get; set; }

    }
    public class TrCourseSearch
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? Hours { get; set; }
        public string? Cost { get; set; }
        public string? Price { get; set; }
        public bool IsActive { get; set; }
        public string? CategoryId { get; set; }
        public string? CourseTypeId { get; set; }

    }
    public class TrCourseReport : TrCourseSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }
    }




}
