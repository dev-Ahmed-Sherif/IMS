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

    }
}
