namespace Entities.ViewModels.TR.Course
{
    public class TrCourseTypeGeneralVM
    {
        public string Name { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrCourseTypeVM : TrCourseTypeGeneralVM
    {
        public int Id { get; set; }

    }
  
    public class TrCourseTypeGetVM : TrCourseTypeVM
    {
        public string CreateUserName { get; set; }
        //public string CourseTypeName { get; set; }
        //public string CourseCategoryName { get; set; }
    }

    public class TrCourseGetTypeSearchVM : TrCourseTypeGetVM
    {
        public string ReportDate { get; set; }
        public string Section { get; set; }

    }
    public class TrCourseTypeSearch
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string TransactionUserId { get; set; }
        public string CreateUserName { get; set; }
        //public string CourseTypeName { get; set; }
        //public string CourseCategoryName { get; set; }
        //public string? Hours { get; set; }
        //public string? Cost { get; set; }
        //public string? Price { get; set; }
        //public bool IsActive { get; set; }
        //public string? CategoryId { get; set; }
        //public string? CourseTypeId { get; set; }

    }
    public class TrCourseTypeReport : TrCourseTypeSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }
    }




}
