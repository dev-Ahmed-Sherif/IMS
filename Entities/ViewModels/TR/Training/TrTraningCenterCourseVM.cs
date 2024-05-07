namespace Entities.ViewModels.TR
{
    public class TrTraningCenterGeneralVM
    {
        public int CourseId { get; set; }

        public int TrainingCenterId { get; set; }

        public string Rating { get; set; }

        public decimal Price { get; set; }

        public string Notes { get; set; }


        public int TransactionUserId { get; set; }
    }
    public class TrTrainingCenterCourseVM : TrTraningCenterGeneralVM
    {
        public int Id { get; set; }

    }
    public class TrTrainingCenterCourseGetVM : TrTrainingCenterCourseVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

        public string TraingingCenterName { get; set; }
        public string CourseName { get; set; }

    }
}
