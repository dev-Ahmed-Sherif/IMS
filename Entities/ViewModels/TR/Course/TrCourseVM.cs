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
}
