namespace Entities.ViewModels.TR.Course
{
    public class TrCourseCategoryGeneralVM
    {
        public string Name { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrCourseCategoryVM : TrCourseCategoryGeneralVM
    {
        public int Id { get; set; }

    }
    public class TrCourseCategoryGetVM : TrCourseCategoryVM
    {
        public string CreateUserName { get; set; }

    }
}
