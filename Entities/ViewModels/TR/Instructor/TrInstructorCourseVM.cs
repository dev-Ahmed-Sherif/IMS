namespace Entities.ViewModels.TR.Instructor
{
    public class TrInstructorCourseGeneralVM
    {

        public string Rating { get; set; }

        public decimal price { get; set; }

        public string Notes { get; set; }

        public int InstructorId { get; set; }

        public int? CourseId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrInstructorCourseVM : TrInstructorCourseGeneralVM
    {
        public int Id { get; set; }
    }
    public class TrInstructorCourseGetVM : TrInstructorCourseVM
    {
        public string CourseName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string HeaderName { get; set; }
        public string employeeName { get; set; }
    }

}
