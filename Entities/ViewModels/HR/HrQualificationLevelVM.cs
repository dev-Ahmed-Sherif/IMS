namespace Entities.ViewModels.HR
{
    public class HrQualificationLevelGeneralVM
    {


        public string name { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class HrQualificationLevelVM : HrQualificationLevelGeneralVM
    {
        public int Id { get; set; }

    }
    public class HrQualificationLevelGetVM : HrQualificationLevelVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }

}
