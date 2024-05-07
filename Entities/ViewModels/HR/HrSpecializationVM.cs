namespace Entities.ViewModels.HR
{
    public class HrSpecializationGeneralVM
    {


        public string name { get; set; }

        //Navigation foreign
        public int QualificationId { get; set; }

        public int TransactionUserId { get; set; }
    }
    public class HrSpecializationVM : HrSpecializationGeneralVM
    {
        public int Id { get; set; }
    }

    public class HrSpecializationGetVM : HrSpecializationVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string QualificationName { get; set; }
    }
}
